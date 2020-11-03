using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace battleSIM
{
    class nightelf : creature
    {
        private int critChance = 60;    //60% critical hit chance    
        private float critDamage = 20;  //80% more damage



        public nightelf(float health, float attackDamage, string name)
        {
            this.health = 40;
            this.dmg = attackDamage;
            this.name = name;
            traitString = "longbow";
            mp = 10;

            this.STR = 5;
            this.CON = 4;
            this.INT = 6;
            this.DEX = 6;
        }

        public override void Skill(creature target)
        {
            if (mp >= 3) { 
                musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/trait_bow.wav";
            musicPlayer.Play();
            mp -= 3;

            Random chance = new Random();
            skillDMG = chance.Next(1, DEX) / 3 + DEX / 2;
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Yellow;
            //shoot an arrow!    
            Console.WriteLine("use bow and arrow, shoot first arrow (" + skillDMG + " dmg) and second arrow (" + skillDMG + " dmg)                       ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            float skillDMG2 = chance.Next(1, DEX) / 3 + DEX / 2;
            Console.WriteLine("");
            target.TakeDamage(skillDMG + skillDMG2);
            manager.instance.yPositionBattleCursor++;
            //arrows weaken the enemies con by 1 point! Cant be lower than 1..
            if (target.CON > 1)
            {
                target.CON = target.CON - 1;
            }
            Thread.Sleep(300);
            musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/trait_bow.wav";
            musicPlayer.Play();

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

