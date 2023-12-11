using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generating_Patterns
{
    abstract class HeroFactory
    {
        public abstract Armor CreateArmor();
        public abstract Weapon CreateWeapon();
    }
    class ElfFactory : HeroFactory
    {
        public override Armor CreateArmor()
        {
            return new CopperArmor();
        }

        public override Weapon CreateWeapon()
        {
            return new Bow();
        }
    }
    class WarriorFactory : HeroFactory
    {
        public override Armor CreateArmor()
        {
            return new IronArmor();
        }

        public override Weapon CreateWeapon()
        {
            return new Sword();
        }
    }
    class Hero
    {
        private Weapon weapon;
        private Armor armor;
        public Hero(HeroFactory factory)
        {
            weapon = factory.CreateWeapon();
            armor = factory.CreateArmor();
        }
        public void Defend()
        {
            armor.Defend();
        }
        public void Hit()
        {
            weapon.Hit();
        }
    }
    abstract class Armor
    {
        public abstract void Defend();
    }
    abstract class Weapon
    {
        public abstract void Hit();
    }
    class IronArmor : Armor
    {
        public override void Defend()
        {
            Console.WriteLine("Iron Armor defend!");
        }
    }
    class CopperArmor : Armor
    {
        public override void Defend()
        {
            Console.WriteLine("Copper Armor defend!");
        }
    }
    class Sword : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Sword hit!");
        }
    }
    class Bow : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Bow hit!");
        }
    }
}
