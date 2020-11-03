using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleSIM
{
    class goblin: creature
    {
        private int critChance = 60;    //60% critical hit chance    
        private float critDamage = 20;  //80% more damage
        private int myChance;



        public goblin(float health, float attackDamage, string name)
        {
            this.health = 40;
            this.dmg = attackDamage;
            this.name = name;
            traitString = "slingshot";
            mp = 10;
            this.STR = 5;
            this.CON = 4;
            this.INT = 3;
            this.DEX = 7;
        }

        /*public override void Attack (creature target)
        {
            float newDmg = dmg / 100 * critDamage + dmg;
            target.TakeDamage(newDmg);
        }*/

        public override void Skill (creature target)
        {
            if (mp >= 3)
            {
                Random random = new Random();
                myChance = random.Next(1, 4);
                int dmg;
                mp -= 3;

                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Yellow;
                musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/trait_slingshot.wav";
                musicPlayer.Play();


                if (myChance > 1)
                {
                    int chance = random.Next(2, 5);
                    chance = chance * 2;
                    Console.WriteLine("the goblin hits well with the slingshot (" + chance + " dmg)                               ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    manager.instance.yPositionBattleCursor++;
                    // you hit very well!
                    target.TakeDamage(chance);
                }

                else
                {
                    Console.WriteLine("the goblin uses a slingshot and shoots itself accidentally                            ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    manager.instance.yPositionBattleCursor++;
                    //you hit yourself, dummy!
                    this.TakeDamage(0.8f);
                }
                Console.WriteLine(" ");
                manager.instance.yPositionBattleCursor++;
            }
            else
            {
                Attack(target);
            }
        }
    }
}
