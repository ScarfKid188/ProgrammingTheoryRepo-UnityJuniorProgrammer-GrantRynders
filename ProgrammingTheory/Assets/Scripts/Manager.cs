using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Manager : MonoBehaviour
{
    //prefabs
    public GameObject hero1Object;
    public GameObject hero2Object;
    public GameObject hero3Object;
    public GameObject hero4Object;
    public GameObject enemy1Object;
    public GameObject enemy2Object;
    public GameObject enemy3Object;
    public GameObject enemy4Object;
    //scripts
    private Hero1 hero1;
    private Hero2 hero2;
    private Hero3 hero3;
    private Hero4 hero4;
    private Enemy1 enemy1;
    private Enemy2 enemy2;
    private Enemy3 enemy3;
    private Enemy4 enemy4;
    //turn bools
    public bool isE1Turn;
    public bool isE2Turn;
    public bool isE3Turn;
    public bool isE4Turn;
    public bool isH1Turn;
    public bool isH2Turn;
    public bool isH3Turn;
    public bool isH4Turn;
    public bool isHeroTurn;
    public bool isEnemyTurn;
    //target bools
    public bool isE1Targeted;
    public bool isE2Targeted;
    public bool isE3Targeted;
    public bool isE4Targeted;
    public bool isH1Targeted;
    public bool isH2Targeted;
    public bool isH3Targeted;
    public bool isH4Targeted;
    public List<bool> targets = new List<bool>();
    //turnOrder
    public List<float> turnOrder = new List<float>();
    public List<string> charOrder = new List<string>();
    public List<Image> charImage = new List<Image>();
    public GameObject slot0;
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;
    public GameObject slot5;
    public GameObject slot6;
    public GameObject slot7;
    public bool h1HasSlot;
    public bool h2HasSlot;
    public bool h3HasSlot;
    public bool h4HasSlot;
    public bool e1HasSlot;
    public bool e2HasSlot;
    public bool e3HasSlot;
    public bool e4HasSlot;
    //UI
    public GameObject mainBattleUI;
    public GameObject playerOptions;
    public Button attackButton;
    public Button defendButton;
    public Button runButton;
    public Button itemButton;
    public Button magicButton;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(hero1Object, new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10)), Quaternion.identity);
        Instantiate(hero2Object, new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10)), Quaternion.identity);
        Instantiate(hero3Object, new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10)), Quaternion.identity);
        Instantiate(hero4Object, new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10)), Quaternion.identity);
        Instantiate(enemy1Object, new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10)), Quaternion.identity);
        Instantiate(enemy2Object, new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10)), Quaternion.identity);
        Instantiate(enemy3Object, new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10)), Quaternion.identity);
        Instantiate(enemy4Object, new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10)), Quaternion.identity);
        hero1 = hero1Object.GetComponent < Hero1 > ();
        hero2 = hero2Object.GetComponent < Hero2 > ();
        hero3 = hero3Object.GetComponent < Hero3 > ();
        hero4 = hero4Object.GetComponent < Hero4 > ();
        enemy1 = enemy1Object.GetComponent < Enemy1 > ();
        enemy2 = enemy2Object.GetComponent < Enemy2 > ();
        enemy3 = enemy3Object.GetComponent < Enemy3 > ();
        enemy4 = enemy4Object.GetComponent < Enemy4 > ();
        Debug.Log("Objects Instantiated");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TurnOrder();
        }
    }
    public void HeroTurn()
    {
        playerOptions.gameObject.SetActive(true);
        if (isH1Turn)
        {
            Attack(hero1.attackDamage, hero1.attackPower);
            UpdateTurnValue(hero1.turnValue, hero1.baseTurnValue);
        }
        else if (isH2Turn)
        {
            Attack(hero2.attackDamage, hero2.attackPower);
            UpdateTurnValue(hero2.turnValue, hero2.baseTurnValue);
        }
        else if (isH3Turn)
        {
            Attack(hero3.attackDamage, hero3.attackPower);
            UpdateTurnValue(hero3.turnValue, hero3.baseTurnValue);
        }
        else if (isH4Turn)
        {
            Attack(hero4.attackDamage, hero4.attackPower);
            UpdateTurnValue(hero4.turnValue, hero4.baseTurnValue);
        }
    }
    public void EnemyTurn()
    {
        RandomTarget();
        if (isE1Turn)
        {
            Attack(enemy1.attackDamage, enemy1.attackPower);
            UpdateTurnValue(enemy1.turnValue, enemy1.baseTurnValue);
        }
        else if (isE2Turn)
        {
            Attack(enemy2.attackDamage, enemy2.attackPower);
            UpdateTurnValue(enemy2.turnValue, enemy2.baseTurnValue);
        }
        else if (isE3Turn)
        {
            Attack(enemy3.attackDamage, enemy3.attackPower);
            UpdateTurnValue(enemy3.turnValue, enemy3.baseTurnValue);
        }
        else if (isE4Turn)
        {
            Attack(enemy4.attackDamage, enemy4.attackPower);
            UpdateTurnValue(enemy4.turnValue, enemy4.baseTurnValue);
        }
        EndTurn();
    }
    public void RandomTarget()
    {
        targets.Clear();
        if (isEnemyTurn)
        {
            if (hero1.isAlive)
            {
                targets.Add(isH1Targeted);
            }
            if (hero2.isAlive)
            {
                targets.Add(isH2Targeted);
            }
            if (hero3.isAlive)
            {
                targets.Add(isH3Targeted);
            }
            if (hero4.isAlive)
            {
                targets.Add(isH4Targeted);
            }
        }
        else if (isHeroTurn)
        {
            if (enemy1.isAlive)
            {
                targets.Add(isE1Targeted);
            }
            if (enemy2.isAlive)
            {
                targets.Add(isE2Targeted);
            }
            if (enemy3.isAlive)
            {
                targets.Add(isE3Targeted);
            }
            if (enemy4.isAlive)
            {
                targets.Add(isE4Targeted);
            }
        }
        targets[Random.Range(0, targets.Count)] = true;
    }
    public void Attack(float attackDamage, float attackPower)
    {
        if (isE1Targeted)
        {
            enemy1.health = DealDamage(enemy1.agility, enemy1.health, enemy1.defense, attackDamage, attackPower);
            Debug.Log("e1health: " + enemy1.health);
        }
        else if (isE2Targeted)
        {
            enemy2.health = DealDamage(enemy2.agility, enemy2.health, enemy2.defense, attackDamage, attackPower);
        }
        else if (isE3Targeted)
        {
            enemy3.health = DealDamage(enemy3.agility, enemy3.health, enemy3.defense, attackDamage, attackPower);
        }
        else if (isE4Targeted)
        {
            enemy4.health = DealDamage(enemy4.agility, enemy4.health, enemy4.defense, attackDamage, attackPower);
        }
        else if (isH1Targeted)
        {
            hero1.health = DealDamage(hero1.agility, hero1.health, hero1.defense, attackDamage, attackPower);
        }
        else if (isH2Targeted)
        {
            hero2.health = DealDamage(hero2.agility, hero2.health, hero2.defense, attackDamage, attackPower);
        }
        else if (isH3Targeted)
        {
            hero3.health = DealDamage(hero3.agility, hero3.health, hero3.defense, attackDamage, attackPower);
        }
        else if (isH4Targeted)
        {
            hero4.health = DealDamage(hero4.agility, hero4.health, hero4.defense, attackDamage, attackPower);
        }
        else
        {
            Debug.Log("NO TARGET for attack ABORT ABORT");
        }
    }
    public float DealDamage(float agility, float health, float defense, float attackDamage, float attackPower)
    {
        float agilityValue = DidAttackHit(agility);
        return ((health * defense) - (attackDamage * attackPower * agilityValue));
    }
    public float DidAttackHit(float agility)
    {
        float randomNum = Random.Range(0, 100);
        if (randomNum <= agility)
        {
            return 1.0f;
        }
        else
        {
            return 0.0f;
        }
    }
    public float Defend(float defense)
    {
        return defense *= 2;
    }
    public void CreateTurnList()
    {
        Debug.Log("TurnListCreated");
        turnOrder.Clear();
        charOrder.Clear();
        charImage.Clear();
        if (hero1.isAlive)
        {
            turnOrder.Add(hero1.turnValue);
            charOrder.Add(null);
            charImage.Add(null);
        }
        if (hero2.isAlive)
        {
            turnOrder.Add(hero2.turnValue);
            charOrder.Add(null);
            charImage.Add(null);
        }
        if (hero3.isAlive)
        {
            turnOrder.Add(hero3.turnValue);
            charOrder.Add(null);
            charImage.Add(null);
        }
        if (hero4.isAlive)
        {
            turnOrder.Add(hero4.turnValue);
            charOrder.Add(null);
            charImage.Add(null);
        }
        if (enemy1.isAlive)
        {
            turnOrder.Add(enemy1.turnValue);
            charOrder.Add(null);
            charImage.Add(null);
        }
        if (enemy2.isAlive)
        {
            turnOrder.Add(enemy2.turnValue);
            charOrder.Add(null);
            charImage.Add(null);
        }
        if (enemy3.isAlive)
        {
            turnOrder.Add(enemy3.turnValue);
            charImage.Add(null);
            charOrder.Add(null);
        }
        if (enemy4.isAlive)
        {
            turnOrder.Add(enemy4.turnValue);
            charOrder.Add(null);
            charImage.Add(null);
        }
        turnOrder.Sort();
    }
    public void TurnOrder()
    {
        CreateTurnList();
        for (int i = 0; i < turnOrder.Count; i++)
        {
            while (charOrder[i] == null)
            {
                if (turnOrder[i] == hero1.turnValue && !h1HasSlot)
                {
                    charOrder[i] = hero1.title;
                    charImage[i] = hero1.characterIcon;
                    h1HasSlot = true;
                    if (i == 0)
                    {
                        isH1Turn = true;
                        HeroTurn();
                    }
                }
                else if (turnOrder[i] == hero2.turnValue && !h2HasSlot)
                {
                    charOrder[i] = hero2.title;
                    charImage[i] = hero2.characterIcon;
                    h2HasSlot = true;
                    if (i == 0)
                    {
                        isH2Turn = true;
                        HeroTurn();
                    }
                }
                else if (turnOrder[i] == hero3.turnValue && !h3HasSlot)
                {
                    charOrder[i] = hero3.title;
                    charImage[i] = hero3.characterIcon;
                    h3HasSlot = true;
                    if (i == 0)
                    {
                        isH3Turn = true;
                        HeroTurn();
                    }
                }
                else if (turnOrder[i] == hero4.turnValue && !h4HasSlot)
                {
                    charOrder[i] = hero4.title;
                    charImage[i] = hero4.characterIcon;
                    h4HasSlot = true;
                    if (i == 0)
                    {
                        isH4Turn = true;
                        HeroTurn();
                    }
                }
                else if (turnOrder[i] == enemy1.turnValue && !e1HasSlot)
                {
                    charOrder[i] = enemy1.title;
                    charImage[i] = enemy1.characterIcon;
                    e1HasSlot = true;
                    if (i == 0)
                    {
                        isE1Turn = true;
                        EnemyTurn();
                    }
                }
                else if (turnOrder[i] == enemy2.turnValue && !e2HasSlot)
                {
                    charOrder[i] = enemy2.title;
                    charImage[i] = enemy2.characterIcon;
                    e2HasSlot = true;
                    if (i == 0)
                    {
                        isE2Turn = true;
                        EnemyTurn();
                    }
                }
                else if (turnOrder[i] == enemy3.turnValue && !e3HasSlot)
                {
                    charOrder[i] = enemy3.title;
                    charImage[i] = enemy3.characterIcon;
                    e3HasSlot = true;
                    if (i == 0)
                    {
                        isE3Turn = true;
                        EnemyTurn();
                    }
                }
                else if (turnOrder[i] == enemy4.turnValue && !e4HasSlot)
                {
                    charOrder[i] = enemy4.title;
                    charImage[i] = enemy4.characterIcon;
                    e4HasSlot = true;
                    if (i == 0)
                    {
                        isE4Turn = true;
                        EnemyTurn();
                    }
                }
            }
        }
    }
    public float UpdateTurnValue(float turnValue, float baseTurnValue)
    {
        turnValue = turnValue + baseTurnValue;
        return turnValue;
    }
    public void EndTurn()
    {
        ClearTargets();
        TurnOrder();
    }
    public void ClearTargets()
    {
        isE1Targeted = false;
        isE2Targeted = false;
        isE3Targeted = false;
        isE4Targeted = false;
        isH1Targeted = false;
        isH2Targeted = false;
        isH3Targeted = false;
        isH4Targeted = false;
    }
    public void CreateBattleUI()
    {
        mainBattleUI.gameObject.SetActive(true);
    }
}