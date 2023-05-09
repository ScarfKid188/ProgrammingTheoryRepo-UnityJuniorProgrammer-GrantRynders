using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Character : Manager
{
    public float health;
    public float baseHealth;
    public float ether;
    public float baseEther;
    public float attackDamage;
    public float attackPower;
    public float defense;
    public float speed;
    public float agility;
    public string title;
    public bool isAlive;
    public bool isTurn;
    public bool hasSlot;
    public bool isTargeted;
    public float turnValue;
    public float baseTurnValue;
    public float currentLevel;
    public float currentExp;
    public Image characterIcon;
    public class Spell : Character
    {
        public float etherCost;
        public float delay;
        public float amountHealed;
        public class HealSpell : Spell
        {
            
            void Start()
            {
                etherCost = 1;
                delay = 50;
                amountHealed = 30;
            }
            public void CastSpell()
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
            }
            public void CastSpell()
            {
                ether -= etherCost;
                turnValue += delay;
                Attack(attackDamage, attackPower);
            }
        }
        public class GuardSpell : Spell
        {
            void Start()
            {
                etherCost = 1;
                delay = 50;
            }
            public void CastSpell()
            {
                ether -= etherCost;
                turnValue += delay;
                Defend(defense);
            }
        }

    }
}
