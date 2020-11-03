using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleSIM
{
    class troll : creature
    {
        private int critChance = 60;    //60% critical hit chance    
        private float critDamage = 80;  //80% more damage
        private int myChance;


        public troll(float health, float attackDamage, string name)
        {
            this.health = 40;
            this.dmg = attackDamage;
            this.name = name;
            traitString = "paralyze";
            mp = 10;
            this.STR = 6;
            this.CON = 7;
            this.INT = 3;
            this.DEX = 4;
        }

        public override void Skill(creature target)
        {
            if (mp>=3) {
                // troll bashes, makes enemy stunned chance 1/5, and different dmg calculation
                skillDMG = CON / 7 * 3;

                mp -= 3;

                Console.WriteLine("");
                musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/trait_bash.wav";
                musicPlayer.Play();
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Yellow;

                Console.WriteLine("the troll dealt (" + skillDMG + " damage) and crippled his enemy                   ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                target.TakeDamage(skillDMG);
                if (target.CON > 1)
                {
                    target.CON = target.CON - 1;
                }                // now add a stun effect to target
                manager.instance.yPositionBattleCursor++;
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
