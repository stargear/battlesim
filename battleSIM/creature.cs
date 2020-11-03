using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Media;


namespace battleSIM
{
    class creature
    {
        public SoundPlayer musicPlayer = new SoundPlayer();

        public float health = 40;
        public float maxHealth = 40;
        public float dmg = 7;
        public string name = "Goppel";
        public float mp = 10;

        public int DEX = 1;
        public int STR = 1;
        public int CON = 1;
        public int INT = 1;

        public int raceInt = 0;  // 0 == human, 1 == nightelf, 2 == goblin, 3 == troll, 4 == ghost
        public int classInt = 0; // 0 == attacker, 1 == defender, 2 == mage, 3 == rogue

        public bool stunned = false;
        public bool IsDied = false;
        public float myDMG;
        public float skillDMG=3;

        public string weaponString;
        public string skillString;
        public string traitString;

        public virtual void Attack(creature target)
        {

            if (stunned == false)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Yellow;
                if (classInt == 0) //this is an attacker
                {
                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/att_sword.wav";
                    musicPlayer.Play();
                    myDMG = dmg / 7 * STR+CON/target.CON;
                    Console.WriteLine("\n" + name + " attacks with a sword (" + myDMG + " damage)                        ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    manager.instance.yPositionBattleCursor++;
                    target.TakeDamage(myDMG);
                }
                if (classInt == 1) //this is a defender
                {
                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/att_mace.wav";
                    musicPlayer.Play();
                    myDMG = dmg / 8 * CON+STR / target.CON;
                    Console.WriteLine("\n" + name + " attacks with a mace (" + myDMG + " damage)                           ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    manager.instance.yPositionBattleCursor++;
                    target.TakeDamage(myDMG);
                }
                if (classInt == 2) //this is a mage
                {
                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/att_staff.wav";
                    musicPlayer.Play();
                    myDMG = dmg / target.INT * INT+DEX / target.CON;
                    Console.WriteLine("\n" + name + " attacks with a staff (" + myDMG + " damage)                                ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    manager.instance.yPositionBattleCursor++;
                    target.TakeDamage(myDMG);
                }
                if (classInt == 3) //this is a rogue
                {
                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/att_dagger.wav";
                    musicPlayer.Play();
                    myDMG = dmg / 6 * DEX+STR / target.CON;
                    Console.WriteLine("\n" + name + " attacks with a dagger (" + myDMG + " damage)                               ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    manager.instance.yPositionBattleCursor++;
                    target.TakeDamage(myDMG);
                }


                //Console.WriteLine(" ");
                manager.instance.yPositionBattleCursor++;




            }
        }

        // to make it better use divide by target.CON or target.DEX!!

        public virtual void classSkill (creature target)
        {

            if (stunned == false)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Yellow;

                if (classInt == 0 && mp > 7) //this is an attacker - fatalattack
                {
                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/skill_fatalattack.wav";
                    musicPlayer.Play();
                    Random chance = new Random();
                    myDMG = (STR + chance.Next(-2, 4));
                    Console.WriteLine("\n" + name + " launches a fatal sword attack (" + myDMG + " damage)                                                 ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    manager.instance.yPositionBattleCursor++;
                    target.TakeDamage(myDMG);
                    mp -= 7;
                    return;
                }
                else if (classInt == 1 && mp > 6) //this is a defender - triple attack
                {
                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/att_mace.wav";
                    musicPlayer.Play();
                    Random chance = new Random();
                    myDMG = CON / 4 + chance.Next(0, 2);
                    int secondDMG = CON / 4 + chance.Next(0, 2);
                    int thirdDMG = CON / 3 + chance.Next(0, 2);
                    Console.WriteLine("\n" + name + " hits (" + myDMG  + " damage),  hits (" + secondDMG + " damage), hits (" + thirdDMG +  " damage)                ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    manager.instance.yPositionBattleCursor++;
                    target.TakeDamage(myDMG+secondDMG+thirdDMG);
                    mp -= 7;
                    Thread.Sleep(200);
                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/att_mace.wav";
                    musicPlayer.Play();
                    Thread.Sleep(200);
                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/att_mace.wav";
                    musicPlayer.Play();
                    return;



                }
                else if (classInt == 2 && mp > 6) //this is a mage - magic missile
                {
                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/skill_missile_homing.wav";
                    musicPlayer.Play();
                    Random chance = new Random();
                    myDMG = (INT-3 + mp/4+chance.Next(0, 5));
                    Console.WriteLine("\n" + name + " shoots a magic projectile (" + myDMG + " damage)                                             ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    manager.instance.yPositionBattleCursor++;
                    target.TakeDamage(myDMG);
                    mp -= 7;
                    Thread.Sleep(400);
                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/skill_missile_exp.wav";
                    musicPlayer.Play();
                    return;
                }
                else if (classInt == 3 && mp > 8) //this is a rogue - backstab
                {
                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/skill_backstab.wav";
                    musicPlayer.Play();
                    Random chance = new Random();
                    myDMG = DEX/3*2 + mp / 3;
                    Console.WriteLine("\n" + name + " stabs the enemy brutally (" + myDMG + " damage)                                           ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    manager.instance.yPositionBattleCursor++;
                    target.TakeDamage(myDMG);
                    mp -= 7;
                    return;
                }
                else
                {

                    Attack(target);
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                //Console.WriteLine(" ");
                manager.instance.yPositionBattleCursor++;




            }
        }


        public virtual void Skill(creature target)
        {
            Console.Write("");
            target.TakeDamage(skillDMG);
            mp = mp - 3;

        }

        public void TakeDamage(float damage)
        {
            health -= damage;
            Console.WriteLine("\n" + name + " has " + health + " left.");
            Console.WriteLine(" ");
            manager.instance.yPositionBattleCursor++;
            
            if (health <= 0)
            {
                Die();

            SoundPlayer musicPlayer5 = new SoundPlayer();
            musicPlayer5.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/menu_error.wav";
            musicPlayer5.Play();
            }
        }

        public void healUrself(float healing)
        {
            health += healing;

            Console.WriteLine("\n" + name + " has " + health + " left.");
            manager.instance.yPositionBattleCursor++;
            if (health <= 0)
            {
                Die();
            }
        }

        public void getStunned()
        {
            Console.WriteLine("this " + name + "is stunned now!");
            stunned = true;
            manager.instance.yPositionBattleCursor++;
            //if this was player 1 who stunned you
            if (manager.instance.turns == true)
            {
                manager.instance.turns = false;
                manager.instance.turns = true;
                Console.WriteLine("player 1 skips a turn");
                stunned = true;
                manager.instance.yPositionBattleCursor++;
            }
            //if this was player 2 who stunned you
            else if (manager.instance.turns == false)
            {
                manager.instance.turns = true;
                manager.instance.turns = false;
                Console.WriteLine("player 2 skips a turn");
                stunned = true;
                manager.instance.yPositionBattleCursor++;
            }

            
        }

        public void Die()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine(name + " died. GAME OVER!");
            IsDied = true;
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Thread.Sleep(4300);


            Console.ReadKey();
            Console.ReadKey();

            Console.SetWindowSize(240, 63);
            Console.Clear();
            musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/02_gameover.wav";
            musicPlayer.Play();




            Console.WriteLine(name + " died");









            Console.WriteLine("                                                                 ");
            Console.WriteLine("                                                                 ");
            Console.WriteLine("                                                                                                                     ");
            Console.WriteLine("                                                                                                                     ");
            Console.WriteLine("                                                                                                                     ");
            Console.WriteLine("                           *#########(((#(             ..            /#####.         ,##(                       .*,   ");
            Console.WriteLine("                          ,############((##           .####.          /#(####/      .####(.          .,//(######((#/   ");
            Console.WriteLine("                        .#(((####.  *(#####         .##((((##.        /########,   /######, /(######((##(#######(##/   ");
            Console.WriteLine("                      .(#######,                  .############,      /#########(######(##* (###((((((##((######(##(      ");
            Console.WriteLine("                     ####(##*    ..........     /##((###########,    /##(###########(####( *(#((((##((#(#######(((*          ");
            Console.WriteLine("                    ,##(((###.    /((#######,   *#((##((##########/   /###################(.,###(##((((#/                       ");
            Console.WriteLine("                    ,#((##(##.    (#########,  .##(((#/   .#((#(##/   /###((############(##,.(#((####(((###(###                   ");
            Console.WriteLine("                    ,#(((##(#/.        ,###%, .(#((###*   .#(((((#/   (###((((#######*#((##/ (((####((((##(((##                     ");
            Console.WriteLine("                    ,#((((((((##(((((#(####%* /################((#/  ,#(((##.*##((#* ,#(((#( /########(##(/*,.                       ");
            Console.WriteLine("                    .##(#(((((((((###(#####%*,#(###########((#(((#/ ./##((#/  /##(.  .#((#(#.*##(#(###(                               ");
            Console.WriteLine("                      , (((((((((((((((((###/.##(#######((#####(((#/ *##(((#,   /*    .#(#((#,,##(##(((((((########,                   ");
            Console.WriteLine("                        ,#(((((((((((#####, (#(((#####   ,#((((((#/ (##((##.         .#((((#/.(#####((#(##(((((###,                    ");
            Console.WriteLine("                          *#(#((((((#(##/  /#((((((((    ,##((((##/,#(((##/          .#((((#(.(####((#########(###,                    ");
            Console.WriteLine("                             .######*           .*(%/     .*                          .,//(.              .,/*                         ");
            Console.WriteLine("                            (#(((((((#*    ,###((((##.    *###*          ..,*((####(#######.      .,/(#####((##/                       ");
            Console.WriteLine("                          /#(((((((((#(#*   /#######%*    (#((###/.*########((((((#########./###########((((((###*                          ");
            Console.WriteLine("                        *#(((((#/.*#(((((#(  (#((#####.  .(((((((#(,##((((((((#############.#############(##(###(##*                     ");
            Console.WriteLine("                      ,#(((((#(    ,#((((((#*.#((((((#*  ,##((####..(((((####((#####(((/*,. (########.  ,####((((((#,                    ");
            Console.WriteLine("                    .((((((#(.      ,##((((#* .#((((((#. /%#(((##,  (##((((((((#,.....      (########.     /#((#####,                      ");
            Console.WriteLine("                    *#((((((#(.     (##((((#*  ,#((((##* ((#####*   /#(###############,     *########.     /######%/                         ");
            Console.WriteLine("                    *#((((((((#/   (#(((((##*   *##(((((,#((###/    *######((########%*     *#######%.    ,#(((##*                              ");
            Console.WriteLine("                     ,#(((((((((#((##((#(((#*    /#((#(((((((#(     ,######((##(/,.         ,%#########((((####*                                   ");
            Console.WriteLine("                       ,#(((((#((((#((((###.      (##((((((((#.      /########,....,,,,,,.  .%##############%/                                     ");
            Console.WriteLine("                        .(#(((#((((((((#(.        .######(((#/       *###################(  .%###############/.                                    ");
            Console.WriteLine("                          .(((((####((#.           ,#(#(####(        ,%##################(  .###############(####(*                                ");
            Console.WriteLine("                                                    /#(#####.        .(((((((((((((((((((/   ((((####(./#(((##((###(                               ");
            Console.WriteLine("                                                     /####%.                                 /#(((((/     *########(                               ");



           
            //battleSIM.ExecutablePath);





















        }
    }
}
