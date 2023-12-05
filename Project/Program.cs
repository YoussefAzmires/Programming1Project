﻿namespace Project
{

    using System.Threading;
    internal class Program
    {
        static ConsoleKey k = ConsoleKey.NoName;
        static int consolewindowheight = 30;
        static int consolewindowwidth = 120;
        static int distancefromwall = 2;
        static int MeX = 0;
        static int MeY = 0;
        static void Main(string[] args)
        {

            int userinput;
            do
            {

                Console.WriteLine("Main Menu\r\n1. Play 'the man inside the box' \r\n2. Instructions \r\n3 Exit");
                userinput = Validinput();
                switch (userinput)
                {
                    case 1:

                        //Shooting();
                        string player = Customization();
                        Console.Clear();
                        ConsoleKey k = 0;

                        //Intro();
                        Console.Clear();
                        Wall();
                        Cpu(ref k, ref MeX, ref MeY, player);


                        break;
                    case 2:
                        Instructions();
                        break;
                    case 4:
                        Console.WriteLine(" Thank you for playing! ");
                        break;


                }
            } while (Returntomenu());
        }
        static void Intro()
        {
            Thread.Sleep(1000);
            Console.Write("I...");
            Thread.Sleep(1000);
            string dialogue = "I'm tired.";
            foreach (char c in dialogue)
            {
                Console.Write(c);
                Thread.Sleep(50);
            }
            Thread.Sleep(1500);
            dialogue = " I have been overclocked for the past 2 months...";
            foreach (char c in dialogue)
            {
                Console.Write(c);
                Thread.Sleep(50);
            }
            Thread.Sleep(1000);
            dialogue = "I need to leave the CPU.";
            foreach (char c in dialogue)
            {
                Console.Write(c);
                Thread.Sleep(50);
            }
            Thread.Sleep(300);
            dialogue = " NOW";
            foreach (char c in dialogue)
            {
                Console.Write(c);
                Thread.Sleep(50);
            }
            static void Ram()
            {

            }
        }
        static void Instructions()
        {
            Console.WriteLine("Escape the Box: A CPU Odyssey\r\n\r\nWelcome to \"Escape the Box: A CPU Odyssey\"! Your journey begins inside the CPU, and your mission is to navigate through its components and escape the digital confines.\r\n\r\n - Use the arrow keys to navigate through the CPU.\r\n\r\n - Dodge obstacles representing CPU challenges.");
        }
        static int Validinput()
        {
            Int32 userinput = 0;
            bool goodvalue;
            do
            {
                goodvalue = Int32.TryParse(Console.ReadLine(), out userinput);
                if (!goodvalue)
                {
                    Console.WriteLine("Oops, please input a number");
                }

            } while (!goodvalue);
            return userinput;
        }
        static bool Returntomenu()
        {
            bool menu = false;
            Console.WriteLine("Press \"M\" to return to menu ");
            string userinput = Console.ReadLine();
            if (userinput == "m" || userinput == "M")
            {
                menu = true;
            }
            return menu;
        }
        static void Cpu(ref ConsoleKey k, ref int MeX, ref int MeY, string player)
        {
            int consolewindowheight = Console.WindowHeight;
            int consolewindowwidth = Console.WindowWidth;
            MeX = 60;
            MeY = 15;
            Console.SetCursorPosition(MeX, MeY);
            Console.Write(player);

            while (!Gameover())
            {
                while (k != ConsoleKey.Escape)
                {
                    Console.CursorVisible = false;

                    if (Console.KeyAvailable)
                    {
                        k = Console.ReadKey(true).Key;
                        Console.SetCursorPosition(MeX, MeY);
                        Console.Write(' ');

                        if (k == ConsoleKey.RightArrow)
                        {
                            Console.Write(' ');
                            MeX++;

                        }
                        if (k == ConsoleKey.LeftArrow)
                        {
                            MeX--;
                        }
                        if (k == ConsoleKey.UpArrow)
                        {
                            MeY--;
                        }
                        if (k == ConsoleKey.DownArrow)
                        {
                            MeY++;
                        }
                    }
                    if (MeX == Console.WindowWidth - distancefromwall)
                    {
                        MeX--;

                    }
                    else if (MeY == Console.WindowHeight - distancefromwall)
                    {
                        MeY--;
                    }
                    else if (MeX == distancefromwall)
                    {
                        MeX++;
                    }
                    else if (MeY == distancefromwall)
                    {
                        MeY++;
                    }
                    Console.SetCursorPosition(MeX, MeY);
                    Console.Write(player);

                }
            }


        }
        static void Getkey()
        {
            if (Console.KeyAvailable)
            {
                k = Console.ReadKey(true).Key;
            }
        }
        static string Customization()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("Choose your character");
            string[] Character = { "☺", "😔", "😥", "☹", "♠" };
            for (int i = 0; i < Character.Length; i++)
            {
                Console.WriteLine($"{i}. {Character[i]}");
            }
            int choice = Validinput();
            return (Character[choice]);
        }

        static bool Gameover()
        {

            return false;

        }
        static void Shooting()
        {
            int BulletY = consolewindowheight - distancefromwall;
            int BulletX = consolewindowwidth - distancefromwall;

            while (BulletX != 0)
            {
                Console.WriteLine("");
                Console.SetCursorPosition(BulletX, BulletY);
                Console.WriteLine("X");
                BulletX--;
                Thread.Sleep(1);
                Console.Clear();
            }
        }
        static void Wall()
        {
            int NewmeX = 0;
            int NewmeY = 0;


            for (int i = 0; i < consolewindowheight; i++)
            {
                Console.SetCursorPosition(NewmeX, i);
                Console.Write("█");
                Console.SetCursorPosition(119, i);
                Console.Write("█");
            }
            for (int i = 0; i < consolewindowwidth; i++)
            {
                Console.SetCursorPosition(i, NewmeY);
                Console.Write("█");
                Console.SetCursorPosition(i, 29);
                Console.Write("█");


            }


        }


    }
}







