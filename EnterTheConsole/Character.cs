namespace EnterTheConsole
{
    internal class Character
    {
        //유틸리티 클래스 예제
        Utility ut = Utility.Instance;

        //이름
        public string Name { get; private set; }

        //최대체력
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
        public int Defence { get; private set;}

        //소지금
        public int PlayerGold { get; private set; }

        //생성자 - 기본값 초기화
        /// <summary>
        /// new Character 생성자 사용하지 말고 Program.player 사용해서 객체 가져올것
        /// 혹은 매개변수로 Character 사용해서 메인에서 플레이어 객체 가져올것
        /// </summary>
        public Character()
        {
            maxHealth = 100;
            attack = 10;
            defence = 10;
            PlayerGold = 100;

            Health = maxHealth;
            Attack = attack;
            Defence = defence;
            Name = "player";
        }

        //캐릭터 생성
        public void CreatePlayer(string name)
        {
            Console.WriteLine("캐릭터를 생성합니다.");
            Console.WriteLine();
        }
    }
}
