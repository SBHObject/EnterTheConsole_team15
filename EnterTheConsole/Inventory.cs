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
        public IItem[] PlayerEquip
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

        public void EquipItem(int index)
        {
            if (playerInven[index].ItemType == ItemType.Weapon)
            {
                if (playerEquip[0] == null)
                {
                    playerEquip[0] = playerInven[index];
                    RemoveItem(index);
                }
                else
                {
                    IItem temp = playerEquip[0];
                    playerEquip[0] = playerInven[index];
                    RemoveItem(index);
                    AddItem(temp);
                }
            }
            else if (playerInven[index].ItemType == ItemType.Armor)
            {
                if (playerEquip[1] == null)
                {
                    playerEquip[0] = playerInven[index];
                    RemoveItem(index);
                }
                else
                {
                    IItem temp = playerEquip[1];
                    playerEquip[0] = playerInven[index];
                    RemoveItem(index);
                    AddItem(temp);
                }
            }
        }

        public void ShowInventory()
        {
            for(int i = 0; i < playerInven.Length; i++)
            {
                string showItem = $"{i + 1}. {playerInven[i].ShowItemDescription}";
                Console.Write(showItem);
            }
        }

        public void ShowEquip()
        {
            Console.WriteLine($"무기 : {playerInven[0].ShowItemDescription}");
            Console.WriteLine($"방어구 : {playerInven[1].ShowItemDescription}");
        }
    }
}
