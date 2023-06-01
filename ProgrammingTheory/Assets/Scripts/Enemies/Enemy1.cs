using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy1 : Enemy
{
    void Start()
    {
        health = 100;
        baseHealth = 100;
        ether = 6;
        baseEther = 6;
        attackDamage = 1;
        attackPower = 1;
        defense = 1;
        speed = 1;
        agility = 15;
        title = "enemy1";
        isAlive = true;
        turnValue = 105;
        baseTurnValue = 100;
        characterIcon = gameObject.GetComponent<Image>();
    }
    //public List<Magic> magicAbilities = new List<Magic>();
}
