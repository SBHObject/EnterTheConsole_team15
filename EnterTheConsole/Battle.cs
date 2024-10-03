namespace EnterTheConsole
{
    //Program 클래스와 Main 함수는 단 하나만 존재해야합니다.
    //또한 Main 함수에 게임의 모든 내용을 담아야하기 때문에 클래스로 나누어서 구현하게됩니다.
    internal class Battle
    {
        //전투시 사용할 함수입니다.
        //메인에서 이 함수를 호출했을때, 전투가 진행되도록 코드를 짜주면 됩니다.
        //매개변수로써 플레이어 클래스의 객체를 가져와 사용합니다.
        public void Stage(Character player)
        {
            Random random = new Random();
            int numberOfMonsters = random.Next(1, 5); // 1~4마리의 몬스터가 랜덤하게 등장
            List<Monster> monsters = new List<Monster>(numberOfMonsters);
            //함수 내부에서 새로운 객체를 생성하는건 좋은것 같습니다.
            //다만, 이 경우 모든 전투에서 여기서 선언된 종류와 스텟의 몬스터만 등장하게됩니다.
            //몬스터를 생성하는 함수를 추가로 만들고, 필드에 몬스터 배열을 만들어서 플레이어의 상태 혹은 스테이지에 따라
            //등장 몬스터를 다르게 할 수도 있을것 같습니다.
            for(int i = 0; i < numberOfMonsters; i++)
            {
                int monsterType = random.Next(1, 5);
                switch(monsterType)
                {
                    case 1:
                        monsters.Add(new Monster("근접 미니언", 15, 5, 2));
                        break;
                    case 2:
                        monsters.Add(new Monster("공허충", 10, 9, 3));
                        break;
                    case 3:
                        monsters.Add(new Monster("대포 미니언", 25, 8, 5));
                        break;
                    case 4:
                        monsters.Add(new Monster("원거리 미니언", 10, 8, 3));
                        break;
                }
            }

            //전투 시작전, 플레이어의 체력을 저장해둡니다.
            int beforeHP = player.Health;
            //살아있는 몬스터의 숫자 입니다. 승패 판정을 위해 사용됩니다.
            int livingMonsters = monsters.Count;
            //턴 구분을 위한 변수입니다.
            bool isPlayerTurn = true;

            //플레이어 객체는 매개변수를 통해서 가져오게 되었습니다.
            //살아있는 몬스터의 숫자가 0이 아니면 계속 반복됩니다.
            while (livingMonsters != 0)
            {
                Console.Clear();
                Console.WriteLine("전투 시작!");
                Console.WriteLine();
                int count = 1;
                foreach(Monster monster in monsters)
                {
                    //몬스터의 사망 여부에 따라 표기를 변경해주는 기능입니다.
                    if (monster.IsDead == false)
                    {
                        Console.WriteLine($"{count++:D2}. Lv.{monster.Level:D2} {monster.Name:D5} HP {monster.HP}");
                    }
                    else
                    {
                        //사망한 몬스터는 체력 대신 Dead 를 표기하고, 색을 회색으로 바꿔줍니다.
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{count++:D2}. Lv.{monster.Level:D2} {monster.Name:D5} Dead");
                        Console.ResetColor();
                    }
                }

                Console.WriteLine();
                //플레이어의 정보를 출력합니다.
                Console.WriteLine("[내정보]");
                Console.WriteLine($"Lv.{player.PlayerLevel:D2} {player.Name} ({player.PlayerJob})");
                Console.WriteLine();

                //누구의 턴인지에 따라 출력이 달라집니다.
                //플레이어의 턴이 끝나고, 콘솔을 다시 출력하여 몬스터의 사망여부를 판정하기 위한 방법입니다.
                if (isPlayerTurn)
                {
                    Console.WriteLine("공격할 적을 입력해주세요 (0. 도망가기)");
                    //유틸리티 클래스로 구현해둔 string -> int 변환기 입니다.
                    //이 프로젝트에서 편하게 쓰려고 만든 함수이기 때문에 외부에서는 사용이 불가능합니다.
                    int input = Utility.Instance.Selecter(Console.ReadLine(), monsters.Count);
                    if (input == 0)
                    {
                        Console.WriteLine("전투를 종료합니다.");
                        //전투를 즉시 종료하기위해 break를 통해 반복문을 즉시 끝내줍니다.
                        break;
                    }
                    //몬스터를 제데로 고를경우의 행동입니다.
                    else if (input >= 1 && input <= monsters.Count)
                    {
                        if (monsters[input-1].IsDead == false)
                        {
                            //좀 더 쉽게 쓰기위해 클래스를 선언해주었습니다...
                            Monster target = monsters[input-1];
                            //데미지 계산입니다.
                            //플레이어 객체로부터 공격력을 참조하여 구현해주어야합니다.
                            //또한, 현재 정수형만 쓰고있기 때문에, 소수점이 없이 구현해주어야합니다.
                            int minDamage = (player.Attack / 10 >= 1) ? player.Attack - player.Attack / 10 : player.Attack - 1;
                            int maxDamage = (player.Attack / 10 >= 1) ? player.Attack + player.Attack / 10 : player.Attack + 1;
                            //계산이 끝난 실제로 줄 데미지 입니다.
                            int realDamage = random.Next(minDamage, maxDamage + 1);
                            Console.WriteLine($"{player.Name} 의 공격!");
                            //클래스 선언을 따로 안해주면 이렇게 쓰게 됩니다...
                            //Console.WriteLine($"Lv.{monsters[input - 1].Level:D2} {monsters[input - 1].Name} 을 맞췄습니다. [데미지 : {realDamage}] ")
                            Console.WriteLine($"Lv.{target.Level:D2} {target.Name} 을 맞췄습니다. [데미지 : {realDamage}]");

                            //공격 결과를 표기합니다.
                            Console.WriteLine();
                            //먼저, 데미지 계산 전의 대상의 체력을 저장합니다.
                            int temp = target.HP;
                            //공격을 받은 몬스터의 체력을 깍습니다.
                            target.TakeDamage(realDamage);
                            Console.WriteLine($"Lv.{target.Level:D2} {target.Name}");
                            if(target.IsDead == true)
                            {
                                //공격 처리 전 체력을 표기한 뒤, 사망 혹은 현재체력을 표기합니다.
                                //공격으로 대상이 죽었을때의 표기입니다.
                                Console.WriteLine($"HP {temp} -> Dead");
                                //생존중인 몬스터의 숫자를 1 줄입니다.
                                livingMonsters--;
                            }
                            else
                            {
                                Console.WriteLine($"HP {temp} -> {target.HP}");
                            }

                            Console.WriteLine("0.다음");
                            Console.ReadLine();

                            //성공적을 공격했을경우 턴을 마칩니다.
                            isPlayerTurn = false;
                        }
                        else
                        {
                            Console.WriteLine("선택한 몬스터는 이미 죽었습니다..");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("잘못된 선택입니다.");
                        Console.ReadLine();
                        //이 경우, continue 아래의 코드를 실행하지 않고 다음 반복으로 넘어갑니다.
                        continue;
                    }
                }
                else
                {
                    //몬스터의 턴입니다.
                    foreach (Monster monster in monsters)
                    {
                        //몬스터가 죽지 않았을경우, 플레이어를 공격합니다.
                        if(monster.IsDead == false)
                        {
                            //플레이어에게 줄 데미지를 정합니다.
                            int minDamage = (monster.ATK / 10 >= 1) ? monster.ATK - monster.ATK / 10 : monster.ATK - 1;
                            int maxDamage = (monster.ATK / 10 >= 1) ? monster.ATK + monster.ATK : monster.ATK + 1;
                            int realDamage = random.Next(minDamage, maxDamage + 1);

                            //데미지를 계산합니다.
                            int temp = player.Health;
                            //단, 플레이어에게는 방어력이 존재합니다.
                            //방어력만큼 데미지를 감소시킵니다. 만약 방어력이 데미지를 넘었을경우 1의 데미지를 줍니다.
                            realDamage = (realDamage - player.Defence > 0) ? realDamage - player.Defence : 1;
                            player.TakeDamage(realDamage);

                            //결과를 출력합니다.
                            Console.WriteLine($"Lv.{monster.Level:D2} {monster.Name} 의 공격!");
                            Console.WriteLine($"{player.Name} 을(를) 맞췄습니다. [데미지 : {realDamage}]");

                            Console.WriteLine();
                            //플레이어의 체력을 표기합니다.
                            Console.WriteLine($"Lv.{player.PlayerLevel:D2} {player.Name}");
                            Console.WriteLine($"HP {temp} -> {player.Health}");

                            Console.WriteLine();
                            Console.WriteLine("0.다음");
                            Console.ReadLine();
                        }

                        //몬스터의 공격마다, 플레이어의 사망을 확인합니다
                        if(player.IsDead == true)
                        {
                            break;
                        }
                    }

                    //몬스터의 턴을 마칩니다.
                    isPlayerTurn = true;
                }
            }

            Console.Clear();

            //반복문 종료후, 생존 몬스터의 숫자에 따라서 결과를 달리합니다.
            if(livingMonsters == 0)
            {
                //생존수 0 -> 승리
                Console.WriteLine("전투 결과");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("승리!");
                Console.ResetColor();
                Console.WriteLine();

                Console.WriteLine($"던전에서 몬스터를 {monsters.Count}마리 잡았습니다.");
                Console.WriteLine();

                Console.WriteLine($"Lv.{player.PlayerLevel} {player.Name}");
                Console.WriteLine($"HP {beforeHP} -> {player.Health}");
                //임시로, 처치한 몬스터 한마리당 100G를 주니다.
                player.GetGold(100 * monsters.Count);
                Console.WriteLine($"{100 * monsters.Count}G 를 보상으로 받았습니다.");
                Console.WriteLine();

                Console.WriteLine("0.다음");
                Console.ReadLine();
            }
            else
            {
                //생존후 0이 아닐경우, 사망여부에 따라 게임오버, 도주를 선택합니다.
                if(player.IsDead == true)
                {
                    Console.WriteLine("전투 결과");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("패배");
                    Console.ResetColor();
                    Console.WriteLine();

                    Console.WriteLine("당신은 사망하였습니다.");
                    Console.WriteLine();

                    Console.WriteLine("0.다음");
                    Console.ReadLine();

                    //체력을 최대체력의 10%만큼 회복시키고 사망여부를 false로 바꿉니다.
                    player.Revive();
                }
                else
                {
                    Console.WriteLine("전투 결과");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("패배");
                    Console.ResetColor();
                    Console.WriteLine();

                    Console.WriteLine($"당신은 던전에서 도망쳤습니다.");
                    Console.WriteLine();

                    Console.WriteLine($"Lv.{player.PlayerLevel} {player.Name}");
                    Console.WriteLine($"HP {beforeHP} -> {player.Health}");
                    Console.WriteLine();

                    Console.WriteLine("0.다음");
                    Console.ReadLine();
                }
            }
        }
    }
}
