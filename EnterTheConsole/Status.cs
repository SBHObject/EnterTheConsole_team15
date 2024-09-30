namespace EnterTheConsole
{    
        internal class Status
        {
            //이름
            public string Name { get; private set; }

            //직업
            public string Job { get; private set; }

            //최대 체력
            private int maxHealth;
            //현재 체력
            public int Health { get; private set; }

            //기본 공격력
            private int attack;
            //실제 공격력
            public int Attack { get; private set; }

            //기본 방어력
            private int defence;
            //실제 방어력
            public int Defence { get; private set; }

            //소지금
            public int PlayerGold { get; private set; }

            //레벨
            public int PlayerLevel { get; private set; } = 0;

            public Status(int level, string name, string job, int atk, int def, int hp, int gold)
            {
                PlayerLevel = level;
                Name = name;
                Job = job;
                attack = atk;
                defence = def;
                Health = hp;
                PlayerGold = gold;
            }

            public Status()
            {
            }

            public void DisplayCharacterInfo()
            {

                Console.WriteLine($"LV. {PlayerLevel:D2}");
                Console.WriteLine($"{Name} ( {Job} )");
                Console.WriteLine(Attack == 0 ? $"공격력 : {attack}" : $"공격력 : {Attack} ");
                Console.WriteLine(Defence == 0 ? $"방어력 : {defence}" : $"방어력 : {Defence}");
                Console.WriteLine($"체 력 : {Health}");
                Console.WriteLine($"Gold : {PlayerGold} G");
            }
        }
    
}
    

