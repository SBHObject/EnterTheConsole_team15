using System.Diagnostics;

namespace EnterTheConsole
{
    internal class Program
    {
        public static Character player = new Character();
        public static ItemDatabase itemDB = new ItemDatabase();
        private static Utility ut = Utility.Instance;
        private static Status playerStat;
        private static Shop shop;

        static void Main(string[] args)
        {
            player.CreatePlayer();

            playerStat = new Status();
            shop = new Shop(player);

            MainMenu();
        }

        private static void MainMenu()
        {
            bool endGame = false;

            while (!endGame)
            {
                Console.Clear();
                Console.WriteLine("[마을]");
                Console.WriteLine();
                Console.WriteLine("마을에 오신것을 환영합니다.");
                Console.WriteLine("하실 행동을 선택해주세요");

                Console.WriteLine("1.상태 보기\n2.전투 시작\n3.장비 관리\n4.상점\n5.게임 종료");
                int input = ut.Selecter(Console.ReadLine(), 4);
                switch(input)
                {
                    case 1:
                        //스텟 보기
                        break;
                    case 2:
                        //스테이지 선택
                        break;
                    case 3:
                        //장비 관리
                        player.playerInven.ShowInventoryMenu();
                        break;
                    case 4:
                        //상점
                        shop.ShowShop();
                        break;
                    case 5:
                        endGame = true;
                        break;
                }
            }
        }
    }
}
