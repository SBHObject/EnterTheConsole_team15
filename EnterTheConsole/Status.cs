﻿namespace EnterTheConsole
{
    internal class Status
    {
        public void DisplayCharacterInfo(Character player)
        {
            Console.Clear();
            Console.WriteLine($"LV. {player.PlayerLevel:D2}");
            Console.WriteLine($"{player.Name} ( {player.PlayerJob} )");
            Console.WriteLine($"공격력 : {player.Attack} ");
            Console.WriteLine($"방어력 : {player.Defence}");
            Console.WriteLine($"체 력 : {player.Health}");
            Console.WriteLine($"Gold : {player.PlayerGold} G");

            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.ReadLine();
        }
    }
    
}
    

