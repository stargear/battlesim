using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleSIM
{
    class ghost:creature
    {
        private int critChance = 60;    //60% critical hit chance    
        private float critDamage = 80;  //80% more damage



        public ghost(float health, float attackDamage, string name)
        {
            this.health = 40;
            this.dmg = attackDamage;
            this.name = name;
            traitString = "lifedrain";
            mp = 10;

            this.STR = 4;
            this.CON = 3;
            this.INT = 7;
            this.DEX = 6;
        }

        public override void Skill (creature target)
        {
            if (mp >= 3)
            {
                musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/trait_drain.wav";
                musicPlayer.Play();
                Random chance = new Random();
                mp -= 3;

                Console.WriteLine("");
                skillDMG = (INT - 4 + mp / 4 + chance.Next(0, 2));

                // drain life and heal urself with it
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("the ghost drained " + skillDMG + "life, and gained " + skillDMG / 3 + " through this!                                   ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                target.TakeDamage(skillDMG);

                if (this.health < 20)
                {
                    this.healUrself(skillDMG / 3);
                    manager.instance.yPositionBattleCursor++;
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
