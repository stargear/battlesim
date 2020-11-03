using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Media;

namespace battleSIM
{
    class manager
    {
        public static manager instance = new manager();
        public static List<creature> creatures = new List<creature>();
        public int yPositionBattleCursor = 12;
        public int turncounter = 1;
        public SoundPlayer musicPlayer = new SoundPlayer();

        public manager()
        {
            if (instance == null)
                instance = this;


        }


        public bool turns = false; //false is player 1s turn, true is player 2s turn!


        public void StartBattle()
        {
            bool IsAnyDied = false;
            Console.WriteLine(" ");
            Console.WriteLine("the battle starts");
            turns = false;
            Thread.Sleep(1400);
            Console.CursorVisible = false;

            Console.Clear();
            musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/00_beginn_game.wav";
            musicPlayer.Play();



            while (!IsAnyDied)
            {


                

                //here write the battle actions
                //**************************************************************************************************************


                //xpos = 0; xpos = 15; ypos = 10;
                Console.SetCursorPosition(0, yPositionBattleCursor);
                Thread.Sleep(100);
                //Console.Clear();
                Interface();
                creatures[0].mp++;

                // first comes player 1s character!
                if (turns == false)
                {
                    
                    Interface();
                    yPositionBattleCursor = 12;
                    Console.SetCursorPosition(0, yPositionBattleCursor);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("turn"+ turncounter + ": player 1");
                    Console.ForegroundColor = ConsoleColor.White;


                    ConsoleKey key = Console.ReadKey().Key;
                    //ypos++;
                    switch (key)
                    {
                        //use the weapon to attack
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:

                            creatures[0].Attack(creatures[1]);
                            
                            Thread.Sleep(200);

                            turns = true;
                            break;

                        //use the class skill to attack
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:

                            creatures[0].classSkill(creatures[1]);

                            Thread.Sleep(200);

                            turns = true;
                            break;
                        //use the trait skill to attack
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:

                            creatures[0].Skill(creatures[1]);

                            Thread.Sleep(200);

                            turns = true;
                            break;
                    }
                    // creatures[0].Attack(creatures[1]);
                    if (creatures[1].IsDied)
                    {
                        IsAnyDied = true;
                        break;
                    }
                    manager.instance.yPositionBattleCursor++;
                    turncounter++;
                    //Console.WriteLine(" ");
                }


                // then comes player 2s character

                else if (turns == true)
                {
                    creatures[1].mp++;
                    Interface();
                    yPositionBattleCursor = 12;
                    Console.SetCursorPosition(0, yPositionBattleCursor);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("turn"+ turncounter + ": player 2");
                    Console.ForegroundColor = ConsoleColor.White;

                    yPositionBattleCursor = 20;
                    Console.SetCursorPosition(0, yPositionBattleCursor);

                    ConsoleKey key = Console.ReadKey().Key;

                    switch (key)
                    {
                        //use the weapon to attack
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:

                            creatures[1].Attack(creatures[0]);
                            
                            Thread.Sleep(200);

                            turns = false;
                            break;

                        //use the class skill to attack
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:

                            creatures[1].classSkill(creatures[0]);
                            
                            Thread.Sleep(200);

                            turns = false;
                            break;
                        //use the trait skill to attack
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:

                            creatures[1].Skill(creatures[0]);

                            Thread.Sleep(200);

                            turns = false;
                            break;
                    }

                        manager.instance.yPositionBattleCursor++;
                    turncounter++;

                    if (creatures[0].IsDied)
                    {
                        IsAnyDied = true;
                        break;
                    }
                   // Console.WriteLine(" ");
                }


            }
            Console.Read();
        }


