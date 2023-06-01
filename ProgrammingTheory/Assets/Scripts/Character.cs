using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class Character : Manager
{
    private float m_health;
    public float health
    {
        get { return m_health; }
        set
        {
            if (value < 0.0f)
            {
                m_health = 0;
            }
            else
            {
                m_health = value;
            }
        }
    }
    public float baseHealth;
    private float m_ether;
    public float ether
    {
        get { return m_ether; }
        set
        {
            if (value < 0.0f)
            {
                m_ether = 0;
            }
            else
            {
                m_ether = value;
            }
        }
    }
    public float baseEther;
    public float attackDamage;
    public float attackPower;
    public float defense;
    public float speed;
    public float agility;
    public string title;
    public float baseTurnValue;
    public float currentLevel;
    public float currentExp;
    public Image characterIcon;
    public bool isAlive;
    public bool isTurn;
    public bool hasSlot;
    public bool isTargeted;
    public float turnValue;
    public Vector3 battlePos;
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
    }
    [System.Serializable]
    class SaveData
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
        public float baseTurnValue;
        public float currentLevel;
        public float currentExp;
        public Image characterIcon;
        public bool isAlive;
    }

    public void SaveCharStats()
    {
        
        SaveData data = new SaveData();
        data.health = health;
        data.baseHealth = baseHealth;
        data.ether = ether;
        data.baseEther = baseEther;
        data.attackDamage = attackDamage;
        data.attackPower = attackPower;
        data.defense = defense;
        data.speed = speed;
        data.agility = agility;
        data.title = title;
        data.baseTurnValue = baseTurnValue;
        data.currentLevel = currentLevel;
        data.currentExp = currentExp;
        data.characterIcon = characterIcon;
        data.isAlive = isAlive;
        Debug.Log("Saving " + title +"'s data...");
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + ("/savefile" + title + ".json"), json);
    }

    public void LoadCharStats()
    {
        
        string path = Application.persistentDataPath + ("/savefile" + title + ".json");
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            health = data.health;
            baseHealth = data.baseHealth;
            ether = data.ether;
            baseEther = data.baseEther;
            attackDamage = data.attackDamage;
            attackPower = data.attackPower;
            defense = data.defense;
            speed = data.speed;
            agility = data.agility;
            title = data.title;
            baseTurnValue = data.baseTurnValue;
            currentLevel = data.currentLevel;
            currentExp = data.currentExp;
            characterIcon = data.characterIcon;
            isAlive = data.isAlive;
            Debug.Log("Loading " + title + "'s data...");
        }
    }
    public void ResetStats()
    {
        health = baseHealth;
        ether = baseEther;
        isAlive = true;
    }
}
