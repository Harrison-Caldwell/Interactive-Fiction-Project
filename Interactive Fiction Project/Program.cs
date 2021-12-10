using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Fiction_Project
{
    class Program
    {
        static string[] Story;
        static bool GameOver = false;
        static bool TitlePage = true;
        static string[] Page;
        static int CurrentPage = 0;
        static string StoryWritten;
        static string OptionA;
        static string OptionB;
        static string PageA = "0";
        static string PageB;

        //int CurrentPage = Int32.Parse(Page);

        static void Main(string[] args)
        {

            Story = System.IO.File.ReadAllLines(@"Story.txt");
            ProgressPage();
            
            


            while (GameOver == false) // game loop
            {
                ConsoleKeyInfo readKeyInput = Console.ReadKey(true);
                

                if (TitlePage == true) //enables quitting the game from title page
                {
                    
                    if (readKeyInput.Key == ConsoleKey.D1)
                    {
                        CurrentPage = Int32.Parse(PageA);
                        TitlePage = false;
                        ProgressPage();
                    }
                    else if (readKeyInput.Key == ConsoleKey.D2)
                    {
                        GameOver = true;
                    }
                    else if (readKeyInput.Key == ConsoleKey.D3)
                    {
                        
                        
                            System.IO.File.ReadAllText(@"SaveFile.txt");
                        ProgressPage();
                            
                            TitlePage = false;
                        
                    }
                }
                else if (TitlePage == false)
                {
                    if (readKeyInput.Key == ConsoleKey.D1)
                    {
                        CurrentPage = Int32.Parse(PageA);
                        ProgressPage();
                    }
                    else if (readKeyInput.Key == ConsoleKey.D2)
                    {
                        CurrentPage = Int32.Parse(PageB);
                        ProgressPage();
                    }
                    else if (readKeyInput.Key == ConsoleKey.Escape)
                    {
                        Environment.Exit(0);
                    }
                }

                if (GameOver == true)
                {
                    Environment.Exit(0);
                }

            }
        }

            
            void Death()
            {
                if (Story[CurrentPage].Contains("Fin"))
                {
                    GameOver = true;
                Environment.Exit(0);
                }
            }


        static void ProgressPage() //splits the story line into page array
        {
            Page = Story[CurrentPage].Split('/');

            StoryWritten = Page[0];
            OptionA = Page[1];
            OptionB = Page[2];
            PageA = Page[3];
            PageB = Page[4];

            WriteStory();
            
        }

        static void SaveGame()
        {
            ConsoleKeyInfo readKeyInput = Console.ReadKey(true);
            if (readKeyInput.Key == ConsoleKey.D4)
            {
                System.IO.File.WriteAllText(@"SaveFile.txt", Story[CurrentPage]);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Game Saved");
                Console.ResetColor();
                
            }
        }

        static void WriteStory() //writes the story on the page
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(StoryWritten);
            Console.WriteLine();
            Console.WriteLine("To " + OptionA + " Press 1");
            Console.WriteLine("To " + OptionB + " Press 2");
            if (TitlePage == true)
            {
                Console.WriteLine("To Load Game Press 3");
            }
            else if (TitlePage == false)
            {
                Console.WriteLine("To Quit Game Without Saving Press Escape");
                Console.WriteLine("To Save Game Press 4");
                
            }
            SaveGame();
        }

        static void WriteTitlePage()
        {
            Console.WriteLine("To Load Save Press 3");
        }



        
    }
}
