namespace EnterTheConsole
{
    public enum Job
    {
        Warrior,
        Thief
    }

    internal class Character
    {
        //유틸리티 클래스 예제
        private Utility ut = Utility.Instance;

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
        public int PlayerLevel { get; private set; } = 1;

        //사망관련
        public bool IsDead { get; private set; } = false;

        //인벤토리
        public Inventory playerInven = new Inventory();

        private Job playerJob;
        public string PlayerJob
        {
            get
            {
                switch(playerJob)
                {
                    case Job.Warrior:
                        return "전사";

                    case Job.Thief:
                        return "도적";

                    default:
                        return "???";
                }
            }
        }

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

            //이벤트 함수 등록, 장비 변경시 스텟 업데이트 함수 호출
            playerInven.UpdateStatus += UpdateStatus;
        }

        //캐릭터 생성
        public void CreatePlayer()
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

                if(ut.Selecter(Console.ReadLine(), 2) != 1)
                {
                    continue;
                }

                Name = nameInput;
                Console.WriteLine();
                Console.WriteLine("직업을 선택해주세요.");
                Console.WriteLine("1. 전사\n2. 도적");
                int input = ut.Selecter(Console.ReadLine(), 2);
                switch(input)
                {
                    case 1:
                        SettingJobStatus(Job.Warrior);
                        break;
                    case 2:
                        SettingJobStatus(Job.Thief);
                        break;
                    default:
                        continue;
                }

                Console.Clear();
                Console.WriteLine($"이름 : {Name}\n직업 : {PlayerJob}");
                Console.WriteLine();
                Console.WriteLine("이 내용이 맞습니까?");
                Console.WriteLine("1. 예\n0.아니오 (1이외의 입력시, 아니오)");
                if(Console.ReadLine() == "1")
                {
                    Console.WriteLine("게임을 시작합니다.");
                    Console.ReadLine();
                    break;
                }
                else
                {
                    continue;
                }
                
            }
        }

        private void SettingJobStatus(Job job)
        {
            playerJob = job;

            switch(playerJob)
            {
                case Job.Warrior:
                    maxHealth = 100;
                    attack = 10;
                    defence = 12;
                    break;
                case Job.Thief:
                    maxHealth = 90;
                    attack = 15;
                    defence = 8;
                    break;
                default:
                    Health = 1;
                    Attack = 1;
                    Defence = 1;
                    break;
            }

            Health = maxHealth;
            Attack = attack;
            Defence = defence;
        }

        //플레이어가 데미지 받는 함수
        public void TakeDamage(int damage)
        {
            Health -= damage;
            //사망
            if(Health <= 0)
            {
                IsDead = true;
            }
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

        //중복기능... 이후 처리 생각하기
        public bool UseItem(int index)
        {
            //아이템의 종류에 따라 달라짐
            switch (playerInven.PlayerInven[index].ItemType)
            {
                //장비일경우
                case ItemType.Weapon:
                case ItemType.Armor:
                    playerInven.EquipItem(index);
                    Console.WriteLine($"{playerInven.PlayerInven[index].ItemName}를 장착했습니다");
                    return true;

                //소모품인경우
                case ItemType.Consumable:
                    Console.WriteLine("소모품을 사용하였습니다.");
                    ItemConsumable usedItem = (ItemConsumable)playerInven.PlayerInven[index];
                    //아이템 사용
                    usedItem.UseItem(this);
                    playerInven.RemoveItem(index);
                    return true;

                //그 외 입력이 들어올경우 아이템 사용 실패 -> 버그
                default:
                    Console.WriteLine("아이템 사용에 실패하였습니다.");
                    return false;
            }
        }

        //장비에 따른 스테이터스 업데이트
        public void UpdateStatus()
        {
            //무기 장착에 따른 공격력 변화
            if (playerInven.PlayerEquip[0] != null)
            {
                ItemWeapon equipedWeapon = (ItemWeapon)playerInven.PlayerEquip[0];
                Attack = attack + equipedWeapon.ItemDamage;
            }
            else
            {
                Attack = attack;
            }

            //방어구 장착에 따른 방어력 변화
            if (playerInven.PlayerEquip[1] != null)
            {
                ItemArmor equipedArmor = (ItemArmor)playerInven.PlayerEquip[1];
                Defence = defence + equipedArmor.ItemDefence;
            }
            else
            {
                Defence = defence;
            }
        }
    }
}
