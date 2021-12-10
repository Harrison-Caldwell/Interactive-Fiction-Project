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
            FileCheck();
            story = System.IO.File.ReadAllLines(@"Story.txt");
            DisplayStory();           


            while (gameOver == false) // game loop
            {
                GameOverCheck();
                PageLengthCheck();
                CheckForBlanks();
                
                ConsoleKeyInfo readKeyInput = Console.ReadKey(true);
                

                if (titlePage == true) //enables quitting the game from title page
                {
                    
                    if (readKeyInput.Key == ConsoleKey.D1) // begin gameplay from main menu
                    {
                        currentPage = Int32.Parse(pageA);
                        OutOfRange();
                        titlePage = false;
                        DisplayStory();
                    }
                    else if (readKeyInput.Key == ConsoleKey.D2) // exit from main menu
                    {
                        gameOver = true;
                    }
                    else if (readKeyInput.Key == ConsoleKey.D3) // Load Save File
                    {
                        SaveCheck();
                        saveFile = System.IO.File.ReadAllText(@"SaveFile.txt");
                        currentPage = Int32.Parse(saveFile);
                        OutOfRange();
                        titlePage = false;
                        DisplayStory();    
                        titlePage = false;
                        
                    }
                }
                else if (titlePage == false) // takes player input to select next page
                {
                    if (readKeyInput.Key == ConsoleKey.D1)
                    {
                        currentPage = Int32.Parse(pageA);
                        OutOfRange();
                        DisplayStory();
                        
                    }
                    else if (readKeyInput.Key == ConsoleKey.D2)// takes player input to select next page
                    {
                        currentPage = Int32.Parse(pageB);
                        OutOfRange();
                        DisplayStory();
                        
                    }
                    else if (readKeyInput.Key == ConsoleKey.Escape) // allows player to quit at any point
                    {
                        Environment.Exit(0);
                    }
                    SaveGame();
                    GameOverCheck();
                    
                }
                
                                
                if (gameOver == true) // checks for game over
                {
                    Environment.Exit(0);
                }

            }
        }

            
           static void GameOverCheck() // checks for game over
            {
                if (story[currentPage].Contains("Fin"))
                {
                    
                Environment.Exit(0);
                }
            }

        static void PageLengthCheck() // error checks the length of the current page
        {
            if (page.Length > 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error Detected with Page Length, Application Will Now Exit");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else if (page.Length < 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error Detected with Page Length, Application Will Now Exit");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        static void CheckForBlanks()//checks for any blanks in the file
        {
            for (int i = 0; i < 40; i++)
            {
                if (string.IsNullOrEmpty(story[i]))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("MISSING LINE DETECTED. APPLICATION WILL EXIT");
                    Console.ResetColor();
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
        }

        static void FileCheck() // checks that story file exists
        {
            if (System.IO.File.Exists(@"Story.txt"))
            {
                
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("MISSING STORY INPUT. APPLICATION WILL NOW EXIT");
                Console.ResetColor();
                Console.ReadKey();
                Environment.Exit(0);
            }            
        }

        static void OutOfRange()//checks that requested page is inside array bounds
        {
            if (currentPage > 40)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("PAGE NUMBER EXCEEDS MAXIMUM. APPLICATION WILL NOW EXIT");
                Console.ResetColor();
                Console.ReadKey();
                Environment.Exit(0);
            }
        }


        static void SplitPage() //splits the story line into page array
        {
            page = story[currentPage].Split('/');

            storyWritten = page[0];
            optionA = page[1];
            optionB = page[2];
            pageA = page[3];
            pageB = page[4];
            



        }
        static void SaveCheck()//checks that a save file exists
        {
            if (System.IO.File.Exists(@"SaveFile.txt"))
            {

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NO SAVE DETECTED. APPLICATION WILL NOW EXIT");
                Console.ResetColor();
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        static void SaveGame() // saves the current page number to a file as a string
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

        static void DisplayStory() //writes the story on the page
        {
            
            SplitPage();
            

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
            
            
            
        }


        



        
    }
}
