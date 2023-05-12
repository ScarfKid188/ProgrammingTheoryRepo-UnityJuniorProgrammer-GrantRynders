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
    public List<Spell> charSpells = new List<Spell>();

    public GameObject managerObject;
    public Manager manager;
    public Spell spell;
    public Spell attackSpell;
    void Start()
    {
        managerObject = GameObject.Find("Manager");
        manager = managerObject.GetComponent<Manager>();
        spell = managerObject.GetComponent<Spell>();
        //charSpells.Add(Spell.AttackSpell);
        //charSpells.Add(Spell.DefendSpell);
        //charSpells.Add(Spell.HealSpell);
    }

}
