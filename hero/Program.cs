using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;

namespace hero
{
    class Program
    {
        static void Main(string[] args)
        {
            List<LowRankKnight> LRKnights = new List<LowRankKnight>();
            List<Knight> Knights = new List<Knight>();

            
            //predefined knights
            Knight knight1 = new Knight("Ivan", 1,10,3,20);
            Knight knight2 = new Knight("Stojan", 2, 9, 4, 22);

            Knights.Add(knight1);
            Knights.Add(knight2);

            MainMenu(LRKnights, Knights);

            //Console.Clear();
        }
        static void MainMenu(List<LowRankKnight> LRKnights, List<Knight> Knights)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\r\n _   __ _   _ _____ _____  _   _ _____ _____ \r\n| | / /| \\ | |_   _|  __ \\| | | |_   _/  ___|\r\n| |/ / |  \\| | | | | |  \\/| |_| | | | \\ `--. \r\n|    \\ | . ` | | | | | __ |  _  | | |  `--. \\\r\n| |\\  \\| |\\  |_| |_| |_\\ \\| | | | | | /\\__/ /\r\n\\_| \\_/\\_| \\_/\\___/ \\____/\\_| |_/ \\_/ \\____/ \r\n                                             \r\n                                             \r\n");

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("1. Create low rank knight");
            Console.WriteLine("2. Create knight");
            Console.WriteLine("3. Battle");
            Console.WriteLine("4. Show LR knights");
            Console.WriteLine("5. Show knights");
            Console.WriteLine("6. Battle for knighthood");
            Console.WriteLine("7. Exit");

            int choise;

            bool isValidInput = int.TryParse(Console.ReadLine(), out choise);
            if (!isValidInput || choise < 1 || choise > 7)
            {             
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid command! Please enter a valid option (1-7).");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Wait!");

                Thread.Sleep(2000);

                MainMenu(LRKnights, Knights);
                return;
            }


            if (choise == 1) //1. Create low rank knight
            {
                PreCrateLRKnightMenu(LRKnights, Knights);
            }
            else if (choise == 2) //2. Create knight
            {
                PreCrateKnightMenu(LRKnights, Knights);
            }
            else if (choise == 3) //3. Battle
            {
                PreBattleMenu(LRKnights, Knights);
            }
            else if (choise == 4) //4. Show LR knights
            {
                PrintLRKnights(LRKnights, Knights);
            }
            else if (choise == 5) //5. Show knights
            {
                PrintKnights(LRKnights, Knights);
            }
            else if (choise == 6) //6. Battle for knighthood
            {
                SelectLRKnightForPromotingMenu(LRKnights, Knights);
            }
            else if (choise == 7) //7. Exit
            {
                
            }
        }
        static void Promote(LowRankKnight knight) //auto promote low rank knight
        {
            Knight newKnight;

            bool flag = false;

            for (int i = 0; i < 100; i++)
            {
                if (knight.wins != 3)
                {
                    Console.WriteLine($"Battle {i + 1}");
                    Console.WriteLine("----------");
                    knight.BattleForRank();
                }
                else
                {
                    knight.rank = 1;
                    break;
                }
            }

        }
        static void PreCrateLRKnightMenu(List<LowRankKnight> LRKnights, List<Knight> Knights)
        {
            Console.Clear();

            Console.WriteLine("1. Set parameters to LR knight");
            Console.WriteLine("2. Set random parameters to LR knight");

            int choise;

            bool isValidInput = int.TryParse(Console.ReadLine(), out choise);
            if (!isValidInput || choise < 1 || choise > 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid command! Please enter a valid option (1-2).");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Wait!");

                Thread.Sleep(2000);

                MainMenu(LRKnights, Knights);
                return;
            }

            if (choise == 1)
            {
                CrateLRKnightMenu(LRKnights, Knights);
            }
            else if (choise == 2)
            {
                CrateRandomLRKnightMenu(LRKnights, Knights);
            }
        }
        static void CrateLRKnightMenu(List<LowRankKnight> LRKnights, List<Knight> Knights)
        {
            Console.Clear();

            LowRankKnight tempKnight = new LowRankKnight();

            tempKnight.GetValues();

            LRKnights.Add(tempKnight);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("New LR knight is created!");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Returning to main menu...");
            Thread.Sleep(2000);

            Console.ForegroundColor = ConsoleColor.White;

            MainMenu(LRKnights, Knights);
        }
        static void CrateRandomLRKnightMenu(List<LowRankKnight> LRKnights, List<Knight> Knights)
        {
            Console.Clear();

            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter id: ");
            int id = int.Parse(Console.ReadLine());

            LowRankKnight tempKnight = new LowRankKnight(name, id);

            LRKnights.Add(tempKnight);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("New LR knight is created!");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Returning to main menu...");
            Thread.Sleep(2000);

            Console.ForegroundColor = ConsoleColor.White;

            MainMenu(LRKnights, Knights);
        }
        static void PreCrateKnightMenu(List<LowRankKnight> LRKnights, List<Knight> Knights)
        {
            Console.Clear();

            Console.WriteLine("1. Set parameters to knight");
            Console.WriteLine("2. Set random parameters to knight");

            int choise;

            bool isValidInput = int.TryParse(Console.ReadLine(), out choise);
            if (!isValidInput || choise < 1 || choise > 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid command! Please enter a valid option (1-2).");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Wait!");

                Thread.Sleep(2000);

                MainMenu(LRKnights, Knights);
                return;
            }

            if (choise == 1)
            {
                CrateKnightMenu(LRKnights, Knights);
            }
            else if (choise == 2)
            {
                CrateRandomKnightMenu(LRKnights, Knights);
            }
        }
        static void CrateKnightMenu(List<LowRankKnight> LRKnights, List<Knight> Knights)
        {
            Console.Clear();

            Knight tempKnight = new Knight();

            tempKnight.GetValues();

            Knights.Add(tempKnight);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("New knight is created!");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Returning to main menu...");
            Thread.Sleep(2000);

            Console.ForegroundColor = ConsoleColor.White;

            MainMenu(LRKnights, Knights);
        }
        static void PreBattleMenu(List<LowRankKnight> LRKnights, List<Knight> Knights)
        {
            Console.Clear();

            Console.WriteLine("1.Battle between LR knights");
            Console.WriteLine("2.Battle between knights");

            int choise;

            bool isValidInput = int.TryParse(Console.ReadLine(), out choise);
            if (!isValidInput || choise < 1 || choise > 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid command! Please enter a valid option (1-2).");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Wait!");

                Thread.Sleep(2000);

                MainMenu(LRKnights, Knights);
                return;
            }

            if (choise == 1)
            {
                BattleBetweenLRKnightsMenu(LRKnights, Knights);
            }
            else if (choise == 2)
            {
                BattleBetweenKnightsMenu(LRKnights, Knights);
            }
        }
        static void BattleBetweenLRKnightsMenu(List<LowRankKnight> LRKnights, List<Knight> Knights)
        {
            Console.Clear();

            Console.Write("Enter id of the FIRST LR knight: ");

            int searchedId1;

            bool isValidInput = int.TryParse(Console.ReadLine(), out searchedId1);
            if (!isValidInput || searchedId1 < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid command! Please enter a valid id (id => 1).");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Wait!");

                Thread.Sleep(2000);

                MainMenu(LRKnights, Knights);
                return;
            }

            Console.Write("Enter id of the SECOND LR knight: ");

            int searchedId2;

            isValidInput = int.TryParse(Console.ReadLine(), out searchedId2);
            if (!isValidInput || searchedId2 < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid command! Please enter a valid id (id => 1).");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Wait!");

                Thread.Sleep(2000);

                MainMenu(LRKnights, Knights);
                return;
            }

            int firstLRKnightIndex = 0;
            int secondLRKnightIndex = 0;

            bool flag = false;

            //search for first knight
            for (int i = 0; i < LRKnights.Count; i++)
            {
                if (LRKnights[i].id == searchedId1)
                {
                    firstLRKnightIndex = i;
                    flag = true;
                    break;
                }
                else
                {
                    flag = false;
                }

            }

            //search for second knight
            for (int i = 0; i < LRKnights.Count; i++)
            {
                if (LRKnights[i].id == searchedId2)
                {
                    secondLRKnightIndex = i;
                    flag = true;
                    break;
                }
                else
                {
                    flag = false;
                }

            }

            if (flag)
            {
                Console.Clear();

                LRKnights[firstLRKnightIndex].LRKnightBattle(LRKnights[secondLRKnightIndex]);

                Console.WriteLine();
                Console.Write("Press any key...");
                Console.ReadKey();
                MainMenu(LRKnights, Knights);
            }
            else
            {
                Console.WriteLine("error");
            }


        }
        static void BattleBetweenKnightsMenu(List<LowRankKnight> LRKnights, List<Knight> Knights)
        {
            Console.Clear();

            Console.Write("Enter id of the FIRST knight: ");

            int searchedId1;

            bool isValidInput = int.TryParse(Console.ReadLine(), out searchedId1);
            if (!isValidInput || searchedId1 < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid command! Please enter a valid id (id => 1).");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Wait!");

                Thread.Sleep(2000);

                MainMenu(LRKnights, Knights);
                return;
            }

            Console.Write("Enter id of the SECOND knight: ");

            int searchedId2;

            isValidInput = int.TryParse(Console.ReadLine(), out searchedId2);
            if (!isValidInput || searchedId2 < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid command! Please enter a valid id (id => 1).");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Wait!");

                Thread.Sleep(2000);

                MainMenu(LRKnights, Knights);
                return;
            }

            int firstKnightIndex = 0;
            int secondKnightIndex = 0;

            bool flag = false;

            //search for first knight
            for (int i = 0; i < Knights.Count; i++)
            {
                if (Knights[i].id == searchedId1)
                {
                    firstKnightIndex = i;
                    flag = true;
                    break;
                }
                else
                {
                    flag = false;
                }

            }

            //search for second knight
            for (int i = 0; i < Knights.Count; i++)
            {
                if (Knights[i].id == searchedId2)
                {
                    secondKnightIndex = i;
                    flag = true;
                    break;
                }
                else
                {
                    flag = false;
                }

            }

            if (flag)
            {
                Console.Clear();

                Knights[firstKnightIndex].KnightBattle(Knights[secondKnightIndex]);

                Console.WriteLine();
                Console.Write("Press any key...");
                Console.ReadKey();
                MainMenu(LRKnights, Knights);
            }
            else
            {
                Console.WriteLine("error");
            }
        }
        static void CrateRandomKnightMenu(List<LowRankKnight> LRKnights, List<Knight> Knights)
        {
            Console.Clear();

            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter id: ");
            int id = int.Parse(Console.ReadLine());

            Knight tempKnight = new Knight(name, id);

            Knights.Add(tempKnight);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("New LR knight is created!");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Returning to main menu...");
            Thread.Sleep(2000);

            Console.ForegroundColor = ConsoleColor.White;

            MainMenu(LRKnights, Knights);
        }
        static void PrintLRKnights(List<LowRankKnight> LRKnights, List<Knight> Knights)
        {
            Console.Clear();
            if (LRKnights.Count == 0)
            {
                Console.WriteLine("Empty");
            }
            else
            {
                for (int i = 0; i < LRKnights.Count; i++)
                {
                    Console.WriteLine();

                    Console.WriteLine($"LR Knight {i + 1}");
                    Console.WriteLine("----------");

                    LRKnights[i].Show();
                }
            }


            Console.WriteLine();
            Console.Write("Press any key...");
            Console.ReadKey();
            MainMenu(LRKnights, Knights);

        }
        static void PrintKnights(List<LowRankKnight> LRKnights, List<Knight> Knights)
        {
            Console.Clear();

            if (Knights.Count == 0)
            {
                Console.WriteLine("Empty");
            }
            else
            {
                for (int i = 0; i < Knights.Count; i++)
                {
                    Console.WriteLine();

                    Console.WriteLine($"Knight {i + 1}");
                    Console.WriteLine("----------");

                    Knights[i].Show();
                }
            }


            Console.WriteLine();
            Console.Write("Press any key...");
            Console.ReadKey();
            MainMenu(LRKnights, Knights);

        }
        static void SelectLRKnightForPromotingMenu(List<LowRankKnight> LRKnights, List<Knight> Knights)
        {
            Console.Clear();

            Console.Write("Enter id of the LR knight: ");
            int searchedId;

            bool isValidInput = int.TryParse(Console.ReadLine(), out searchedId);
            if (!isValidInput || searchedId < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid command! Please enter a valid id (id => 1).");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Wait!");

                Thread.Sleep(2000);

                MainMenu(LRKnights, Knights);
                return;
            }

            int id = 0;

            int index = -1;

            for (int i = 0; i < LRKnights.Count; i++)
            {
                if (LRKnights[i].id == searchedId)
                {
                    id = 1;
                    index = i;
                    break;
                }
                
            }

            if (id != 0)
            {
                PromoteLRKnight(LRKnights[index], LRKnights, Knights);

                Console.WriteLine();
                Console.Write("Press any key...");
                Console.ReadKey();
                MainMenu(LRKnights, Knights);
            }
            else
            {
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no LR knight with this id!");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Returning to main menu...");
                Thread.Sleep(2000);

                Console.ForegroundColor = ConsoleColor.White;

                MainMenu(LRKnights, Knights);

                MainMenu(LRKnights, Knights);
            }

        }
        static void PromoteLRKnight(LowRankKnight LRKnight, List<LowRankKnight> LRKnights, List<Knight> Knights)
        {
            Console.Clear();

            Promote(LRKnight); //make rank = 1;

            if (LRKnight.rank == 1)
            {
                Knight newKnight = new Knight(LRKnight.name, LRKnight.id, LRKnight.Attack, LRKnight.Shield, LRKnight.Health);

                LRKnights.Remove(LRKnight);

                Knights.Add(newKnight);
            }
        }
        
        

    }
}
