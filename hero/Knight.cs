using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hero
{
    class Knight : Hero
    {
        public int id;

        Random rnd = new Random();
        public Knight()
        { 
            
        }
        public Knight(string name, int id)
        {
            this.name = name;
            this.Attack = rnd.Next(50, 100);
            this.Shield = rnd.Next(10, 20);
            this.Health = rnd.Next(50, 100);
            this.id = id;
        }

        public Knight(string name, int id, int attack, int shield, int health)
        {
            this.name = name;
            this.id = id;
            this.Attack = attack;
            this.Shield = shield;
            this.Health = health;
        }
        public override void Show()
        {
            Console.WriteLine($"Id: {this.id}");
            base.Show();
        }

        public void GetValues()
        {
            Console.Write("Enter id: ");
            this.id = int.Parse(Console.ReadLine());

            base.GetValues();
        }
        public void KnightBattle(Knight otherHero)
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
    }
}
