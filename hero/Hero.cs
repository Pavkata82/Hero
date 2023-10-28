using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hero
{
    class Hero
    {
        public string name;
        private int attack;
        private int shield;
        private int health;
        private int wins;
        public int originalHealth;

        Random rnd = new Random();

        public int Shield
        {
            get {return shield; }
            set {this.shield = value; }
        }
        public int Attack
        {
            get { return attack; }
            set { this.attack = value; }
        }
        public int Health
        {
            get { return health; }
            set { this.health = value; }
        }
        public int Wins
        {
            get { return wins; }
            set { this.wins = value; }
        }
        public Hero()
        {

        }
        public Hero(string name)
        {
            this.name = name;
            Attack = rnd.Next(50, 100);
            Shield = rnd.Next(10, 20);
            Health = rnd.Next(50, 100);
            this.originalHealth = Health;
            Wins = 0;
        }
        public Hero(string name, int attack, int shield, int health)
        {
            this.name = name;
            Attack = attack;
            Shield = shield;
            Health = health;
            this.originalHealth = Health;
            Wins = 0;
        }
        public void GetValues()
        {
            Console.Write("Enter name: ");
            this.name = Console.ReadLine();

            Console.Write("Enter attack: ");
            Attack = int.Parse(Console.ReadLine());

            Console.Write("Enter shield: ");
            Shield = int.Parse(Console.ReadLine());

            Console.Write("Enter health: ");
            Health = int.Parse(Console.ReadLine());
 
        }
        public virtual void Show()
        {
            Console.WriteLine($"Name: {this.name}");
            Console.WriteLine($"Attack: {this.attack}");
            Console.WriteLine($"Shield: {this.shield}");
            Console.WriteLine($"Health: {this.health}");
        }

        public virtual void Battle(Hero otherHero)
        {
            for (int i = 0; i < 1000; i++)
            {
                int attacker = rnd.Next(0, 2);

                if (this.IsAlive() && otherHero.IsAlive())
                {
                    if (attacker == 0)
                    {
                        otherHero.Health -= this.attack - otherHero.Shield;
                    }
                    else if (attacker == 1)
                    {
                        this.Health -= otherHero.attack - this.Shield;
                    }
                    
                }
                else if(this.IsAlive() && (otherHero.IsAlive() != true))
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
                else if((this.IsAlive() != true) && (otherHero.IsAlive() != true))
                {
                    Console.WriteLine("No one wins!");
                    break;
                }
            }

            this.health = originalHealth;

        }
        public bool IsAlive()
        {
            if (health <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
