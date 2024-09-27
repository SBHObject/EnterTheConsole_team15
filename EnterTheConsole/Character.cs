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

        //레벨관련 -> 경험치와 레벨
        public int PlayerExp { get; private set; } = 0;
        public int PlayerLevel { get; private set; } = 0;

        //사망관련
        public bool IsDead { get; private set; } = false;

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
            while (true)
            {
                Console.Clear();
                Console.WriteLine("캐릭터를 생성합니다.");
                Console.WriteLine();
                Console.WriteLine("캐릭터 이름을 입력해주세요");
                string nameInput = Console.ReadLine();
                Console.Clear();
                Console.WriteLine($"\"{nameInput}\" 이 이름이 맞습니까?");
                Console.WriteLine($"1.예 2.아니오");
                if(ut.Selecter(Console.ReadLine(), 2) == 1)
                {
                    Console.WriteLine("게임을 시작합니다.");
                    break;
                }
            }
        }

        //플레이어가 데미지 받는 함수
        public void TakeDamage(int damage)
        {
            Health -= damage;
            //TODO 사망
        }

        //돈 얻기
        public void GetGold(int amount)
        {
            PlayerGold += amount;
        }

        //돈 쓰기
        public bool LoseGold(int amount)
        {
            //돈이 부족하면 false 반환, 돈을 차감하지 않음
            if(amount > PlayerGold)
            {
                Console.WriteLine("소지금이 부족합니다.");
                return false;
            }
            else
            {
                PlayerGold -= amount;
                return true;
            }
        }

        //체력 회복
        public void GetHeal(int amount)
        {
            int temp = Health + amount;
            //회복량이 체력 최대치를 넘으면, 최대체력으로
            Health = (temp > maxHealth)? maxHealth : temp;
        }
    }
}
