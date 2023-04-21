using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Character : MonoBehaviour
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
    public float turnValue;
    public float baseTurnValue;
    public float currentLevel;
    public float currentExp;
    public Image characterIcon;

    public class Spell : Character
    {
        public float etherCost;
        public float delay;

        public class HealSpell : Spell
        {
            void Start()
            {
                etherCost = 1;
                delay = 50;
            }
        }
        public class AttackSpell : Spell
        {
            void Start()
            {
                etherCost = 1;
                delay = 50;
            }
        }
        public class GuardSpell : Spell
        {
            void Start()
            {
                etherCost = 1;
                delay = 50;
            }
        }

    }
}
