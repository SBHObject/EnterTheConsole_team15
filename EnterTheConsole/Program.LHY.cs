using Play_LHY;
using System;
using System.Collections.Generic;

//public class Program
//{
//    static void Main()
//    {
//        Random random = new Random();
//        int numberOfMonsters = random.Next(1, 5); // 1~4마리의 몬스터가 랜덤하게 등장
//        List<Monster> monsters = new List<Monster>();

//        for (int i = 0; i < numberOfMonsters; i++)
//        {
//            int monsterType = random.Next(1, 4); // 1~3의 몬스터 종류 랜덤
//            switch (monsterType)
//            {
//                case 1:
//                    monsters.Add(new Monster("Lv2 미니언", 15, 5));
//                    break;
//                case 2:
//                    monsters.Add(new Monster("Lv3 공허충", 10, 9));
//                    break;
//                case 3:
//                    monsters.Add(new Monster("Lv5 대포미니언", 25, 8));
//                    break;
//            }
//        }

//        Player player = new Player("Chad", 100);

//        Console.WriteLine("전투 시작!");
//        foreach (var monster in monsters)
//        {
//            Console.WriteLine($"{monster.Name} 등장! HP: {monster.HP}, ATK: {monster.ATK}");
//        }

//        while (true)
//        {
//            Console.WriteLine("\n대상을 선택해주세요.");
//            for (int i = 0; i < monsters.Count; i++)
//            {
//                var monster = monsters[i];
//                if (monster.HP > 0)
//                {
//                    Console.WriteLine($"{i + 1}. {monster.Name} HP: {monster.HP}");
//                }
//                else
//                {
//                    Console.ForegroundColor = ConsoleColor.DarkGray;
//                    Console.WriteLine($"{i + 1}. {monster.Name} Dead");
//                    Console.ResetColor();
//                }
//            }
//            Console.WriteLine("0. 취소");

//            int choice;
//            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > monsters.Count)
//            {
//                Console.WriteLine("잘못된 입력입니다.");
//                continue;
//            }

//            if (choice == 0)
//            {
//                Console.WriteLine("전투를 종료합니다.");
//                break;
//            }

//            var selectedMonster = monsters[choice - 1];
//            if (selectedMonster.HP <= 0)
//            {
//                Console.WriteLine("잘못된 입력입니다.");
//                continue;
//            }

//            int attackPower = random.Next(9, 12); // 공격력 10, 오차 1, 최종 공격력 9 ~ 11 랜덤 값
//            selectedMonster.HP -= attackPower;
//            Console.WriteLine($"{selectedMonster.Name}을(를) 공격했습니다! 공격력: {attackPower}");

//            if (selectedMonster.HP <= 0)
//            {
//                selectedMonster.HP = 0;
//                Console.WriteLine($"{selectedMonster.Name}이(가) 죽었습니다!");
//            }

//            foreach (var monster in monsters)
//            {
//                if (monster.HP > 0)
//                {
//                    int monsterAttackPower = random.Next((int)Math.Ceiling(monster.ATK * 0.9), (int)Math.Ceiling(monster.ATK * 1.1) + 1);
//                    player.HP -= monsterAttackPower;
//                    Console.WriteLine($"{monster.Name}의 공격! {player.Name}을(를) 맞췄습니다. [데미지: {monsterAttackPower}]");
//                    Console.WriteLine($"{player.Name} HP: {player.HP + monsterAttackPower} -> {player.HP}");

//                    if (player.HP <= 0)
//                    {
//                        Console.WriteLine($"{player.Name}이(가) 죽었습니다! 게임 오버!");
//                        ShowResult(false, player, monsters);
//                        return;
//                    }

//                    Console.WriteLine("0. 다음");
//                    if (Console.ReadLine() != "0")
//                    {
//                        Console.WriteLine("잘못된 입력입니다.");
//                    }
//                }
//            }

//            // 모든 몬스터가 죽었는지 확인
//            if (monsters.TrueForAll(m => m.HP <= 0))
//            {
//                ShowResult(true, player, monsters);
//                return;
//            }
//        }
//    }

//    static void ShowResult(bool victory, Player player, List<Monster> monsters)
//    {
//        Console.WriteLine("\nBattle!! - Result");
//        if (victory)
//        {
//            Console.WriteLine("Victory");
//            Console.WriteLine($"던전에서 몬스터 {monsters.Count}마리를 잡았습니다.");
//        }
//        else
//        {
//            Console.WriteLine("You Lose");
//        }
//        Console.WriteLine($"{player.Name}");
//        Console.WriteLine($"HP 100 -> {player.HP}");
//        Console.WriteLine("0. 다음");
//        Console.ReadLine();
//    }

//}
