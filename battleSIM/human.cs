using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace battleSIM
{
    class human: creature
    {
        private int critChance = 60;    //60% critical hit chance    
        private float critDamage = 80;  //80% more damage



        public human (float health, float attackDamage, string name)
        {
            this.health = 40;
            this.dmg = attackDamage;
            this.name = name;
            traitString = "handcannon";
            mp = 10;

            this.STR = 6;
            this.CON = 4;
            this.INT = 5;
            this.DEX = 5;
        }

        public override void Skill (creature target)
        {
            if (mp >= 3)
            {
                musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/trait_gun_shoot.wav";
                musicPlayer.Play();
                Random chance = new Random();
                skillDMG = DEX / 2 + chance.Next(1, STR);
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Yellow;
                //shoot an arrow!    
                mp -= 3;

                Console.WriteLine("use a wooden handcannon (" + skillDMG + " dmg) and reduce the enemies DEX                         ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                target.TakeDamage(skillDMG);
                manager.instance.yPositionBattleCursor++;
                //arrows weaken the enemies con by 1 point! Cant be lower than 1..
                if (target.DEX > 1)
                {
                    target.DEX = target.DEX - 1;
                }
                Console.WriteLine(" ");
                Thread.Sleep(300);
                musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/skill_missile_exp.wav";
                musicPlayer.Play();


                manager.instance.yPositionBattleCursor++;
            }
            else
            {
                Attack(target);
            }
        }
                
    }
}
