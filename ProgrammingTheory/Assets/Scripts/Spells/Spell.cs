using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : Character
{
    public float etherCost;
    public float delay;
    public float amountHealed;
    public string spellTitle;
    public virtual void CastSpell()
    {
    
    }
   
    public class HealSpell : Spell
    {

        void Start()
        {
            etherCost = 1;
            delay = 50;
            amountHealed = 30;
            spellTitle = "HealSpell";
        }
        public override void CastSpell()
        {
            ether -= etherCost;
            turnValue += delay;
            Heal(amountHealed);
        }
    }
    public class AttackSpell : Spell
    {
        void Start()
        {
            etherCost = 1;
            delay = 50;
            spellTitle = "AttackSpell";
        }
        public override void CastSpell()
        {
            ether -= etherCost;
            turnValue += delay;
            Attack(attackDamage, attackPower);
        }
    }
    public class DefendSpell : Spell
    {
        void Start()
        {
            etherCost = 1;
            delay = 50;
            spellTitle = "DefendSpell";
        }
        public override void CastSpell()
        {
            ether -= etherCost;
            turnValue += delay;
            Defend(defense);
        }
    }

}