        public void CreateCreature()
        {

            musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/01_character_creation.wav";
            musicPlayer.Play();
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("       BATTLE                                                                                                  ");
            Console.WriteLine("                                                                                                         ");
            Console.WriteLine("        █████       █        ███████████████                                                              ");
            Console.WriteLine("       █     █      █        █      █      █                                                              ");
            Console.WriteLine("       █            █        █      █      █                                                               ");
            Console.WriteLine("        ████        █        █      █      █                                                               ");
            Console.WriteLine("            █       █        █      █      █                                                               ");
            Console.WriteLine("      █     █       █        █      █      █                                                               ");
            Console.WriteLine("       █████        █        █      █      █                                                               ");
            Console.WriteLine("                                                                                                         ");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("                                                                                                         ");
            Console.WriteLine("      PRESS ANY KEY                                                                                                                   ");
            Console.WriteLine("                                                                                                         ");


            Console.ReadKey();
            Console.Clear();
            musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/menu_click.wav";
            musicPlayer.Play();


            Console.ForegroundColor = ConsoleColor.White;
            bool IsCreating = true;

            while (IsCreating)
            {



                if (turns == false)
                {

                    //Console.WriteLine("input name of your creature, player 1");
                    //string name = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("HELLO PLAYER 1!");
                    Console.WriteLine("                   ");
                    Console.WriteLine("select the race of your creature");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("┌────────────────────────┐");
                    Console.WriteLine("│human [1]               │");
                    Console.WriteLine("└────────────────────────┘");
                    Console.WriteLine("                   ");
                    Console.WriteLine("┌────────────────────────┐");
                    Console.WriteLine("│nightelf [2]            │");
                    Console.WriteLine("└────────────────────────┘");
                    Console.WriteLine("                   ");
                    Console.WriteLine("┌────────────────────────┐");
                    Console.WriteLine("│troll [3]               │");
                    Console.WriteLine("└────────────────────────┘");
                    Console.WriteLine("                   ");
                    Console.WriteLine("┌────────────────────────┐");
                    Console.WriteLine("│ghost [4]               │");
                    Console.WriteLine("└────────────────────────┘");
                    Console.WriteLine("                   ");
                    Console.WriteLine("┌────────────────────────┐");
                    Console.WriteLine("│goblin [5]              │");
                    Console.WriteLine("└────────────────────────┘");
                    Console.WriteLine("                   ");


                    ConsoleKey key = Console.ReadKey().Key;
                    Console.WriteLine(" ");
                    yPositionBattleCursor++;
                    switch (key)
                    {
                        case ConsoleKey.D5:
                        case ConsoleKey.NumPad5:

                            float health = 20;
                            float attackDamage = 3;
                            musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/menu_click.wav";
                            musicPlayer.Play();
                            Console.WriteLine("INPUT THE NAME OF YOUR GOBLIN");
                            string myName = Console.ReadLine();

                            creature Goblin = new goblin(health, attackDamage, myName);
                            creatures.Add(Goblin);
                            creatures[0].raceInt = 0;

                            Console.WriteLine("Added goblin: " + myName);
                            Console.WriteLine(" ");
                            Console.WriteLine("STR: " + Goblin.STR);
                            Console.WriteLine("CON: " + Goblin.CON);
                            Console.WriteLine("DEX: " + Goblin.DEX);
                            Console.WriteLine("INT: " + Goblin.INT);
                            Console.WriteLine(" ");

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@.@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@/@@(.* @@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@,@@,/,,@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@&*/@@@,/%@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@ ,. &**/@@@,% @@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@..,,//**.,/@@@ ./@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@..//,/.,,//@(,,,./@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@./*//.*****,,.,*./..(,/.,,*,*,@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@#.,,,,,/,,,,(..,,,**@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@,,. ,.,//...//, @@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@.,,,.......///%,@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@//*,..*, ./,./,@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@,,*@@..#.../.  @@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@ ,,,@,, ***,.. @@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@.*..,***.*,..,,*@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@.. ..*/(**## ,,. @@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@,*.,**,, *,/ %,,,,. .(@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@**,, @@@@@@@@,.., @@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@%%/*,@@@@@@@@@@...*@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@.*,,@@@@@@@@....@@@@@@@*&.@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@.*, @@@@@@@@@@*,, @@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@ ,@@@@@@@@@@@@@.*,*.@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@,*, @@@@@@@@@@@@");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("        ");
                            Console.WriteLine("goblins can use the skill slingshot");
                            Console.WriteLine("        ");
                            turns = true;
                            break;
                    }

                    switch (key)
                    {
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:

                            float health = 20;
                            float attackDamage = 3;

                            Console.WriteLine("INPUT THE NAME OF YOUR ELF");
                            string myName = Console.ReadLine();
                            musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/menu_click.wav";
                            musicPlayer.Play();
                            creature Nightelf = new nightelf(health, attackDamage, myName);
                            creatures.Add(Nightelf);
                            creatures[0].raceInt = 1;
                            Console.WriteLine("Added nightelf: " + myName);
                            Console.WriteLine(" ");
                            Console.WriteLine("STR: " + Nightelf.STR);
                            Console.WriteLine("CON: " + Nightelf.CON);
                            Console.WriteLine("DEX: " + Nightelf.DEX);
                            Console.WriteLine("INT: " + Nightelf.INT);
                            Console.WriteLine(" ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@*(/*,@@@@@@@@@@@@@@@(@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@/,//((%/#@@@@@@@@@@. ..@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@,**,//%/#@@@@@@  .. @@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@/**,/*(#@@@@@/#.  @@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@(**, ...., (((/(@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@&(...,,,,.//.@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@##(, ,*,.,**/@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@,@@@@@@@@@@@@@&#*/&*(%##*&@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@,@@@@@@@@@&((#*(% ,...,,@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@*@@@@@@@@@@@#*&*/**(/,.@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@.#@@@@@@@@  ***,,*/.@@@@@@@@@@@.,@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@ ..@@@@*,*/**,,, @@@@@@@.@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@,. .........*@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@.@   ...  @@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@..  ....@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@..**.,.  @@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@...,..,  @@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@  .. # ..  @@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@.. *@ .  @@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@/   @@ ., @@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@.. @@. . @@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@..  @@%.. @@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@.. ..  .,. @@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("        ");
                            Console.WriteLine("nightelfs can use the skill bow`n`arrow");
                            Console.WriteLine("        ");

                            turns = true;
                            break;
                    }

                    switch (key)
                    {
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:

                            float health = 20;
                            float attackDamage = 3;

                            Console.WriteLine("INPUT THE NAME OF YOUR TROLL");
                            string myName = Console.ReadLine();
                            musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/menu_click.wav";
                            musicPlayer.Play();
                            creature Troll = new troll(health, attackDamage, myName);
                            creatures.Add(Troll);
                            creatures[0].raceInt = 2;
                            Console.WriteLine("Added troll: " + myName);
                            Console.WriteLine(" ");
                            Console.WriteLine("STR: " + Troll.STR);
                            Console.WriteLine("CON: " + Troll.CON);
                            Console.WriteLine("DEX: " + Troll.DEX);
                            Console.WriteLine("INT: " + Troll.INT);
                            Console.WriteLine(" ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@&&,,,,,,*&@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@(,**,,,*,,*/**,.,,*@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@,,,*,*,,*,,***,*(,//,#@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@&,.,**,,,,***/**,,(#.,(%@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@**,,*/,,,****//,,/*.,,*//*(@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@,,,***..,*//(//,*./..,,..,.*&@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@,*,.**.. ..,***(**,.**,,*/,.,,@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@,**,,..@...,.*****,,,* ..//@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@,***,,,@@...,,,....,.....**@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@,,*/,,/@@.............,*..%@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@,,/*,@@@,.....,,,..,... .,*@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@,,//,,@@@.,.,*,,,.,,..*.,.@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@*/(,...@,,.*,**,,,.,.,,. *@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@*,.,**,@@,,..*****,,,,..,..*@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@*, ..@@@@@.,/**,....... ,,*/ %@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@(*..@@@@@@@,,*/*,,..,....,,,*.&#.,@@@@@@@@%@@@@");
                            Console.WriteLine("@/*.@@@@@@@@@.,,,*..@..,., ,,,.,,@@@ .,#@@**,,**@");
                            Console.WriteLine("@(@@@@@@@@@@@/,,,..@@....@@  ,.,,@@@@@#. ,,,,,,,,");
                            Console.WriteLine("@@@@@@@@@@@@%..,...&@.,,*(.......@@@@@@@,,,,**,..");
                            Console.WriteLine("@@@@@@@@@@@@@..... %@@@@@... .(@@@@@@@@..,,,,, .&");
                            Console.WriteLine("@@@@@@@@@@@@@@@ ..@@@@... .@@@@@@@@@@@@...,,,..@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@...@@@&&.,,,,&%%%%%%&&&%%#....@@@");
                            Console.WriteLine("@@@@@@@@@@@@@....,..***********//(#%&@@@@@@@@@@@@");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("trolls can use the skill bash");
                            Console.WriteLine("        "); turns = true;
                            break;
                    }

                    switch (key)
                    {
                        case ConsoleKey.D4:
                        case ConsoleKey.NumPad4:

                            float health = 20;
                            float attackDamage = 3;

                            Console.WriteLine("INPUT THE NAME OF YOUR GHOST");
                            string myName = Console.ReadLine();
                            musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/menu_click.wav";
                            musicPlayer.Play();
                            creature Ghost = new ghost(health, attackDamage, myName);
                            creatures.Add(Ghost);
                            creatures[0].raceInt = 3;
                            Console.WriteLine("Added ghost: " + myName);
                            Console.WriteLine(" ");
                            Console.WriteLine("STR: " + Ghost.STR);
                            Console.WriteLine("CON: " + Ghost.CON);
                            Console.WriteLine("DEX: " + Ghost.DEX);
                            Console.WriteLine("INT: " + Ghost.INT);
                            Console.WriteLine(" ");
                            Console.ForegroundColor = ConsoleColor.Green;

                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@*@@@@@@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@%%#%%#%%%(@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@/%%%%%#*%/@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@#//&**/(%/(@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@*% (*%%% (#(@@&/%%(@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@%%%% (% **(#@@@@*(%(@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@##(%(@@@@*@@/(*/(&%((*@@@@@%@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@(%%% **%% *(%% &% *&% *(%@(/@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@(*(%% ((% &%%/%%%@@@%@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@(*(&&% (&@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@(% &% ((% (@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@(%% ((((*@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@/ (((((/ ((((@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@((##@@@@#@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");



                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("        ");
                            Console.WriteLine("ghosts can use the skill drain life");
                            Console.WriteLine("        ");

                            turns = true;
                            break;
                    }

                    switch (key)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:

                            float health = 20;
                            float attackDamage = 3;

                            Console.WriteLine("INPUT THE NAME OF YOUR HUMAN");
                            string myName = Console.ReadLine();
                            musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/menu_click.wav";
                            musicPlayer.Play();
                            creature Human = new human(health, attackDamage, myName);
                            creatures.Add(Human);
                            creatures[0].raceInt = 4;
                            Console.WriteLine("Added human: " + myName);
                            Console.WriteLine(" ");
                            Console.WriteLine("STR: " + Human.STR);
                            Console.WriteLine("CON: " + Human.CON);
                            Console.WriteLine("DEX: " + Human.DEX);
                            Console.WriteLine("INT: " + Human.INT);
                            Console.WriteLine(" ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("@@&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&@@&");
                            Console.WriteLine("&&&&&&&&&&&&&%&&&&%%%%%%%&&%%&&&&&&&&&&&&&&&&&&&&");
                            Console.WriteLine("&&&&&&&&&&&&&%&%&&%%%%%%%&&&&&&&&&%&%%%%&%&&&&&&&");
                            Console.WriteLine("&&&&&&&&&%%&&&&,,&&&%%&&%&./,*// &&&&%%%%%&&&&&&&");
                            Console.WriteLine("&&&&&&&%%%%%%&&. .&&&&&&.,*///./,/ &%&%%%%%%&%&&&");
                            Console.WriteLine("&&&%&&%%%%%&%%&&%# &&&.**/%**.,.,/.&&%%%%%%%%&&&&");
                            Console.WriteLine("&&&&%%%%%%%%%&&&%/.&& ,,.*,,/* ../.&&%%%%%%%%%&&%");
                            Console.WriteLine("&&&%%%%%%%%%%%%& .& /.. /,,*(%##/.&&%%%%%%%%%%%%&");
                            Console.WriteLine("&&%%%%%%%%%%%%%&%,&&,#./*/.,.,/,&&&%%%%%%%%%%%%%%");
                            Console.WriteLine("&&%%%%%%%%%%%%%&%..##(/. ,/**. &&&&&&%%%%%%%%%%%%");
                            Console.WriteLine("&&%%%%%%%%%%%%&#..*&#/,*,,#*,# @.**. #&&&%%%%%%%%");
                            Console.WriteLine("&&%%%%%%%%%%%&/#/*, , /.,*,/,.**,  ,,.(*&&&%%%%%%");
                            Console.WriteLine("&&%%%%%%%%%%&&.**#,..**,*,... ,,.***, ,,/,&%%%%%%");
                            Console.WriteLine("&&%%%%%**&&&&&,**.,.,///(///*.,****,*,.,,/&&&%%%%");
                            Console.WriteLine("&&%%%&&...#&&%,*,((,//,*/,*,./*.,*.((* ,,*&&&%%%%");
                            Console.WriteLine("&&%&%&&&&& ..,,,,.,,/,&*,,,.,/#*#. ,,..,*.&&&%%%%");
                            Console.WriteLine("&&%%%%%%&&&&&..., &,((.&***#&,*(///# ,,.&&&%%%%%%");
                            Console.WriteLine("&&%%%%%%%%&&&*/.,.///.(,    ....,#/#*#&&&&&%%%%%%");
                            Console.WriteLine("&&&%%%%%%%%&%/&&%,,,,(%(.&&&&&&%,,//,#&&&&%%%%%%&");
                            Console.WriteLine("&&&&%%%%%%%&&&#,**/(/.,,*%#//&&&&*((//(&&&%%%%&&%");
                            Console.WriteLine("&&&%&&%%%&&&&%,*,,,*&&&&.,..(&&,#,//.,#&&%%%%&&%&");
                            Console.WriteLine("&&&&&&&&&&&&&*. ...&&&&&&&&(.,,.&&  .&&&&&&&&&&&&");
                            Console.WriteLine("&&&&&&&&&&&&*..*&&&&&&&&&&&&&&&&@,,,&&&&&&&&&&&&&");
                            Console.WriteLine("&&&&&&&&&&&.*/%/       ....      /../(%*..&&&&&&&");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("        ");
                            Console.WriteLine("humans can use the skill wooden cannon");
                            Console.WriteLine("        ");
                            turns = true;
                            break;
                    }
                    //Thread.Sleep(750);
                    Console.WriteLine("<< press any key >>");
                    Console.ReadKey();
                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/menu_yes.wav";
                    musicPlayer.Play();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("                   ");
                    Console.WriteLine("select the class of your creature, player 1");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("┌────────────────────────┐");
                    Console.WriteLine("│attacker [1]            │");
                    Console.WriteLine("└────────────────────────┘");
                    Console.WriteLine("                   ");
                    Console.WriteLine("┌────────────────────────┐");
                    Console.WriteLine("│defender [2]            │");
                    Console.WriteLine("└────────────────────────┘");
                    Console.WriteLine("                   ");
                    Console.WriteLine("┌────────────────────────┐");
                    Console.WriteLine("│sorcerer [3]            │");
                    Console.WriteLine("└────────────────────────┘");
                    Console.WriteLine("                   ");
                    Console.WriteLine("┌────────────────────────┐");
                    Console.WriteLine("│rogue [4]               │");
                    Console.WriteLine("└────────────────────────┘");
                    Console.WriteLine("                   ");



                    // creatures[i].asgasgs

                    //determine the class of ur character              
                    ConsoleKey key2 = Console.ReadKey().Key;

                    switch (key2)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:



                            Console.WriteLine("you selected the attacker class! You gain +3 STR and +2 CON");
                            Console.WriteLine("Your creature is equipped with a sharp sword!");
                            creatures[0].weaponString = "sword";
                            creatures[0].skillString = "fatal strike";
                            Console.WriteLine(" ");
                            // give us a new stat and add 3 STR and 2 CON!
                            Console.WriteLine(" ");
                            musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/menu_click.wav";
                            musicPlayer.Play();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@.,,.,.@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@, *(*.,@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@,,,,*,,@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@*.,*(**., *@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@/*....,.*(,,,.#@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@,#..,.,*,,,//.*, @@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@,/...*/, ..,.,.,,*@@@@@@%,/");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@,.,....*//,,*(*..,, @@*,*.*/@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@(.,.*,, **,./*&&.,,,.*...,@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@.*,.@../...(**@@,,/,./*..,@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@*...,,.,,,.*,,,,/,//,.../@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@ *,......,.,**,,**///***.@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@&.,,...,..***/,,,/,,/*/*..*@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@.*,..,,.*,,.,,*,,,,,/,/*,...,@@@@");
                            Console.WriteLine("@@@@@@@@@&.,.* #@@@@@ @@..,.,*,..,,,/(*,....&@@@@");
                            Console.WriteLine("@@@((** #@@@@@@@@@@@@@@@....,,,../*,,,*.*..,@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@..,,,./..@,/**....,.@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@.,,**.*@/@*/**.@@,@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@(/****@@@**/,@@@@,&@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@,**%@@@/,**@@@@@.@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@./*@@@@@*,,@@@@@@,@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@*/*@@@@@.(/@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@,*,..@@@@@.//@@@@@@@@@@@@");
                            Console.ForegroundColor = ConsoleColor.White;

                            creatures[0].STR = creatures[0].STR + 3;
                            creatures[0].CON = creatures[0].CON + 2;
                            creatures[0].classInt = 0;
                            Console.WriteLine("STR: " + creatures[0].STR);
                            Console.WriteLine("CON: " + creatures[0].CON);
                            Console.WriteLine("DEX: " + creatures[0].DEX);
                            Console.WriteLine("INT: " + creatures[0].INT);

                            Console.WriteLine(" ");

                            turns = true;
                            break;

                        // if this is a defender

                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:



                            Console.WriteLine("you selected the defender class! You gain +3 CON and +2 STR");
                            Console.WriteLine("Your creature is equipped with heavy mace!");
                            creatures[0].weaponString = "mace";
                            creatures[0].skillString = "triple bash";
                            Console.WriteLine(" ");
                            // give us a new stat and add 3 STR and 2 CON!
                            Console.WriteLine(" ");
                            musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/menu_click.wav";
                            musicPlayer.Play();
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@#@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@# ....*@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@*,(%((*@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@,.%%%/.@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@&, ***,,.@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@&*,.          *,@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@&..    ..  ,. ....,*@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@,**..     . ,,.  ,.#,@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@,..*.,,. ... .*,,/,*/,*@@@@@@");
                            Console.WriteLine("@@@@@@@(@@@@@@@@@@@/*. .*/*,..,...*/%%, .,.,%@@@@");
                            Console.WriteLine("@@@@@%*#@@@@&@@@@@@./,.//*.,,*,,#*/*/*,. .. .,@@@");
                            Console.WriteLine("@@@@/(%@@@@(#@@@@@#,*,#/*,#,**(//( . .,, .    ,@@");
                            Console.WriteLine("@@@&&(*&@@,,&@@@@%,/.@(*,*/**/*.,,.  ,,..     @@@");
                            Console.WriteLine("@@(@&*(%((*,...,.,#@,//,(//#/**. .. . ...        ");
                            Console.WriteLine("@&&/,/&@&./&@@@@@@@@@@*(#*&&/%(*/,,       .,    %");
                            Console.WriteLine("&//*%@@@%@@@@@@@@@@@@(,,,%@&(//%@,.        (@@@@@");
                            Console.WriteLine("*(((@@@@@@@@@@@@@@@@@(.,(%%@@(/@(*.     (@@@@@@@@");
                            Console.WriteLine("((*@@@@@@@@@@@@@@@@@@#* *//*&**,/,*/,@,&@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@&.  *##,@@@%./%(.&@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@%. #*&@@&,.*../@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@..,.  #@@@@@/#%#/*@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@(%/*(*.*@@@@@#.**,@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@((####*%@@@@@#.*.*@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@,*,./@@@@@@@@@@(.,*.,&@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@#,.,.&@@@@@@@@@@@@%*.(@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@(,(/,,@@@@@@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@.....(@@@@@@@@@@@@@@@@@@@@@@@@@@");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("        ");
                            creatures[0].STR = creatures[0].STR + 3;
                            creatures[0].CON = creatures[0].CON + 2;
                            creatures[0].classInt = 1;
                            Console.WriteLine("STR: " + creatures[0].STR);
                            Console.WriteLine("CON: " + creatures[0].CON);
                            Console.WriteLine("DEX: " + creatures[0].DEX);
                            Console.WriteLine("INT: " + creatures[0].INT);
                            turns = true;
                            break;


                        //if this is a mage

                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:



                            Console.WriteLine("you selected the sorcerer class! You gain +3 INT and +2 DEX");

                            Console.WriteLine("Your creature is equipped with magic staff!");
                            creatures[0].weaponString = "staff";
                            creatures[0].skillString = "magic missile";
                            Console.WriteLine(" ");
                            // give us a new stat and add 3 STR and 2 CON!
                            Console.WriteLine(" ");
                            musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/menu_click.wav";
                            musicPlayer.Play();
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@(///*@@@@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@((,,//**/@@@@@@@@@@%/@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@&@@/,(,#..*,,,,@@@@@@@@/***@@@@@@@@@");
                            Console.WriteLine("@@@@@@&@@@@@@@@@,,*/,***.*..%@@@@@@@*((/@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@(,/,./%%%%,..%@@@@@@#,*@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@&@@@@@@@,,*....%*(.,.,,@@@@@@&/#@@@@@@@@@@");
                            Console.WriteLine("@@&@@@@@@@@@@@@@*,....//.*,.,,@@@@@@/*@@@@@@@@@@@");
                            Console.WriteLine("@@@@&&&@@@@@@#(/*,...#%.*..,//@@@@(,@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@&@&%&@#@@**%(/**,*/,/#,*,,,,@@@@#,@@@@@@@@@@@");
                            Console.WriteLine("@@&&@@&@&%@@##,,,,,,*,*%...%/,*/,@@@(/@@@@@@@@@@@");
                            Console.WriteLine("@##@@@@@&@@#(**/*,.,*(#*%/*,*//*@@(&@@@@@@@@@@@@@");
                            Console.WriteLine("@@(%@@&@%&@#(#/*,**,..,./,,,../%/.**,@@@@@@@@@@@@");
                            Console.WriteLine("@@@%&@@@@@(#(,/,,.**.,..../*/#((..*@@@@@@@@@@@@@@");
                            Console.WriteLine("@@&&@@@%@(%.,,.#/.....**...,/.*%%(#*,./@@@@@@@@@@");
                            Console.WriteLine("@@@&@@@@&,,,/,,//.,..*(,,,.,//*/(*,*%..,@@@@@@@@@");
                            Console.WriteLine("@@@@#@@@**%#@.**.,.../,...,,.,,/,..*,/..@@@@@@@@@");
                            Console.WriteLine("@@@@@#*...%*,**.,,...*,/....,,,,,,**,,..@@@@@@@@@");
                            Console.WriteLine("@@@@@#@*/****....,.../,,.,,,,,.,,**/*,...@@@@@@@@");
                            Console.WriteLine("@@@@@@@%*/@//,.......%**..,,,.,.**,**,....@@@@@@@");
                            Console.WriteLine("@@@@@@,,*,///*,,,,,....,//*,.,,,,,,,&@@@@@@@@@(@@");
                            Console.WriteLine("@@@@@*,//,*/////,,,,...,%#(,,,/((,,,.@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@,////*//..%//#,....%#///##((*,%.@@@@@@@@@@@@");
                            Console.WriteLine("@@@@,/,//////@@@*,%%,,,./.,,.....**/@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@,,,*//////@@(//...//*,,,./*%@(@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@,,//////@@@@@.,,,,,,..@@@,,@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@.....&%*.*,@@@*&@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@.,,.,@#****@%,@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@,...@%*,.,..,@@@@@@@@@@@@@@@@"); 
                            Console.ForegroundColor = ConsoleColor.Green;



                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("        ");
                            creatures[0].INT = creatures[0].INT + 3;
                            creatures[0].DEX = creatures[0].DEX + 2;
                            creatures[0].classInt = 2;
                            Console.WriteLine("STR: " + creatures[0].STR);
                            Console.WriteLine("CON: " + creatures[0].CON);
                            Console.WriteLine("DEX: " + creatures[0].DEX);
                            Console.WriteLine("INT: " + creatures[0].INT);
                            turns = true;
                            break;


                        // if this is a rogue

                        case ConsoleKey.D4:
                        case ConsoleKey.NumPad4:



                            Console.WriteLine("you selected the rogue class! You gain +3 DEX and +2 STR");

                            Console.WriteLine("Your creature is equipped with a set of daggers!");
                            creatures[0].weaponString = "daggers";
                            creatures[0].skillString = "backstab";
                            Console.WriteLine(" ");
                            // give us a new stat and add 3 STR and 2 CON!
                            Console.WriteLine(" ");
                            musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/menu_click.wav";
                            musicPlayer.Play();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@#@@@@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@*.*,,,*,,&@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@,   ,,,.,.@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@  ..,*..,.@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@,.  .*...,,,@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@(, .. .,.....,*@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@%  . ........,.,,,,@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@... .  .......,. ,*,*@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@. . ...,.....,,,...,%@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@,*,.........,..,.....&@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@,,,... .,...,..,..,@...*@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@&.*.,.....*((/..,..(%..@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@,.    . .....,.*.,*/@...@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@, ... . ..,.,.,,.,,,(/ ...@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@*....,.,,...,*(.*,,,#,...&@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@,. .....,(. .. /,.,.,,/*./#@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@, ...,* ...,.,  *..,,. ,*(@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@..@@@@ . .....   .......,@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@(........   . .....,#@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@.....,,,..   ,,,.*...@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@.....,,,..   ,,,.*...@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@,., ../*(.*...  .,/**..*@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@....,,(/,/*..  ..,,*  .#@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@/....,,,,/***.....,,,//..@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@,...,,,#.///*(..,.,**/#,.,@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@/. @@@@% ..//%@@@@,*,**./@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@*,,*,,@@@@@@,*,*#@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@% *//,*/*,@@@@@@@@,,,*,@@@@@@@@@@");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("        ");
                            creatures[0].DEX = creatures[0].DEX + 3;
                            creatures[0].STR = creatures[0].STR + 2;
                            creatures[0].classInt = 3;
                            Console.WriteLine("STR: " + creatures[0].STR);
                            Console.WriteLine("CON: " + creatures[0].CON);
                            Console.WriteLine("DEX: " + creatures[0].DEX);
                            Console.WriteLine("INT: " + creatures[0].INT);
                            turns = true;
                            break;



                    }
                    Console.WriteLine("<< press any key >>");

                    Console.ReadKey();
                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/menu_yes.wav";
                    musicPlayer.Play();
                }

                //battle starts.. Paint name, stats, race, class, weapon and skill on top left and right
                //for both players. The actual battle stats are being written down below them.

                //player 1s turn!
                else if (turns == true)
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("HELLO PLAYER 2!");
                    Console.WriteLine("                   ");
                    Console.WriteLine("select the race of your creature");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("┌────────────────────────┐");
                    Console.WriteLine("│human [1]               │");
                    Console.WriteLine("└────────────────────────┘");
                    Console.WriteLine("                   ");
                    Console.WriteLine("┌────────────────────────┐");
                    Console.WriteLine("│nightelf [2]            │");
                    Console.WriteLine("└────────────────────────┘");
                    Console.WriteLine("                   ");
                    Console.WriteLine("┌────────────────────────┐");
                    Console.WriteLine("│troll [3]               │");
                    Console.WriteLine("└────────────────────────┘");
                    Console.WriteLine("                   ");
                    Console.WriteLine("┌────────────────────────┐");
                    Console.WriteLine("│ghost [4]               │");
                    Console.WriteLine("└────────────────────────┘");
                    Console.WriteLine("                   ");
                    Console.WriteLine("┌────────────────────────┐");
                    Console.WriteLine("│goblin [5]              │");
                    Console.WriteLine("└────────────────────────┘");
                    Console.WriteLine("                   ");

                    ConsoleKey key = Console.ReadKey().Key;
                    switch (key)
                    {
                        case ConsoleKey.D5:
                        case ConsoleKey.NumPad5:


                            float health = 20;
                            float attackDamage = 3;

                            Console.WriteLine("INPUT THE NAME OF YOUR GOBLIN");
                            string myName = Console.ReadLine();

                            creature Goblin = new goblin(health, attackDamage, myName);
                            creatures.Add(Goblin);
                            creatures[1].raceInt = 0;

                            Console.WriteLine("Added goblin: " + myName);

                            Console.WriteLine("STR: " + Goblin.STR);
                            Console.WriteLine("CON: " + Goblin.CON);
                            Console.WriteLine("DEX: " + Goblin.DEX);
                            Console.WriteLine("INT: " + Goblin.INT);

                            SoundPlayer musicPlayer2 = new SoundPlayer();
                            musicPlayer2.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/menu_click.wav";
                            musicPlayer2.Play();

                            Console.WriteLine(" ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@.@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@/@@(.* @@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@,@@,/,,@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@&*/@@@,/%@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@ ,. &**/@@@,% @@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@..,,//**.,/@@@ ./@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@..//,/.,,//@(,,,./@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@./*//.*****,,.,*./..(,/.,,*,*,@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@#.,,,,,/,,,,(..,,,**@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@,,. ,.,//...//, @@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@.,,,.......///%,@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@//*,..*, ./,./,@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@,,*@@..#.../.  @@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@ ,,,@,, ***,.. @@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@.*..,***.*,..,,*@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@.. ..*/(**## ,,. @@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@,*.,**,, *,/ %,,,,. .(@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@**,, @@@@@@@@,.., @@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@%%/*,@@@@@@@@@@...*@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@.*,,@@@@@@@@....@@@@@@@*&.@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@.*, @@@@@@@@@@*,, @@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@ ,@@@@@@@@@@@@@.*,*.@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@,*, @@@@@@@@@@@@");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("        ");
                            Console.WriteLine("goblins can use the skill slingshot");
                            Console.WriteLine("        ");


                            turns = false;
                            break;
                    }

                    switch (key)
                    {
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:

                            float health = 20;
                            float attackDamage = 3;

                            Console.WriteLine("INPUT THE NAME OF YOUR ELF");
                            string myName = Console.ReadLine();

                            creature Nightelf = new nightelf(health, attackDamage, myName);
                            creatures.Add(Nightelf);
                            creatures[1].raceInt = 1;
                            Console.WriteLine("Added nightelf: " + myName);
                            SoundPlayer musicPlayer2 = new SoundPlayer();
                            musicPlayer2.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/menu_click.wav";
                            musicPlayer2.Play();
                            Console.WriteLine("STR: " + Nightelf.STR);
                            Console.WriteLine("CON: " + Nightelf.CON);
                            Console.WriteLine("DEX: " + Nightelf.DEX);
                            Console.WriteLine("INT: " + Nightelf.INT);
                            Console.WriteLine(" ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@*(/*,@@@@@@@@@@@@@@@(@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@/,//((%/#@@@@@@@@@@. ..@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@,**,//%/#@@@@@@  .. @@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@/**,/*(#@@@@@/#.  @@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@(**, ...., (((/(@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@&(...,,,,.//.@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@##(, ,*,.,**/@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@,@@@@@@@@@@@@@&#*/&*(%##*&@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@,@@@@@@@@@&((#*(% ,...,,@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@*@@@@@@@@@@@#*&*/**(/,.@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@.#@@@@@@@@  ***,,*/.@@@@@@@@@@@.,@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@ ..@@@@*,*/**,,, @@@@@@@.@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@,. .........*@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@.@   ...  @@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@..  ....@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@..**.,.  @@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@...,..,  @@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@  .. # ..  @@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@.. *@ .  @@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@/   @@ ., @@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@.. @@. . @@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@..  @@%.. @@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@.. ..  .,. @@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("        ");
                            Console.WriteLine("nightelfs have bow and arrows as skill");


                            turns = false;
                            break;
                    }

                    switch (key)
                    {
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:


                            float health = 20;
                            float attackDamage = 3;

                            Console.WriteLine("INPUT THE NAME OF YOUR TROLL");
                            string myName = Console.ReadLine();

                            creature Troll = new troll(health, attackDamage, myName);
                            creatures.Add(Troll);
                            creatures[1].raceInt = 2;

                            Console.WriteLine("Added troll: " + myName);
                            SoundPlayer musicPlayer2 = new SoundPlayer();
                            musicPlayer2.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/menu_click.wav";
                            musicPlayer2.Play();
                            Console.WriteLine("STR: " + Troll.STR);
                            Console.WriteLine("CON: " + Troll.CON);
                            Console.WriteLine("DEX: " + Troll.DEX);
                            Console.WriteLine("INT: " + Troll.INT);
                            Console.WriteLine(" ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@&&,,,,,,*&@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@(,**,,,*,,*/**,.,,*@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@,,,*,*,,*,,***,*(,//,#@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@&,.,**,,,,***/**,,(#.,(%@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@**,,*/,,,****//,,/*.,,*//*(@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@,,,***..,*//(//,*./..,,..,.*&@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@,*,.**.. ..,***(**,.**,,*/,.,,@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@,**,,..@...,.*****,,,* ..//@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@,***,,,@@...,,,....,.....**@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@,,*/,,/@@.............,*..%@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@,,/*,@@@,.....,,,..,... .,*@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@,,//,,@@@.,.,*,,,.,,..*.,.@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@*/(,...@,,.*,**,,,.,.,,. *@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@*,.,**,@@,,..*****,,,,..,..*@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@*, ..@@@@@.,/**,....... ,,*/ %@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@(*..@@@@@@@,,*/*,,..,....,,,*.&#.,@@@@@@@@%@@@@");
                            Console.WriteLine("@/*.@@@@@@@@@.,,,*..@..,., ,,,.,,@@@ .,#@@**,,**@");
                            Console.WriteLine("@(@@@@@@@@@@@/,,,..@@....@@  ,.,,@@@@@#. ,,,,,,,,");
                            Console.WriteLine("@@@@@@@@@@@@%..,...&@.,,*(.......@@@@@@@,,,,**,..");
                            Console.WriteLine("@@@@@@@@@@@@@..... %@@@@@... .(@@@@@@@@..,,,,, .&");
                            Console.WriteLine("@@@@@@@@@@@@@@@ ..@@@@... .@@@@@@@@@@@@...,,,..@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@...@@@&&.,,,,&%%%%%%&&&%%#....@@@");
                            Console.WriteLine("@@@@@@@@@@@@@....,..***********//(#%&@@@@@@@@@@@@");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(" ");

                            Console.WriteLine("trolls have a powerful melee skill");

                            turns = false;
                            break;
                    }

                    switch (key)
                    {
                        case ConsoleKey.D4:
                        case ConsoleKey.NumPad4:



                            float health = 20;
                            float attackDamage = 3;
                            Console.WriteLine("INPUT THE NAME OF YOUR GHOST");
                            string myName = Console.ReadLine();

                            creature Ghost = new ghost(health, attackDamage, myName);
                            creatures.Add(Ghost);
                            creatures[1].raceInt = 3;

                            Console.WriteLine("Added ghost: " + myName);
                            SoundPlayer musicPlayer2 = new SoundPlayer();
                            musicPlayer2.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/menu_click.wav";
                            musicPlayer2.Play();
                            Console.WriteLine("STR: " + Ghost.STR);
                            Console.WriteLine("CON: " + Ghost.CON);
                            Console.WriteLine("DEX: " + Ghost.DEX);
                            Console.WriteLine("INT: " + Ghost.INT);
                            Console.WriteLine(" ");
                            Console.ForegroundColor = ConsoleColor.Red;


                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@*@@@@@@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@%%#%%#%%%(@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@/%%%%%#*%/@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@#//&**/(%/(@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@*% (*%%% (#(@@&/%%(@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@%%%% (% **(#@@@@*(%(@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@##(%(@@@@*@@/(*/(&%((*@@@@@%@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@(%%% **%% *(%% &% *&% *(%@(/@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@(*(%% ((% &%%/%%%@@@%@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@(*(&&% (&@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@(% &% ((% (@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@(%% ((((*@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@/ (((((/ ((((@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@((##@@@@#@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");


                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("        ");
                            Console.WriteLine("ghosts can drain life as a skill");

                            turns = false;
                            break;
                    }

                    switch (key)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:

                            float health = 20;
                            float attackDamage = 3;
                            Console.WriteLine("INPUT THE NAME OF YOUR HUMAN");
                            string myName = Console.ReadLine();

                            creature Human = new human(health, attackDamage, myName);
                            creatures.Add(Human);
                            creatures[1].raceInt = 4;

                            Console.WriteLine("Added human: " + myName);
                            SoundPlayer musicPlayer2 = new SoundPlayer();
                            musicPlayer2.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/menu_click.wav";
                            musicPlayer2.Play();
                            Console.WriteLine(" ");
                            Console.WriteLine("STR: " + Human.STR);
                            Console.WriteLine("CON: " + Human.CON);
                            Console.WriteLine("DEX: " + Human.DEX);
                            Console.WriteLine("INT: " + Human.INT);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("@@&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&@@&");
                            Console.WriteLine("&&&&&&&&&&&&&%&&&&%%%%%%%&&%%&&&&&&&&&&&&&&&&&&&&");
                            Console.WriteLine("&&&&&&&&&&&&&%&%&&%%%%%%%&&&&&&&&&%&%%%%&%&&&&&&&");
                            Console.WriteLine("&&&&&&&&&%%&&&&,,&&&%%&&%&./,*// &&&&%%%%%&&&&&&&");
                            Console.WriteLine("&&&&&&&%%%%%%&&. .&&&&&&.,*///./,/ &%&%%%%%%&%&&&");
                            Console.WriteLine("&&&%&&%%%%%&%%&&%# &&&.**/%**.,.,/.&&%%%%%%%%&&&&");
                            Console.WriteLine("&&&&%%%%%%%%%&&&%/.&& ,,.*,,/* ../.&&%%%%%%%%%&&%");
                            Console.WriteLine("&&&%%%%%%%%%%%%& .& /.. /,,*(%##/.&&%%%%%%%%%%%%&");
                            Console.WriteLine("&&%%%%%%%%%%%%%&%,&&,#./*/.,.,/,&&&%%%%%%%%%%%%%%");
                            Console.WriteLine("&&%%%%%%%%%%%%%&%..##(/. ,/**. &&&&&&%%%%%%%%%%%%");
                            Console.WriteLine("&&%%%%%%%%%%%%&#..*&#/,*,,#*,# @.**. #&&&%%%%%%%%");
                            Console.WriteLine("&&%%%%%%%%%%%&/#/*, , /.,*,/,.**,  ,,.(*&&&%%%%%%");
                            Console.WriteLine("&&%%%%%%%%%%&&.**#,..**,*,... ,,.***, ,,/,&%%%%%%");
                            Console.WriteLine("&&%%%%%**&&&&&,**.,.,///(///*.,****,*,.,,/&&&%%%%");
                            Console.WriteLine("&&%%%&&...#&&%,*,((,//,*/,*,./*.,*.((* ,,*&&&%%%%");
                            Console.WriteLine("&&%&%&&&&& ..,,,,.,,/,&*,,,.,/#*#. ,,..,*.&&&%%%%");
                            Console.WriteLine("&&%%%%%%&&&&&..., &,((.&***#&,*(///# ,,.&&&%%%%%%");
                            Console.WriteLine("&&%%%%%%%%&&&*/.,.///.(,    ....,#/#*#&&&&&%%%%%%");
                            Console.WriteLine("&&&%%%%%%%%&%/&&%,,,,(%(.&&&&&&%,,//,#&&&&%%%%%%&");
                            Console.WriteLine("&&&&%%%%%%%&&&#,**/(/.,,*%#//&&&&*((//(&&&%%%%&&%");
                            Console.WriteLine("&&&%&&%%%&&&&%,*,,,*&&&&.,..(&&,#,//.,#&&%%%%&&%&");
                            Console.WriteLine("&&&&&&&&&&&&&*. ...&&&&&&&&(.,,.&&  .&&&&&&&&&&&&");
                            Console.WriteLine("&&&&&&&&&&&&*..*&&&&&&&&&&&&&&&&@,,,&&&&&&&&&&&&&");
                            Console.WriteLine("&&&&&&&&&&&.*/%/       ....      /../(%*..&&&&&&&");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("        ");
                            Console.WriteLine("humans have a wooden handcannon");

                            Console.WriteLine(" ");
                            turns = true;
                            break;
                    }

                    Console.WriteLine("<< press any key >>");
                    Console.ReadKey();
                    SoundPlayer musicPlayer1 = new SoundPlayer();
                    musicPlayer1.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/menu_yes.wav";
                    musicPlayer1.Play();

                    //Thread.Sleep(750);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                   ");
                    Console.WriteLine("select the class of your creature");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("┌────────────────────────┐");
                    Console.WriteLine("│attacker [1]            │");
                    Console.WriteLine("└────────────────────────┘");
                    Console.WriteLine("                   ");
                    Console.WriteLine("┌────────────────────────┐");
                    Console.WriteLine("│defender [2]            │");
                    Console.WriteLine("└────────────────────────┘");
                    Console.WriteLine("                   ");
                    Console.WriteLine("┌────────────────────────┐");
                    Console.WriteLine("│sorcerer [3]            │");
                    Console.WriteLine("└────────────────────────┘");
                    Console.WriteLine("                   ");
                    Console.WriteLine("┌────────────────────────┐");
                    Console.WriteLine("│rogue [4]               │");
                    Console.WriteLine("└────────────────────────┘");
                    Console.WriteLine("                   ");

                    
                    ConsoleKey key2 = Console.ReadKey().Key;

                    switch (key2)
                    {
                    
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:



                            Console.WriteLine("you selected the attacker class! You gain +3 STR and +2 CON");
                            Console.WriteLine("Your creature is equipped with a sharp sword!");
                            creatures[1].weaponString = "sword";
                            creatures[1].skillString = "fatal attack";
                            Console.WriteLine(" ");
                            // give us a new stat and add 3 STR and 2 CON!
                            Console.WriteLine(" ");
                            SoundPlayer musicPlayer2 = new SoundPlayer();
                            musicPlayer2.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/menu_click.wav";
                            musicPlayer2.Play();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@.,,.,.@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@, *(*.,@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@,,,,*,,@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@*.,*(**., *@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@/*....,.*(,,,.#@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@,#..,.,*,,,//.*, @@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@,/...*/, ..,.,.,,*@@@@@@%,/");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@,.,....*//,,*(*..,, @@*,*.*/@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@(.,.*,, **,./*&&.,,,.*...,@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@.*,.@../...(**@@,,/,./*..,@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@*...,,.,,,.*,,,,/,//,.../@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@ *,......,.,**,,**///***.@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@&.,,...,..***/,,,/,,/*/*..*@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@.*,..,,.*,,.,,*,,,,,/,/*,...,@@@@");
                            Console.WriteLine("@@@@@@@@@&.,.* #@@@@@ @@..,.,*,..,,,/(*,....&@@@@");
                            Console.WriteLine("@@@((** #@@@@@@@@@@@@@@@....,,,../*,,,*.*..,@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@..,,,./..@,/**....,.@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@.,,**.*@/@*/**.@@,@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@(/****@@@**/,@@@@,&@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@,**%@@@/,**@@@@@.@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@./*@@@@@*,,@@@@@@,@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@*/*@@@@@.(/@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@,*,..@@@@@.//@@@@@@@@@@@@");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("        ");
                            creatures[1].STR = creatures[1].STR + 3;
                            creatures[1].CON = creatures[1].CON + 2;
                            creatures[1].classInt = 0;
                            Console.WriteLine("STR: " + creatures[1].STR);
                            Console.WriteLine("CON: " + creatures[1].CON);
                            Console.WriteLine("DEX: " + creatures[1].DEX);
                            Console.WriteLine("INT: " + creatures[1].INT);
                            turns = true;
                            break;


                        // if this is a defender

                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:



                            Console.WriteLine("you selected the defender class! You gain +3 CON and +2 STR");

                            Console.WriteLine("Your creature is equipped with a sharp sword!");
                            creatures[1].weaponString = "mace";
                            creatures[1].skillString = "triple bash";
                            Console.WriteLine(" ");
                            // give us a new stat and add 3 STR and 2 CON!
                            Console.WriteLine(" ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            SoundPlayer musicPlayer3 = new SoundPlayer();
                            musicPlayer3.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/menu_click.wav";
                            musicPlayer3.Play();
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@#@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@# ....*@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@*,(%((*@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@,.%%%/.@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@&, ***,,.@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@&*,.          *,@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@&..    ..  ,. ....,*@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@,**..     . ,,.  ,.#,@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@,..*.,,. ... .*,,/,*/,*@@@@@@");
                            Console.WriteLine("@@@@@@@(@@@@@@@@@@@/*. .*/*,..,...*/%%, .,.,%@@@@");
                            Console.WriteLine("@@@@@%*#@@@@&@@@@@@./,.//*.,,*,,#*/*/*,. .. .,@@@");
                            Console.WriteLine("@@@@/(%@@@@(#@@@@@#,*,#/*,#,**(//( . .,, .    ,@@");
                            Console.WriteLine("@@@&&(*&@@,,&@@@@%,/.@(*,*/**/*.,,.  ,,..     @@@");
                            Console.WriteLine("@@(@&*(%((*,...,.,#@,//,(//#/**. .. . ...        ");
                            Console.WriteLine("@&&/,/&@&./&@@@@@@@@@@*(#*&&/%(*/,,       .,    %");
                            Console.WriteLine("&//*%@@@%@@@@@@@@@@@@(,,,%@&(//%@,.        (@@@@@");
                            Console.WriteLine("*(((@@@@@@@@@@@@@@@@@(.,(%%@@(/@(*.     (@@@@@@@@");
                            Console.WriteLine("((*@@@@@@@@@@@@@@@@@@#* *//*&**,/,*/,@,&@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@&.  *##,@@@%./%(.&@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@%. #*&@@&,.*../@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@..,.  #@@@@@/#%#/*@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@(%/*(*.*@@@@@#.**,@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@((####*%@@@@@#.*.*@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@,*,./@@@@@@@@@@(.,*.,&@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@#,.,.&@@@@@@@@@@@@%*.(@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@(,(/,,@@@@@@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@.....(@@@@@@@@@@@@@@@@@@@@@@@@@@");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("        ");
                            creatures[1].CON = creatures[1].CON + 3;
                            creatures[1].STR = creatures[1].STR + 2;
                            creatures[1].classInt = 1;
                            Console.WriteLine("STR: " + creatures[1].STR);
                            Console.WriteLine("CON: " + creatures[1].CON);
                            Console.WriteLine("DEX: " + creatures[1].DEX);
                            Console.WriteLine("INT: " + creatures[1].INT);
                            turns = true;
                            break;


                        //if this is a mage

                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:



                            Console.WriteLine("you selected the sorcerer class! You gain +3 INT and +2 DEX");

                            Console.WriteLine("Your creature is equipped with magic staff!");
                            creatures[1].weaponString = "staff";
                            creatures[1].skillString = "magic missile";
                            Console.WriteLine(" ");
                            // give us a new stat and add 3 STR and 2 CON!
                            Console.WriteLine(" ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            SoundPlayer musicPlayer4 = new SoundPlayer();
                            musicPlayer4.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/menu_click.wav";
                            musicPlayer4.Play();
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@(///*@@@@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@((,,//**/@@@@@@@@@@%/@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@&@@/,(,#..*,,,,@@@@@@@@/***@@@@@@@@@");
                            Console.WriteLine("@@@@@@&@@@@@@@@@,,*/,***.*..%@@@@@@@*((/@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@(,/,./%%%%,..%@@@@@@#,*@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@&@@@@@@@,,*....%*(.,.,,@@@@@@&/#@@@@@@@@@@");
                            Console.WriteLine("@@&@@@@@@@@@@@@@*,....//.*,.,,@@@@@@/*@@@@@@@@@@@");
                            Console.WriteLine("@@@@&&&@@@@@@#(/*,...#%.*..,//@@@@(,@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@&@&%&@#@@**%(/**,*/,/#,*,,,,@@@@#,@@@@@@@@@@@");
                            Console.WriteLine("@@&&@@&@&%@@##,,,,,,*,*%...%/,*/,@@@(/@@@@@@@@@@@");
                            Console.WriteLine("@##@@@@@&@@#(**/*,.,*(#*%/*,*//*@@(&@@@@@@@@@@@@@");
                            Console.WriteLine("@@(%@@&@%&@#(#/*,**,..,./,,,../%/.**,@@@@@@@@@@@@");
                            Console.WriteLine("@@@%&@@@@@(#(,/,,.**.,..../*/#((..*@@@@@@@@@@@@@@");
                            Console.WriteLine("@@&&@@@%@(%.,,.#/.....**...,/.*%%(#*,./@@@@@@@@@@");
                            Console.WriteLine("@@@&@@@@&,,,/,,//.,..*(,,,.,//*/(*,*%..,@@@@@@@@@");
                            Console.WriteLine("@@@@#@@@**%#@.**.,.../,...,,.,,/,..*,/..@@@@@@@@@");
                            Console.WriteLine("@@@@@#*...%*,**.,,...*,/....,,,,,,**,,..@@@@@@@@@");
                            Console.WriteLine("@@@@@#@*/****....,.../,,.,,,,,.,,**/*,...@@@@@@@@");
                            Console.WriteLine("@@@@@@@%*/@//,.......%**..,,,.,.**,**,....@@@@@@@");
                            Console.WriteLine("@@@@@@,,*,///*,,,,,....,//*,.,,,,,,,&@@@@@@@@@(@@");
                            Console.WriteLine("@@@@@*,//,*/////,,,,...,%#(,,,/((,,,.@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@,////*//..%//#,....%#///##((*,%.@@@@@@@@@@@@");
                            Console.WriteLine("@@@@,/,//////@@@*,%%,,,./.,,.....**/@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@,,,*//////@@(//...//*,,,./*%@(@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@,,//////@@@@@.,,,,,,..@@@,,@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@.....&%*.*,@@@*&@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@.,,.,@#****@%,@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@,...@%*,.,..,@@@@@@@@@@@@@@@@"); 



                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("        ");
                            creatures[1].INT = creatures[1].INT + 3;
                            creatures[1].DEX = creatures[1].DEX + 2;
                            creatures[1].classInt = 2;
                            Console.WriteLine("STR: " + creatures[1].STR);
                            Console.WriteLine("CON: " + creatures[1].CON);
                            Console.WriteLine("DEX: " + creatures[1].DEX);
                            Console.WriteLine("INT: " + creatures[1].INT);
                            turns = true;
                            break;


                        // if this is a rogue

                        case ConsoleKey.D4:
                        case ConsoleKey.NumPad4:



                            Console.WriteLine("you selected the rogue class! You gain +3 DEX and +2 STR");

                            Console.WriteLine("Your creature is equipped with a set of daggers!");
                            creatures[1].weaponString = "daggers";
                            creatures[1].skillString = "backstab";
                            Console.WriteLine(" ");
                            // give us a new stat and add 3 STR and 2 CON!
                            Console.WriteLine(" ");
                            
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@#@@@@@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@*.*,,,*,,&@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@,   ,,,.,.@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@  ..,*..,.@@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@,.  .*...,,,@@@@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@(, .. .,.....,*@@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@%  . ........,.,,,,@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@... .  .......,. ,*,*@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@. . ...,.....,,,...,%@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@,*,.........,..,.....&@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@,,,... .,...,..,..,@...*@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@&.*.,.....*((/..,..(%..@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@,.    . .....,.*.,*/@...@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@, ... . ..,.,.,,.,,,(/ ...@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@*....,.,,...,*(.*,,,#,...&@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@,. .....,(. .. /,.,.,,/*./#@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@, ...,* ...,.,  *..,,. ,*(@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@..@@@@ . .....   .......,@@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@(........   . .....,#@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@.....,,,..   ,,,.*...@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@.....,,,..   ,,,.*...@@@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@,., ../*(.*...  .,/**..*@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@....,,(/,/*..  ..,,*  .#@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@/....,,,,/***.....,,,//..@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@,...,,,#.///*(..,.,**/#,.,@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@/. @@@@% ..//%@@@@,*,**./@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@*,,*,,@@@@@@,*,*#@@@@@@@@@@@@");
                            Console.WriteLine("@@@@@@@@@@@@@@@@% *//,*/*,@@@@@@@@,,,*,@@@@@@@@@@");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("        ");

                            creatures[1].DEX = creatures[1].DEX + 3;
                            creatures[1].STR = creatures[1].STR + 2;
                            creatures[1].classInt = 3;
                            Console.WriteLine("STR: " + creatures[1].STR);
                            Console.WriteLine("CON: " + creatures[1].CON);
                            Console.WriteLine("DEX: " + creatures[1].DEX);
                            Console.WriteLine("INT: " + creatures[1].INT);

                            turns = true;
                            break;



                    }
                    Console.WriteLine("<< press any key >>");

                    Console.ReadKey();
                    
                    Thread.Sleep(900);
                    
                    StartBattle();
                    SoundPlayer musicPlayer = new SoundPlayer();
                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/00_beginn_game.wav";
                    musicPlayer.Play();
                }
                
            }
        }

       

        public void Interface()
        {
            int xpos = 0;
            int xpos2 = 50;
            int ypos = 0;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // make console clear, then use console setcursorposition 
            // to make interface! for each char display stats, name and HP bar

            //**************************************************************************************************************


            //here write stats of your character , player1!
            Console.SetCursorPosition(xpos, ypos);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(creatures[0].name);
            ypos++;

            if (creatures[0].classInt == 0) { Console.WriteLine("attacker"); }
            else if (creatures[0].classInt == 1) { Console.WriteLine("defender"); }
            else if (creatures[0].classInt == 2) { Console.WriteLine("sorcerer"); }
            else if (creatures[0].classInt == 3) { Console.WriteLine("rogue"); }
            ypos++;
            Console.SetCursorPosition(0, ypos);

            if (creatures[0].raceInt == 0) { Console.WriteLine("goblin"); }
            else if (creatures[0].raceInt == 1) { Console.WriteLine("nightelf"); }
            else if (creatures[0].raceInt == 2) { Console.WriteLine("troll"); }
            else if (creatures[0].raceInt == 3) { Console.WriteLine("spirit"); }
            else if (creatures[0].raceInt == 4) { Console.WriteLine("human"); }

            Console.ForegroundColor = ConsoleColor.White;
            ypos++;
            Console.WriteLine("Strength: " + creatures[0].STR);
            ypos++;
            Console.WriteLine("Constitution: " + creatures[0].CON);
            ypos++;
            Console.WriteLine("Dexterity: " + creatures[0].DEX);
            ypos++;
            Console.WriteLine("Intel: " + creatures[0].INT);
            ypos++;
            Console.SetCursorPosition(xpos, ypos);
            Console.Write("▲ " + creatures[0].mp + "              "); // we needed to extend utf8 to write "♥" in console!
            //for each life u got, for loop and write "█" to make health bar!!
            Console.SetCursorPosition(0, ypos + 2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("♥ "); // we needed to extend utf8 to write "♥" in console!
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 40; i++)
            {
                if (i < creatures[0].health)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("█");  // wieviel leben hast du?
                    Console.ForegroundColor = ConsoleColor.White;
                }
                
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("█");  // wieviel leben hast du?
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            //*********************************************************************************************


            //and player 2
            ypos = 0;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xpos2, ypos);
            Console.WriteLine(creatures[1].name);
            ypos++;
            Console.SetCursorPosition(xpos2, ypos);

            if (creatures[1].classInt == 0) { Console.WriteLine("attacker"); }
            else if (creatures[1].classInt == 1) { Console.WriteLine("defender"); }
            else if (creatures[1].classInt == 2) { Console.WriteLine("sorcerer"); }
            else if (creatures[1].classInt == 3) { Console.WriteLine("rogue"); }

            ypos++;
            Console.SetCursorPosition(xpos2, ypos);

            if (creatures[1].raceInt == 0) { Console.WriteLine("goblin"); }
            else if (creatures[1].raceInt == 1) { Console.WriteLine("nightelf"); }
            else if (creatures[1].raceInt == 2) { Console.WriteLine("troll"); }
            else if (creatures[1].raceInt == 3) { Console.WriteLine("spirit"); }
            else if (creatures[1].raceInt == 4) { Console.WriteLine("human"); }

            Console.ForegroundColor = ConsoleColor.White;
            ypos++;
            Console.SetCursorPosition(xpos2, ypos);
            Console.WriteLine("Strength: " + creatures[1].STR);
            ypos++;
            Console.SetCursorPosition(xpos2, ypos);
            Console.WriteLine("Constitution: " + creatures[1].CON+"          ");
            ypos++;
            Console.SetCursorPosition(xpos2, ypos);
            Console.WriteLine("Dexterity: " + creatures[1].DEX);
            ypos++;
            Console.SetCursorPosition(xpos2, ypos);
            Console.WriteLine("Intel: " + creatures[1].INT);
            ypos++;
            Console.SetCursorPosition(xpos2, ypos);
            Console.Write("▲ " + creatures[1].mp + "              "); // we needed to extend utf8 to write "♥" in console!

            //for each life u got, for loop and write "█"
            Console.SetCursorPosition(xpos2, ypos + 2);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("♥ ");
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < 40; i++)
            {
                if (i < creatures[1].health)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("█");  // wieviel leben hast du?
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("█");  // wieviel leben hast du?
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }


            Console.WriteLine(" ");

            Console.WriteLine("player 1:"+creatures[0].weaponString + "[1], " + creatures[0].skillString+ "[2], "+ creatures[0].traitString+"[3], player 2:" + creatures[1].weaponString + "[1], " + creatures[1].skillString + "[2], " + creatures[1].traitString + "[3]");



            Console.WriteLine("────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────");
            Console.SetCursorPosition(0,19);
            Console.WriteLine("────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────");

        }


    }
}
