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
            if (playerInven[index] == null)
            {
                Console.WriteLine("아이템이 없습니다");
                Console.ReadLine();
            }
            else
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
                else
                {
                    Console.WriteLine("해당아이템은 장착할 수 없습니다.");
                    Console.ReadLine();
                }
            }
        }

        public void ShowInventory()
        {
            for(int i = 0; i < playerInven.Length; i++)
            {
                string showItem;
                if (playerInven[i] == null)
                {
                    showItem = $"{i + 1}.";
                }
                else
                {
                    showItem = $"{i + 1}. {playerInven[i].ShowItemDescription()}";
                }
                Console.WriteLine(showItem);
            }
        }

        public void ShowEquip()
        {
            if (playerEquip[0] == null)
            {
                Console.WriteLine("무기 : 없음");
            }
            else
            {
                Console.WriteLine($"무기 : {playerEquip[0].ShowItemDescription()}");
            }

            if (playerEquip[1] == null)
            {
                Console.WriteLine("방어구 : 없음");
            }
            else
            {
                Console.WriteLine($"방어구 : {playerEquip[1].ShowItemDescription()}");
            }
        }

        public void ShowInventoryMenu()
        {
            Console.Clear();
            Console.WriteLine("[인벤토리]");
            Console.WriteLine();
            Console.WriteLine("소지한 아이템을 확인하고, 관리할 수 있습니다.");

            Console.WriteLine();
            Console.WriteLine("[장착중인 장비]");
            ShowEquip();
            Console.WriteLine();
            Console.WriteLine("[가방]");
            ShowInventory();

            Console.WriteLine();
            Console.WriteLine("1. 장비 장착\n0. 나가기");
            if (Console.ReadLine() == "1")
            {
                ShowEquipMenu();
            }
        }

        public void ShowEquipMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[장비 장착]");
                Console.WriteLine();
                Console.WriteLine("[장착중인 장비]");
                ShowEquip();
                Console.WriteLine();
                Console.WriteLine("[가방]");
                ShowInventory();
                Console.WriteLine();
                Console.WriteLine("장착할 아이템의 번호를 입력해주세요. 없는 번호 입력시 창을 종료합니다.");
                int input = Utility.Instance.Selecter(Console.ReadLine(), playerInven.Length);
                if (input >= 1 && input < playerInven.Length)
                {
                    EquipItem(input - 1);
                }
                else
                {
                    ShowInventoryMenu();
                    break;
                }
            }
        }
    }
}
