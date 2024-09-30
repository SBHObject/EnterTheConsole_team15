namespace EnterTheConsole
{
    internal class Shop
    {
        //아이템 데이터베이스 객체
        private ItemDatabase itemDb = new ItemDatabase();
        //유틸리티 인스턴스
        private Utility ut = Utility.Instance;
        //플레이어 객체 가져오기
        private Character player;


        //상점 아이템 리스트
        private List<IItem> shopItems = new List<IItem>();
        //외부에서 읽어들일 프로퍼티
        public List<IItem> ShopItems { get {  return shopItems; } }

        public Shop(Character _player)
        {
            player = _player;
            //이후 상점변경 가능
            //아이템 데이터베이스의 모든 아이템을 상점 아이템 리스트에 추가
            foreach (var item in itemDb.Items)
            {
                shopItems.Add(item);
            }
            //오류 처리용 아이템 리스트에서 제거
            shopItems.Remove(itemDb.SearchByItemID(-1));
        }

        //플레이어가 아이템을 구매할 때 호출
        public void BuyItem(int index)
        {
            if (player.LoseGold(shopItems[index].ItemPrice))
            {
                Console.WriteLine($"{shopItems[index].ItemName}을 구매했습니다.");
                player.playerInven.AddItem(shopItems[index]);
            }
        }

        //플레이어가 아이템을 팔 때 호출
        public void SellItem(IItem item)
        {
            //플레이어가 골드 획득(차후 구현)
            player.GetGold(item.ItemPrice);
        }

        public void ShowShop()
        {
            Console.Clear();
            Console.WriteLine("[상점]");
            Console.WriteLine();

            //아이템 목록
            for(int i = 0; i < shopItems.Count; i++)
            {
                //아이템의 정보 출력
                string shopItemText = (i + 1) + "." + shopItems[i].ShowItemDescription() 
                    + " | " + shopItems[i].ItemPrice + "G  ";

                Console.WriteLine(shopItemText);
            }
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("구매할 아이템을 선택해주세요. 표기된 숫자 이외의 입력시, 상점에서 나갑니다.");

                //플레이어에게 입력받기
                int input = ut.Selecter(Console.ReadLine(), shopItems.Count);
                // 1 ~ 사이 숫자일경우
                if (input >= 1 && input <= shopItems.Count)
                {
                    Console.WriteLine($"{shopItems[input - 1].ItemName}을 구매하시겠습니까?");
                    Console.WriteLine("1.예 2.아니오 (1이외 입력시, 아니오)");
                    if(Console.ReadLine() == "1")
                    {
                        //차후 구현시, 돈 부족 여부를 판단해야함
                        BuyItem(input);
                        Console.WriteLine($"{shopItems[input - 1].ItemName}을 구매했습니다.");
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    Console.WriteLine("상점 나가기");
                    Thread.Sleep(1000);
                    break;
                }
            }
        }
    }
}
