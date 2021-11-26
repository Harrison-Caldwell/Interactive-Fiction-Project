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
        static string[] story = new string[45];

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
            story[16] = "The barbarians charge hits and you are thrown backwards. As you try and regain your feet a barbarian comes screaming towards you swinging a mace. You see the swing coming but cannot raise your spear in time to block it!/You Have Died, Return to Main Menu/You have Died, Exit Game/0/44";
            story[17] = "You are knocked flat as the barbarians charge hits you. You struggle to your feet and block a few swings from the barbarian infront of you before another barbarian attacks from the side and you are quickly cut down!/You Have Died, Return to Main Menu/You Have Died, Exit Game/0/44";
            story[18] = "You charge towards the oncoming barbarians and spear the first one with your spear. You see another barbarian approaching you with a large two handed axe./Try to block their first swing/Use your spear to stab at them/32/34";
            story[19] = "You charge towards the oncoming barbarians and manage to parry the first attack before you stab the attacking barbarian. Another barbarian charges towards you with an axe in each hand./Raise your shield and block their attacks/Attack first by swinging your sword at the barbarian/33/35";
            story[20] = "You push towards the frontlines, shoving other soldiers out of the way. The sounds of clashing metal and screams get louder as you approach. You finally reach the front and see that the barbarian army has already been put to flight. The battle is won!/You Have Survived, Return to Main Menu/You Have Survived, Quit Game/0/44";
            story[21] = "As you push through other soldiers towards the frontlines, you can hear the sounds of metal clashing and screaming from ahead. The closer you get, the more you notice the sound is dying down to be replaced by cheering. You reach the front and find the barbarian army fleeing. The battle is won!/You Have Survived, Return to Main Menu/You Have Survived, Quit Game/0/44";
            story[22] = "As you stand at the rear of the army, you notice the distant sound of clashing metal and screams are getting closer. You start to see wounded soldiers running past and then you see them. The barbarians have broken the frontlines and are charging towards you. You try to defend youself with your spear however you are alone against many and are quickly cut down!/You Have Died, Return to Main Menu/You Have Died, Quit Game/0/44";
            story[23] = "While standing at the rear of the army, you notice the sound of clashing metal and screams seems to be getting louder. You see fellow soldiers fleeing past you, and finally see the barbarian army approaching. You manage to block some blows with your shield, but are quickly cut down by the oncoming tide!/You Have Died, Return to Main Menu/You Have Died, Quit Game/0/44";
            story[24] = "The barbaian charge hits your line of spear and you and your comrades are able to stop the charge. You see a swing from a barbarian with mace, but the soldier next to you blocks the blow and you strike the barbarian down. Your spearwall is able to continue to hold off the barbarians who soon realise they cannot break it and begin to retreat. The battle is won!/You Have Survived, Return to Menu/You Have Survived, Quit Game/0/44";
            story[25] = "The barbarians are stopped cold by your shield wall. Your see a barbarian swing his axes at you, but the blow is blocked by the soldier next to you and you cut the barbarian down. The barbarians quickly realize they cannot break your shield wall and begin to flee. The battle is won!/You Have Survived, Return to Menu/You Have Survived, Quit Game/0/44";
            story[26] = "You all level your spears and counter charge the oncoming barbarians. The charge slams into the barbarians and throws them back. You continue to push deeper into the enemy army with your squad until you spot a man on a horse who looks to be commanding the barbarians. It is the King's evil brother!/Charge him along with your unit/Hold your ground/36/38";
            story[27] = "You raise your shields and charge with your unit. The charge slams into the oncoming barbarians and knocks them aside. You continue to cut your way through the barbarians until you see a man on a horse who looks to be giving orders. It is the King's evil brother!/Charge him with your unit/Hold your ground/37/39";
            story[28] = "You follow the group of soldiers as they charge into the barbarian army. They are knocked back by the barbarian charge and quickly slain. You are left alone against the oncoming horde and are quickly cut down!/You Have Died, Return to Main Menu/You Have Died, Quit Game/0/44";
            story[29] = "You follow the group of soldiers as they charge into the barbarian army. They are knocked back by the barbarian charge and quickly slain. You are left alone against the oncoming horde and are quickly cut down!/You Have Died, Return to Main Menu/You Have Died, Quit Game/0/44";
            story[30] = "You stay braced as you watch the group of soldiers charge into the oncoming army. They are quickly slain by the horde. The charge continues on towards you and the rest of the army, but is stopped by the rest of the frontline. You are knocked unconscious but manage to survive the battle!/You Have Survived, Return to Main Menu/You Have Survived, Quit Game/0/44";
            story[31] = "You stay braced as you watch the group of soldiers charge into the oncoming army. They are quickly slain by the horde. The charge continues on towards you and the rest of the army, but is stopped by the rest of the frontline. You are knocked unconscious but manage to survive the battle!/You Have Survived, Return to Main Menu/You Have Survived, Quit Game/0/44";
            story[32] = "You try to block however the blow breaks your spear in half. The barbarian quickly follows with a second attack which kills you!/You Have Died, Return to Main Menu/You Have Died, Quit Game/0/44";
            story[33] = "You block the first few blows however your shield is quickly reduced to splinters and you are cut down shortly after!/You Have Died, Return to Main Menu/You Have Died, Quit Game/0/44";
            story[34] = "Your thrust hits the barbarian and they fall before you. You are able to defend yourself and slay more barbarians until you see them start to flee. The battle is won!/You Have Survived, Return to Main Menu/You Have Survived, Quit Game/0/44";
            story[35] = "Your swing strikes the barbarian down"


            story[44] = "Fin";
            
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
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(StoryWritten);
            Console.WriteLine();
            Console.WriteLine("To " + OptionA + " press 1");
            Console.WriteLine("To " + OptionB + " press 2");
        }



        
    }
}
