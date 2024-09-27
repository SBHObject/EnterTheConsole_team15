using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void AddItem(IItem item)
        {
            for (int i = 0; i < PlayerInven.Length; i++)
            {
                if (playerInven[i] == null)
                {
                    playerInven[i] = item;
                }
            }
        }
    }
}
