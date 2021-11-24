using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Fiction_Project
{
    class Program
    {
        static bool GameOver = true;
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

            StoryInit();
            ProgressPage();


            while (GameOver == true)
            {
                ConsoleKeyInfo readKeyInput = Console.ReadKey(true);

                if (TitlePage == true)
                {
                    if (readKeyInput.Key == ConsoleKey.D1)
                    {
                        CurrentPage = Int32.Parse(PageA);
                        TitlePage = false;
                        ProgressPage();
                    }
                    else if (readKeyInput.Key == ConsoleKey.D2)
                    {
                        GameOver = false;
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
                }

            }
        }

        // init story here
        static string[] story = new string[30];

        static void StoryInit()
        {
            story[0] = "A Soldier's Story/Start/Quit/1/2";

            story[1] = "You are a soldier in the army of King Mithrades. Today you are going to battle against the King's brother, who has invaded the kingdom with an army of barbarians! You go to the armory to pick your weapon for battle./Pick a sword and shield/Pick a spear/2/3";
            story[2] = "You grab a sword and shield and march towards your unit for the battle. As you arrive you report to your commander John and ready yourself for battle./Practice with your sword and shield/Talk to your fellow soldiers/5/7";
            story[3] = "You grab a spear and march towards your unit for the battle. As you arrive you report to your commander Robert and ready yourself for battle./Practice with your spear/Talk to your fellow soldiers/6/8";
        }

        static void ProgressPage()
        {
            Page = story[CurrentPage].Split('/');

            StoryWritten = Page[0];
            OptionA = Page[1];
            OptionB = Page[2];
            PageA = Page[3];
            PageB = Page[4];

            WriteStory();
        }

        static void WriteStory()
        {
            Console.WriteLine();
            Console.WriteLine(StoryWritten);
            Console.WriteLine();
            Console.WriteLine("To " + OptionA + " press 1");
            Console.WriteLine("To " + OptionB + " press 2");
        }


        
    }
}
