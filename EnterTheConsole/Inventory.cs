namespace EnterTheConsole
{
    internal class Inventory
    {
        //임시로 10칸짜리 가방 생성
        private IItem[] playerInven = new IItem[10];
        //인벤토리 내용을 확인하기 위한 프로퍼티
        public IItem[] PlayerInven
        {
            get { return playerInven; }
        }

        //장착 장비를 관리하는 배열
        private IItem[] playerEquip = new IItem[2];
        public IItem PlayerEquip
        {
            get { return PlayerEquip; }
        }

        //인벤토리에 아이템을 넣는 함수
        public bool AddItem(IItem item)
        {
            for (int i = 0; i < PlayerInven.Length; i++)
            {
                //인벤토리 배열에 빈자리가 있으면 그 자리에 넣고 반복문 종료
                if (playerInven[i] == null)
                {
                    playerInven[i] = item;
                    return true;
                }
            }

            //반복문에서 return을 못할경우, 인벤토리가 꽉 찬상태 -> 실패 반환
            Console.WriteLine("인벤토리가 꽉찼습니다.");
            Thread.Sleep(1000);
            return false;
        }

        //인벤토리 아이템 제거 함수
        public bool RemoveItem(int indexNum)
        {
            //인덱스를 매개변수로 받아서, 인덱스위치의 아이템 확인
            if (playerInven[indexNum] == null)
            {
                Console.WriteLine("선택한 슬롯에 아이템이 없습니다.");
                Thread.Sleep(1000);
                //실패 반환
                return false;
            }
            else
            {
                //인덱스에 아이템이 있으면 삭제
                playerInven[indexNum] = null;
                return true;
            }
        }

        public bool UseItem(int index)
        {
            //아이템의 종류에 따라 달라짐
            switch(playerInven[index].ItemType)
            {
                //무기일경우
                case ItemType.Weapon:
                    //장비 슬롯에 아이템이 없으면 장착
                    if (playerEquip[0] == null)
                    {
                        playerEquip[0] = playerInven[index];
                        RemoveItem(index);
                    }
                    else
                    {
                        //있으면 교체
                        IItem temp = playerEquip[0];
                        playerEquip[0] = playerInven[index];
                        playerInven[index] = temp;
                    }
                    Console.WriteLine($"{playerInven[index].ItemName}를 장착했습니다");
                    return true;

                //방어구일경우
                case ItemType.Armor:
                    //무기와 같은 기능, 슬롯이 달라짐
                    if (playerEquip[1] == null)
                    {
                        playerEquip[1] = playerInven[index];
                        RemoveItem(index);
                    }
                    else
                    {
                        IItem temp = playerEquip[1];
                        playerEquip[1] = playerInven[index];
                        playerInven[index] = temp;
                    }
                    Console.WriteLine($"{playerInven[index].ItemName}를 장착했습니다");
                    return true;

                //소모품인경우
                case ItemType.Consumable:
                    Console.WriteLine("소모품을 사용하였습니다.");
                    return true;

                //그 외 입력이 들어올경우 아이템 사용 실패 -> 버그
                default:
                    Console.WriteLine("아이템 사용에 실패하였습니다.");
                    return false;
            }
        }
    }
}
