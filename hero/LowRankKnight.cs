using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hero
{
    class LowRankKnight : Knight
    {
        public int wins;

        public int rank;

        Random rnd = new Random();

        public LowRankKnight()
        {

        }

        public LowRankKnight(string name, int id)
        {
            this.name = name;
            this.wins = 0;
            this.id = id;
            this.rank = 0;
            this.Attack = rnd.Next(50, 100);
            this.Shield = rnd.Next(10, 20);
            this.Health = rnd.Next(50, 100); 
        }
        public LowRankKnight(string name, int id, int attack, int shield, int health)
        {
            this.name = name;
            this.wins = 0;
            this.id = id;
            this.rank = 0;
            this.Attack = attack;
            this.Shield = shield;
            this.Health = health;
        }

        public override void Show()
        {
            Console.WriteLine($"Id: {this.id}");
            Console.WriteLine($"Name: {this.name}");
            Console.WriteLine($"Attack: {this.Attack}");
            Console.WriteLine($"Shield: {this.Shield}");
            Console.WriteLine($"Health: {this.Health}");
            Console.WriteLine($"Wins: {this.wins}");
        }
        public void LRKnightBattle(LowRankKnight otherHero)
        {
            int otherHeroOriginalHealth = otherHero.Health;
            this.originalHealth = this.Health;

            for (int i = 0; i < 1000; i++)
            {
                int attacker = rnd.Next(0, 2);

                if (this.IsAlive() && otherHero.IsAlive())
                {
                    if (attacker == 0)
                    {
                        otherHero.Health -= Attack - otherHero.Shield;
                    }
                    else if (attacker == 1)
                    {
                        this.Health -= otherHero.Attack - this.Shield;
                    }

                }
                else if (this.IsAlive() && (otherHero.IsAlive() != true))
                {
                    Console.WriteLine(this.name + " Win");
                    Wins += 1;
                    break;
                }
                else if ((this.IsAlive() != true) && otherHero.IsAlive())
                {
                    Console.WriteLine(otherHero.name + " Win");
                    break;
                }
                else if ((this.IsAlive() != true) && (otherHero.IsAlive() != true))
                {
                    Console.WriteLine("No one wins!");
                    break;
                }
            }

            Health = this.originalHealth;
            otherHero.Health = otherHeroOriginalHealth;
        }
        public void BattleForRank()
        {
            LowRankKnight tempKnight = new LowRankKnight("Enemy", 1);
            LowRankKnight main = new LowRankKnight(this.name, this.id, this.Attack, this.Shield, this.Health);

            int oldWins = main.Wins;

            main.Battle(tempKnight);

            int newWins = main.Wins;


            if (oldWins < newWins)
            {
                this.wins += 1;
                Console.WriteLine($"{this.name} have {this.wins} win(s)!");
            }
            if (IsLowRankPromoted())
            {
                Console.WriteLine($"{this.name} is promoted to Knight!");

                this.rank = 1;

            }

            Console.WriteLine();
        }

        public bool IsLowRankPromoted()
        {
            return wins >= 3 ? true : false;
        }

    }
}
