namespace EnterTheConsole
{
    public enum ItemType
    {
        Weapon,
        Armor,
        Consumable
    }

    internal class ItemDatabase
    {
        //아이템 리스트 배열
        private List<IItem> items = new List<IItem>(10);
        //아이템 데이터베이스에 접근할 프로퍼티
        public List<IItem> Items { get { return items; } }

        //객체 생성과 동시에 아이템 데이터 생성
        public ItemDatabase()
        {
            int itemId = 0;
            items.Add(new ItemWeapon(-1, "오류", "어째서?", 0, 0));
            items.Add(new ItemWeapon(itemId++, "철 검", "평범한 철검", 5, 100));
            items.Add(new ItemArmor(itemId ++, "가죽갑옷", "가죽재질의 갑옷", 5, 100));
            items.Add(new ItemHealPotion(itemId++, "하급 포션", "낮은 품질의 회복포션", 30, 50));
        }

        public IItem SearchByItemID(int itemId)
        {
            for(int i = 0; i < items.Count; i++)
            {
                if (items[i].ItemID == itemId)
                {
                    return items[i];
                }
            }

            return items[0];
        }
    }

    //아이템 인터페이스
    internal interface IItem
    {
        //아이디 -> 중복되지 않는 아이템의 고유 아이디
        public int ItemID { get; }
        //이름 -> 아이템 이름
        public string ItemName { get; }
        //아이템 설명
        public string ItemDescription {  get; }
        //아이템 타입
        public ItemType ItemType { get; }
        //아이템의 상점가
        public int ItemPrice { get; }

        /// <summary>
        /// 아이템 이름 | 아이템 스텟(공격력,방어력등) | 아이템 설명 형태로 string값 반환함,\n 아이템 설명을 반환하는 함수
        /// </summary>
        /// <returns></returns>
        public string ShowItemDescription();
    }

    //아이템 - 무기
    internal class ItemWeapon : IItem
    {
        public int ItemID { get; private set; }
        public string ItemName { get; private set;}
        public string ItemDescription { get; private set;}
        public ItemType ItemType { get; private set;}
        public int ItemDamage { get; private set;}
        public int ItemPrice { get; private set;}

        //생성자, 아이템의 아이디, 이름, 설명, 무기공격력, 가격을 지정
        public ItemWeapon(int itemID, string itemName, string description, int damage, int itemPrice)
        {
            ItemID = itemID;
            ItemName = itemName;
            ItemType = ItemType.Weapon;
            ItemDamage = damage;
            ItemDescription = description;
            ItemPrice = itemPrice;
        }

        //아이템 설명 반환
        public string ShowItemDescription()
        {
            string description = $"{ItemName,8} | 공격력 : {ItemDamage,2} | {ItemDescription,-15}";
            return description;
        }
    }

    //방어구
    internal class ItemArmor : IItem
    {
        public int ItemID { get; private set; }
        public string ItemName { get; private set; }
        public string ItemDescription { get; private set; }
        public ItemType ItemType { get; private set; }
        public int ItemDefence { get; private set; }
        public int ItemPrice { get; private set; }
        public ItemArmor(int itemID, string itemName, string description, int defence, int itemPrice)
        {
            ItemID = itemID;
            ItemName = itemName;
            ItemType = ItemType.Armor;
            ItemDefence = defence;
            ItemDescription = description;
            ItemPrice = itemPrice;
        }

        //아이템 설명 반환
        public string ShowItemDescription()
        {
            string description = $"{ItemName,8} | 방어력 : {ItemDefence,2} | {ItemDescription,-15}";
            return description;
        }
    }

    internal class ItemConsumable : IItem
    {
        public int ItemID { get; private set; }
        public string ItemName { get; private set; }
        public string ItemDescription { get; private set; }
        public ItemType ItemType { get; private set; }
        public int ItemPrice { get; private set; }

        public int ItemAmount { get; private set; }

        public ItemConsumable(int itemID, string itemName, string description, int amount, int itemPrice)
        {
            ItemID = itemID;
            ItemName = itemName;
            ItemType = ItemType.Consumable;
            ItemAmount = amount;
            ItemDescription = description;
            ItemPrice = itemPrice;
        }

        //아이템 설명 반환
        public virtual string ShowItemDescription()
        {
            string description = $"{ItemName,8} | 회복량 : {ItemAmount,2} | {ItemDescription,-15}";
            return description;
        }

        public virtual void UseItem(Character character)
        {
            
        }
    }

    internal class ItemHealPotion : ItemConsumable
    {
        public ItemHealPotion(int itemID, string itemName, string description, int amount, int itemPrice)
            : base(itemID, itemName, description, amount, itemPrice) { }

        public override string ShowItemDescription()
        {
            string description = $"{ItemName,8} | 회복량 : {ItemAmount,2} | {ItemDescription,-15}";
            return description;
        }

        public override void UseItem(Character character)
        {
            Console.WriteLine("체력이 회복되었습니다.");
            int temp = character.Health;
            //회복
            character.GetHeal(ItemAmount);
            Console.WriteLine($"체력 : {temp} -> {character.Health}");
            Console.ReadLine();
        }
    }
}
