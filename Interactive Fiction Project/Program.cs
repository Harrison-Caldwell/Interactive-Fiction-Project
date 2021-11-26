using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Fiction_Project
{
    class Program
    {
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

            StoryInit();
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
        static string[] story = new string[40];

        static void StoryInit() //the story itself
        {
            story[0] = "A Soldier's Story/Start/Quit/1/2";

            story[1] = "You are a soldier in the army of King Mithrades. Today you are going to battle against the King's brother, who has invaded the kingdom with an army of barbarians! You go to the armory to pick your weapon for battle./Pick a sword and shield/Pick a spear/2/3";
            story[2] = "You grab a sword and shield and march towards your unit for the battle. As you arrive you report to your commander John and ready yourself for battle./Practice with your sword and shield/Talk to your fellow soldiers/5/7";
            story[3] = "You grab a spear and march towards your unit for the battle. As you arrive you report to your commander Robert and ready yourself for battle./Practice with your spear/Talk to your fellow soldiers/4/6";
            story[4] = "You practice with your spear for about an hour, until you hear a horn sound, signalling the battle is about to start./Take a position in the front rank/Take a position in the rear of the army/8/10";
            story[5] = "You practice with your sword and shield for about an hour, until you hear a horn sound, which signals the battle is about to start.Take a position in the front rank/Take a position in the rear/9/11";
            story[6] = "You chat with your fellow soldiers about the coming battle, until you hear a horn, signalling the battle will start soon/Take a position with your new friends in the unit/Keep to yourself/12/14";
            story[7] = "You talk with your fellow swordsmen about the coming battle, until you hear a horn signalling the battle is soon to start/Take a position with your new friends in the unit/Keep to yourself/13/15";
            story[8] = "As you take a position at the front of the army, you see the barbarians charging and you ready your spear./Brace yourself for the charge/Charge at the barbarians/16/18";
            story[9] = "As you take up your position at the front of the army, you see the barbarians charging towards you./Raise your shield and brace for the charge/Counter charge the barbarians/17/19";
            story[10] = "As you take up a position at the rear of the army you can hear the roar of the barbarians as they charge but cannot see them./try and move forwards to the front/stay where you are and wait/20/22";
            story[11] = "As you arrive at the rear of the army you can hear the roar of the barbarians as they charge but cannot see them./try and move towards the frontlines/stay where you are/21/23";
            story[12] = "As your new friends surround you, you all ready your spears and watch the barbarians charge towards you./Shout to your comrades to 'hold the line'/Yell 'Charge' and run forwards with your comrades/24/26";
            story[13] = "Your form up with your new comrades and raise your sword and shields as the barbarians charge towards you./Tell your comrades to 'Hold the line'/Yell 'Charge' and run forwards with your comrades towards the barbarians/25/27";
            story[14] = "You take up your position in the unit and ready your spear as the barbarians charge. You hear another yell near you and see the soldiers you were talking with charge towards the barbarians./Follow them/Hold your position/28/30";
            story[15] = "You take up your position and ready your sword and shield as the barbarians charge. You hear a yell near you and see the soldiers you were talking with charge the barbarians./Follow them/Hold your position/29/31";
            story[16] = "The barbarians charge hits and you are thrown backwards. As you try and regain your feet a barbarian comes screaming towards you swinging an axe. You see the swing coming but cannot raise your spear in time to block it./You Have Died, Return to Main Menu/You have Died, Exit Game/0/31";

            story[31] = "Fin";
            
            void Death()
            {
                if (story[CurrentPage].Contains("Fin"))
                {
                    GameOver = true;
                }
            }


        }

        static void ProgressPage() //splits the story line into page array
        {
            Page = story[CurrentPage].Split('/');

            StoryWritten = Page[0];
            OptionA = Page[1];
            OptionB = Page[2];
            PageA = Page[3];
            PageB = Page[4];

            WriteStory();
        }

        static void WriteStory() //writes the story on the page
        {
            Console.WriteLine();
            Console.WriteLine(StoryWritten);
            Console.WriteLine();
            Console.WriteLine("To " + OptionA + " press 1");
            Console.WriteLine("To " + OptionB + " press 2");
        }



        
    }
}
