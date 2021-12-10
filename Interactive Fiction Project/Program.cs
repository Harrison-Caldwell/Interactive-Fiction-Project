using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Fiction_Project
{
    class Program
    {
        static string[] story;
        static bool gameOver = false;
        static bool titlePage = true;
        static string[] page;
        static int currentPage;
        static string storyWritten;
        static string optionA;
        static string optionB;
        static string pageA = "0";
        static string pageB;
        static string save;
        static string saveFile;

        //int CurrentPage = Int32.Parse(Page);

        static void Main(string[] args)
        {

            story = System.IO.File.ReadAllLines(@"Story.txt");
            ProgressPage();
            
            
            


            while (gameOver == false) // game loop
            {
                ConsoleKeyInfo readKeyInput = Console.ReadKey(true);
                

                if (titlePage == true) //enables quitting the game from title page
                {
                    
                    if (readKeyInput.Key == ConsoleKey.D1)
                    {
                        currentPage = Int32.Parse(pageA);
                        titlePage = false;
                        ProgressPage();
                    }
                    else if (readKeyInput.Key == ConsoleKey.D2)
                    {
                        gameOver = true;
                    }
                    else if (readKeyInput.Key == ConsoleKey.D3) // Load Save File
                    {

                        currentPage = Int32.Parse(saveFile);
                        saveFile = System.IO.File.ReadAllText(@"SaveFile.txt");
                        ProgressPage();    
                        titlePage = false;
                        
                    }
                }
                else if (titlePage == false)
                {
                    if (readKeyInput.Key == ConsoleKey.D1)
                    {
                        currentPage = Int32.Parse(pageA);
                        ProgressPage();
                    }
                    else if (readKeyInput.Key == ConsoleKey.D2)
                    {
                        currentPage = Int32.Parse(pageB);
                        ProgressPage();
                    }
                    else if (readKeyInput.Key == ConsoleKey.Escape)
                    {
                        Environment.Exit(0);
                    }
                }

                if (gameOver == true)
                {
                    Environment.Exit(0);
                }

            }
        }

            
            void Death()
            {
                if (story[currentPage].Contains("Fin"))
                {
                    gameOver = true;
                Environment.Exit(0);
                }
            }

        static void PageLengthCheck()
        {
            if (page.Length >= 4)
            {
                Console.WriteLine("Error Detected with Page Length, Application Will Now Exit");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        static void FindBlanks()
        {
            

        }


        static void ProgressPage() //splits the story line into page array
        {
            page = story[currentPage].Split('/');

            storyWritten = page[0];
            optionA = page[1];
            optionB = page[2];
            pageA = page[3];
            pageB = page[4];

            WriteStory();
            
        }

        static void SaveGame()
        {
            
            ConsoleKeyInfo readKeyInput = Console.ReadKey(true);
            if (readKeyInput.Key == ConsoleKey.D4)
            {
                save = currentPage.ToString();
                System.IO.File.WriteAllText(@"SaveFile.txt", save);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Game Saved");
                Console.ResetColor();
                
            }
        }

        static void WriteStory() //writes the story on the page
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(storyWritten);
            Console.WriteLine();
            Console.WriteLine("To " + optionA + " Press 1");
            Console.WriteLine("To " + optionB + " Press 2");
            if (titlePage == true)
            {
                Console.WriteLine("To Load Game Press 3");
            }
            else if (titlePage == false)
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
