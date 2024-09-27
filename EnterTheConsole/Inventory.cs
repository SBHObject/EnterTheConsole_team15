﻿namespace EnterTheConsole
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

            Console.WriteLine("인벤토리가 꽉찼습니다.");
            Thread.Sleep(1000);
            return false;
        }

        //인벤토리 아이템 제거 함수
        public bool RemoveItem(int indexNum)
        {
            if (playerInven[indexNum] == null)
            {
                Console.WriteLine("선택한 슬롯에 아이템이 없습니다.");
                Thread.Sleep(1000);
                return false;
            }
            else
            {
                playerInven[indexNum] = null;
                return true;
            }
        }

        public bool UseItem(int index)
        {
            switch(playerInven[index].ItemType)
            {
                case ItemType.Weapon:
                    if (playerEquip[0] == null)
                    {
                        playerEquip[0] = playerInven[index];
                        playerInven[index] = null;
                    }
                    else
                    {
                        IItem temp = playerEquip[0];
                        playerEquip[0] = playerInven[index];
                        playerInven[index] = temp;
                    }
                    Console.WriteLine($"{playerInven[index].ItemName}를 장착했습니다");
                    return true;

                case ItemType.Armor:
                    if (playerEquip[1] == null)
                    {
                        playerEquip[1] = playerInven[index];
                        playerInven[index] = null;
                    }
                    else
                    {
                        IItem temp = playerEquip[1];
                        playerEquip[1] = playerInven[index];
                        playerInven[index] = temp;
                    }
                    Console.WriteLine($"{playerInven[index].ItemName}를 장착했습니다");
                    return true;

                case ItemType.Consumable:
                    Console.WriteLine("소모품을 사용하였습니다.");
                    return true;

                default:
                    Console.WriteLine("아이템 사용에 실패하였습니다.");
                    return false;
            }
        }
    }
}
