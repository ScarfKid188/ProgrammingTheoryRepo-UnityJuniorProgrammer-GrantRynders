using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Manager : MonoBehaviour
{
    //prefabs
    public GameObject hero1Prefab;
    public GameObject hero2Prefab;
    public GameObject hero3Prefab;
    public GameObject hero4Prefab;
    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;
    public GameObject enemy3Prefab;
    public GameObject enemy4Prefab;
    //scene gameobjects
    public GameObject targetObject;
    public GameObject cameraAxis;
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
    private battleCamera battleCamera;
    //turnOrder
    public List<float> turnOrder = new List<float>(); // list of character turnValues
    public List<Character> charOrder = new List<Character>(); // list of characters to help visualize what's happening, get active character
    public List<Image> charImage = new List<Image>(); //list of character icons
    public List<GameObject> slotsList = new List<GameObject>(); // list of the slot gameObjects that aligns with charImage
    public bool isHeroTurn;
    public bool isEnemyTurn;
    public GameObject slot0;
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;
    public GameObject slot5;
    public GameObject slot6;
    public GameObject slot7;
    public Sprite defaultSprite;
    //UI
    public GameObject mainBattleUI;
    public GameObject playerOptions;
    public Button attackButton;
    public Button defendButton;
    public Button runButton;
    public Button itemButton;
    public Button magicButton;
    public Dropdown magicDropdown;
    public GameObject h1Stats;
    public GameObject h2Stats;
    public GameObject h3Stats;
    public GameObject h4Stats;
    public TextMeshProUGUI h1HealthText;
    public GameObject h1HealthBar;
    public TextMeshProUGUI h1EtherText;
    public GameObject h1EtherBar;
    public TextMeshProUGUI h1LevelText;
    public GameObject h1ExpBar;
    public TextMeshProUGUI h1TitleText;
    public GameObject h1IconObject;
    public Image h1Icon;
    public TextMeshProUGUI h2HealthText;
    public GameObject h2HealthBar;
    public TextMeshProUGUI h2EtherText;
    public GameObject h2EtherBar;
    public TextMeshProUGUI h2LevelText;
    public GameObject h2ExpBar;
    public TextMeshProUGUI h2TitleText;
    public GameObject h2IconObject;
    public Image h2Icon;
    public TextMeshProUGUI h3HealthText;
    public GameObject h3HealthBar;
    public TextMeshProUGUI h3EtherText;
    public GameObject h3EtherBar;
    public TextMeshProUGUI h3LevelText;
    public GameObject h3ExpBar;
    public TextMeshProUGUI h3TitleText;
    public GameObject h3IconObject;
    public Image h3Icon;
    public TextMeshProUGUI h4HealthText;
    public GameObject h4HealthBar;
    public TextMeshProUGUI h4EtherText;
    public GameObject h4EtherBar;
    public TextMeshProUGUI h4LevelText;
    public GameObject h4ExpBar;
    public TextMeshProUGUI h4TitleText;
    public GameObject h4IconObject;
    public Image h4Icon;
    //vectors
    public Vector3 h1Pos;
    public Vector3 h2Pos;
    public Vector3 h3Pos;
    public Vector3 h4Pos;
    public Vector3 e1Pos;
    public Vector3 e2Pos;
    public Vector3 e3Pos;
    public Vector3 e4Pos;
    public Vector3 targetOffset;
    //general
    public List<Character> heroes = new List<Character>();
    public List<Character> enemies = new List<Character>();
    public List<Character> participants = new List<Character>(); // list of all active Characters in battle
    public List<Character> targets = new List<Character>(); // list of all targeted Characters
    // Start is called before the first frame update
    void Start()
    {
        //set char pos
        h1Pos = new Vector3(5, 0, 5);
        h2Pos = new Vector3(10, 0, 5);
        h3Pos = new Vector3(15, 0, 5);
        h4Pos = new Vector3(20, 0, 5);
        e1Pos = new Vector3(5, 0, -5);
        e2Pos = new Vector3(10, 0, -5);
        e3Pos = new Vector3(15, 0, -5);
        e4Pos = new Vector3(20, 0, -5);
        targetOffset = new Vector3(0, 5, 0);
        //Instantiate character prefabs
        hero1Object = Instantiate(hero1Prefab, h1Pos, Quaternion.identity);
        hero1Object.gameObject.tag = "hero1";
        hero2Object = Instantiate(hero2Prefab, h2Pos, Quaternion.identity);
        hero2Object.gameObject.tag = "hero2";
        hero3Object = Instantiate(hero3Prefab, h3Pos, Quaternion.identity);
        hero3Object.gameObject.tag = "hero3";
        hero4Object = Instantiate(hero4Prefab, h4Pos, Quaternion.identity);
        hero4Object.gameObject.tag = "hero4";
        enemy1Object = Instantiate(enemy1Prefab, e1Pos, Quaternion.identity);
        enemy1Object.gameObject.tag = "enemy1";
        enemy2Object = Instantiate(enemy2Prefab, e2Pos, Quaternion.identity);
        enemy2Object.gameObject.tag = "enemy2";
        enemy3Object = Instantiate(enemy3Prefab, e3Pos, Quaternion.identity);
        enemy3Object.gameObject.tag = "enemy3";
        enemy4Object = Instantiate(enemy4Prefab, e4Pos, Quaternion.identity);
        enemy4Object.gameObject.tag = "enemy4";
        //get char scripts
        hero1 = hero1Object.GetComponent < Hero1 > ();
        hero2 = hero2Object.GetComponent < Hero2 > ();
        hero3 = hero3Object.GetComponent < Hero3 > ();
        hero4 = hero4Object.GetComponent < Hero4 > ();
        enemy1 = enemy1Object.GetComponent < Enemy1 > ();
        enemy2 = enemy2Object.GetComponent < Enemy2 > ();
        enemy3 = enemy3Object.GetComponent < Enemy3 > ();
        enemy4 = enemy4Object.GetComponent < Enemy4 > ();
        //participants list
        heroes.Add(hero1);
        heroes.Add(hero2);
        heroes.Add(hero3);
        heroes.Add(hero4);
        enemies.Add(enemy1);
        enemies.Add(enemy2);
        enemies.Add(enemy3);
        enemies.Add(enemy4);
        foreach (Character hero in heroes)
        {
            participants.Add(hero);
        }
        foreach (Character enemy in enemies)
        {
            participants.Add(enemy);
        }
        
        //iconSlots list
        slotsList.Add(slot0);
        slotsList.Add(slot1);
        slotsList.Add(slot2);
        slotsList.Add(slot3);
        slotsList.Add(slot4);
        slotsList.Add(slot5);
        slotsList.Add(slot6);
        slotsList.Add(slot7);
        //other scripts
        battleCamera = cameraAxis.GetComponent < battleCamera > ();
        //initiate basic UI
        h1LevelText.text = hero1.currentLevel.ToString();
        h1TitleText.text = hero1.title;
        h1Icon = h1IconObject.GetComponent<Image>();
        h1Icon.sprite = hero1Object.GetComponent<Image>().sprite;
        h2LevelText.text = hero2.currentLevel.ToString();
        h2TitleText.text = hero2.title;
        h2Icon = h2IconObject.GetComponent<Image>();
        h2Icon.sprite = hero2Object.GetComponent<Image>().sprite;
        h3LevelText.text = hero3.currentLevel.ToString();
        h3TitleText.text = hero3.title;
        h3Icon = h3IconObject.GetComponent<Image>();
        h3Icon.sprite = hero3Object.GetComponent<Image>().sprite;
        h4LevelText.text = hero4.currentLevel.ToString();
        h4TitleText.text = hero4.title;
        h4Icon = h4IconObject.GetComponent<Image>();
        h4Icon.sprite = hero4Object.GetComponent<Image>().sprite;
        UpdateStatsUI();
        //initiate turn order
        TurnOrder();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TurnOrder();
        }
        if (isEnemyTurn)
        {
            if (enemy1.isTurn)
            {
                battleCamera.CircleCharacter(enemy1Object);
            }
            if (enemy2.isTurn)
            {
                battleCamera.CircleCharacter(enemy2Object);
            }
            if (enemy3.isTurn)
            {
                battleCamera.CircleCharacter(enemy3Object);
            }
            if (enemy4.isTurn)
            {
                battleCamera.CircleCharacter(enemy4Object);
            }
        }
        if (isHeroTurn)
        {
            if (hero1.isTurn)
            {
                battleCamera.CircleCharacter(hero1Object);
            }
            if (hero2.isTurn)
            {
                battleCamera.CircleCharacter(hero2Object);
            }
            if (hero3.isTurn)
            {
                battleCamera.CircleCharacter(hero3Object);
            }
            if (hero4.isTurn)
            {
                battleCamera.CircleCharacter(hero4Object);
            }
            if (Input.GetKeyDown(KeyCode.Q) && enemy1.isAlive)
            {
                ClearTargets();
                targets.Add(enemy1);
                enemy1.isTargeted = true;
                targetObject.gameObject.SetActive(true);
                targetObject.transform.position = e1Pos + targetOffset;

            }
            if (Input.GetKeyDown(KeyCode.W) && enemy2.isAlive)
            {
                ClearTargets();
                targets.Add(enemy2);
                enemy2.isTargeted = true;
                targetObject.gameObject.SetActive(true);
                targetObject.transform.position = e2Pos + targetOffset;
            }
            if (Input.GetKeyDown(KeyCode.E) && enemy3.isAlive)
            {
                ClearTargets();
                targets.Add(enemy3);
                enemy3.isTargeted = true;
                targetObject.gameObject.SetActive(true);
                targetObject.transform.position = e3Pos + targetOffset;
            }
            if (Input.GetKeyDown(KeyCode.R) && enemy4.isAlive)
            {
                ClearTargets();
                targets.Add(enemy4);
                enemy4.isTargeted = true;
                targetObject.gameObject.SetActive(true);
                targetObject.transform.position = e4Pos + targetOffset;
            }
            if (Input.GetKeyDown(KeyCode.T) && hero1.isAlive)
            {
                ClearTargets();
                targets.Add(hero1);
                hero1.isTargeted = true;
                targetObject.gameObject.SetActive(true);
                targetObject.transform.position = h1Pos + targetOffset;

            }
            if (Input.GetKeyDown(KeyCode.Y) && hero2.isAlive)
            {
                ClearTargets();
                targets.Add(hero2);
                hero2.isTargeted = true;
                targetObject.gameObject.SetActive(true);
                targetObject.transform.position = h2Pos + targetOffset;
            }
            if (Input.GetKeyDown(KeyCode.U) && hero3.isAlive)
            {
                ClearTargets();
                targets.Add(hero3);
                hero3.isTargeted = true;
                targetObject.gameObject.SetActive(true);
                targetObject.transform.position = h3Pos + targetOffset;
            }
            if (Input.GetKeyDown(KeyCode.I) && enemy4.isAlive)
            {
                ClearTargets();
                targets.Add(hero4);
                hero4.isTargeted = true;
                targetObject.gameObject.SetActive(true);
                targetObject.transform.position = h4Pos + targetOffset;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                HeroAttack();
            }
        }
    }
    public void HeroTurn()
    {
        isHeroTurn = true;
        playerOptions.gameObject.SetActive(true);
    }
    public void EnemyTurn()
    {
        isEnemyTurn = true;
        RandomTarget();
        foreach (Character enemy in enemies)
        {
                if (enemy.isTurn)
                {
                    Attack(enemy.attackDamage, enemy.attackPower);

                }
        }
        EndTurn();
    }
    public void RandomTarget()
    {
        ClearTargets();
        if (isEnemyTurn)
        {
            foreach (Character hero in heroes)
            {
                if (hero.isAlive)
                {
                    targets.Add(hero);
                }
            }
        }
        else if (isHeroTurn)
        {
            foreach (Character enemy in enemies)
            {
                if (enemy.isAlive)
                {
                    targets.Add(enemy);
                }
            }
        }  
        int target = Random.Range(0, targets.Count - 1);
        targets[target].isTargeted = true;
        
    }
    public void HeroAttack()
    {
        if (targets.Count > 0)
        {
            foreach (Character hero in heroes)
            {
                if (hero.isTurn)
                {
                    Attack(hero.attackDamage, hero.attackPower);

                }
            }
        }
        else
        {
            Debug.Log("No target for heroAttack");
        }
    }
    public void Attack(float attackDamage, float attackPower)
    {
        foreach (Character participant in participants)
        {
            if (participant.isTargeted)
            {
                participant.health = DealDamage(participant.agility, participant.health, participant.defense, attackDamage, attackPower);
                Debug.Log(participant.title + " health: " + participant.health);
                EndTurn();
            }
        }
    }
    public float DealDamage(float agility, float health, float defense, float attackDamage, float attackPower)
    {
        float agilityValue = DidAttackHit(agility);
        float damageDealt = (attackDamage * attackPower * agilityValue / defense);
Debug.Log(charOrder[0] + "dealt " + damageDealt + " damage");
        return (health - damageDealt);
    }
    public float DidAttackHit(float agility)
    {
        float randomNum = Random.Range(0, 100);
        if (randomNum >= agility)
        {
            return 1.0f;
        }
        else
        {
Debug.Log( charOrder[0] + "'s attack missed" + agility + randomNum);
            return 0.0f;
        }
    }
    public void Defend(float defenseBuff)
    {
        if (targets.Count > 0)
        {
            defenseBuff = 2; //placeholder
            foreach (Character participant in participants)
            {
                if (participant.isTargeted)
                {
                    participant.defense = DefendAmount(participant.defense, defenseBuff);
                    EndTurn();
                }
            }
        }
        else
        {
            Debug.Log("No target for defend");
        }
    }
    public float DefendAmount(float defense, float defenseBuff)
    {
        return defense *= defenseBuff;
    }
    public void Heal(float amountHealed)
    {
        if (targets.Count > 0)
        {
            foreach (Character participant in participants)
            {
                if (participant.isTargeted)
                {
                    participant.health = HealAmount(participant.health, participant.baseHealth, amountHealed);
                    EndTurn();
                }
            }
        }
        else
        {
            Debug.Log("No target for heal");
        }
    }
    public float HealAmount(float health, float baseHealth, float amountHealed)
    {
        health += amountHealed;
        if (health > baseHealth)
        {
            health = baseHealth;
        }
        return health;
    }
    //public void UseSpell(int index)
    //{
    //    index = magicDropdown.value;
    //    GenerateSpellList();
    //}
    //public void GenerateSpellList()
    //{
    //    List<string> magicDropOptions = new List<string>();
    //    foreach (Spell spell in charOrder[0].charSpells)
    //    {
    //        magicDropOptions.Add(spell.spellTitle);
    //    }
    //    magicDropdown.AddOptions(magicDropOptions);
    //}
    public void CreateTurnList()
    {
        Debug.Log("TurnListCreated");
        turnOrder.Clear();
        charOrder.Clear();
        charImage.Clear();
        foreach (Character participant in participants)
        {
            participant.hasSlot = false;
        }
        Debug.Log("cleared all turn slot properties");
        foreach (Character participant in participants)
        {
            if (participant.isAlive)
            {
                turnOrder.Add(participant.turnValue);
                charOrder.Add(null);
                charImage.Add(null);
            }
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
                foreach (Character participant in participants)
                {
                    if (turnOrder[i] == participant.turnValue && !participant.hasSlot)
                    {
                        charOrder[i] = participant;
                        charImage[i] = participant.characterIcon;
                        participant.hasSlot = true;
                        if (i == 0)
                        {
                            participant.isTurn = true;
                            if (participant is Hero)
                            {
                                HeroTurn();
                            }
                            if (participant is Enemy)
                            {
                                EnemyTurn();
                            }
                        }
                    }
                }
            }
        }
        SetSlotImages();
        Debug.Log("It is " + charOrder[0] + "'s turn");
    }
    public float UpdateTurnValue(float turnValue, float baseTurnValue)
    {
        turnValue += baseTurnValue;
        return turnValue;
    }
    public void SetSlotImages()
    {
        foreach (GameObject slot in slotsList)
        {
            slot.GetComponent<Image>().sprite = defaultSprite;
        }
        for (int i = 0; i < charImage.Count; i++)
        {
            slotsList[i].GetComponent<Image>().sprite = charImage[i].sprite;
        }
    }
    public void EndTurn()
    {
        charOrder[0].turnValue = UpdateTurnValue(charOrder[0].turnValue, charOrder[0].baseTurnValue);
        Debug.Log(charOrder[0] + "'s turnValue is now " + charOrder[0].turnValue);
        Debug.Log("It is the end of " + charOrder[0] + "'s turn");
        playerOptions.gameObject.SetActive(false);
        ClearTargets();
        ClearTurnBool();
        CheckIfCharsAreDead();
        UpdateStatsUI();
        TurnOrder();
    }
    public void ClearTargets()
    {
        
        targets.Clear();
        targetObject.gameObject.SetActive(false);
        foreach (Character participant in participants)
        {
            participant.isTargeted = false;
        }
    }
    public void ClearTurnBool()
    {
        isHeroTurn = false;
        isEnemyTurn = false;
        foreach (Character participant in participants)
        {
            participant.isTurn = false;
        }
    }
    public void CreateBattleUI()
    {
        mainBattleUI.gameObject.SetActive(true);
    }
    public void UpdateStatsUI()
    {
        h1HealthText.text = hero1.health.ToString() + "/" + hero1.baseHealth.ToString();
        h1EtherText.text = hero1.ether.ToString() + "/" + hero1.baseEther.ToString();
        h2HealthText.text = hero2.health.ToString() + "/" + hero2.baseHealth.ToString();
        h2EtherText.text = hero2.ether.ToString() + "/" + hero2.baseEther.ToString();
        h3HealthText.text = hero3.health.ToString() + "/" + hero3.baseHealth.ToString();
        h3EtherText.text = hero3.ether.ToString() + "/" + hero3.baseEther.ToString();
        h4HealthText.text = hero4.health.ToString() + "/" + hero4.baseHealth.ToString();
        h4EtherText.text = hero4.ether.ToString() + "/" + hero4.baseEther.ToString();
        h1HealthBar.GetComponent<Image>().fillAmount = Mathf.Clamp(hero1.health / hero1.baseHealth, 0 , 1.0f);
        h2HealthBar.GetComponent<Image>().fillAmount = Mathf.Clamp(hero2.health / hero2.baseHealth, 0, 1.0f);
        h3HealthBar.GetComponent<Image>().fillAmount = Mathf.Clamp(hero3.health / hero3.baseHealth, 0, 1.0f);
        h4HealthBar.GetComponent<Image>().fillAmount = Mathf.Clamp(hero4.health / hero4.baseHealth, 0, 1.0f);
        h1EtherBar.GetComponent<Image>().fillAmount = Mathf.Clamp(hero1.ether / hero1.baseEther, 0, 1.0f);
        h2EtherBar.GetComponent<Image>().fillAmount = Mathf.Clamp(hero2.ether / hero2.baseEther, 0, 1.0f);
        h3EtherBar.GetComponent<Image>().fillAmount = Mathf.Clamp(hero3.ether / hero3.baseEther, 0, 1.0f);
        h4EtherBar.GetComponent<Image>().fillAmount = Mathf.Clamp(hero4.ether / hero4.baseEther, 0, 1.0f);
    }
    public void CheckIfCharsAreDead()
    {
        Debug.Log(participants[0]);
        foreach (Character participant in participants)
        { 
             if (participant.health <= 0)
             {
                 Debug.Log(participant + " is dead");
                 participant.health = 0;
                 participant.isAlive = false;
                 if (participant is Enemy)
                 {
                     participant.gameObject.SetActive(false);
                 }
             }
        }
        if (heroes[0].isAlive == false && heroes[1].isAlive == false && heroes[2].isAlive == false && heroes[3].isAlive == false)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        ClearTargets();
        ClearTurnBool();
        SceneManager.LoadScene("Title", LoadSceneMode.Single);
    }
}
