using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hero1 : Hero
{
    void Start()
    {
    health = 100;
    baseHealth = 100;
    ether = 6;
    baseEther = 6;
    attackDamage = 50;
    attackPower = 1;
    defense = 1;
    speed = 1;
    agility = 15;
    title = "hero1";
    isAlive = true;
    //turnValue;
    baseTurnValue = 100;
    currentLevel = 1;
    currentExp = 0;
    characterIcon = gameObject.GetComponent< Image >();
    }
}
