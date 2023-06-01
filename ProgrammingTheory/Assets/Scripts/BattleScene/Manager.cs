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
    private Hero hero1;
    private Hero hero2;
    private Hero hero3;
    private Hero hero4;
    private Enemy enemy1;
    private Enemy enemy2;
    private Enemy enemy3;
    private Enemy enemy4;
    private battleCamera battleCamera;
    private WorldManager worldManager;
    //turnOrder
    public List<float> turnOrder = new List<float>(); // list of character turnValues
    public List<Character> charOrder = new List<Character>(); // list of characters to help visualize what's happening, get active character
    public List<Image> charImage = new List<Image>(); //list of character icons
    private List<GameObject> slotsList = new List<GameObject>(); // list of the slot gameObjects that aligns with charImage
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
    public GameObject heroStats;
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
    public GameObject victoryScreen;
    //vectors
    private Vector3 h1Pos;
    private Vector3 h2Pos;
    private Vector3 h3Pos;
    private Vector3 h4Pos;
    private Vector3 e1Pos;
    private Vector3 e2Pos;
    private Vector3 e3Pos;
    private Vector3 e4Pos;
    private Vector3 targetOffset;
    //general
    public List<Character> heroes = new List<Character>();
    public List<GameObject> heroObjects = new List<GameObject>();
    public List<Character> enemies = new List<Character>();
    public List<GameObject> enemyObjects = new List<GameObject>();
    public List<Character> participants = new List<Character>(); // list of all active Characters in battle
    public List<GameObject> participantObjects = new List<GameObject>();
    public List<Character> targets = new List<Character>(); // list of all targeted Characters
    public List<Character> selectableTargets = new List<Character>(); // list of all targeted Characters for arrow selection
    public int currentTarget;
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
        worldManager = GameObject.Find("WorldManager").GetComponent<WorldManager>();
        //for (int i = 0; i < worldManager.heroParty.Count; i++)
        //{
        //    GameObject heroObject;

        //    heroObject = Instantiate(worldManager.heroParty[i], (h1Pos + new Vector3((5 * i), 0, 0)), Quaternion.identity);
        //    heroObjects[i] = heroObject;
        //    Debug.Log(worldManager.heroParty[i] + " " + heroObjects[i]);
        //    heroes[i] = heroObjects[i].GetComponent<Hero>();
        //}
        hero1Object = Instantiate(worldManager.heroParty[0], h1Pos, Quaternion.identity);
        hero1 = hero1Object.GetComponent<Hero>();
        heroes.Add(hero1);
        heroObjects.Add(hero1Object);
        h1Stats.gameObject.SetActive(true);
        h1LevelText.text = hero1.currentLevel.ToString();
        h1TitleText.text = hero1.title;
        h1Icon = h1IconObject.GetComponent<Image>();
        h1Icon.sprite = hero1Object.GetComponent<Image>().sprite;
        hero1.battlePos = h1Pos;
        if (worldManager.heroParty.Count >= 2)
        {
            hero2Object = Instantiate(worldManager.heroParty[1], h2Pos, Quaternion.identity);
            hero2 = hero2Object.GetComponent<Hero>();
            heroes.Add(hero2);
            heroObjects.Add(hero2Object);
            h2Stats.gameObject.SetActive(true);
            h2LevelText.text = hero2.currentLevel.ToString();
            h2TitleText.text = hero2.title;
            h2Icon = h2IconObject.GetComponent<Image>();
            h2Icon.sprite = hero2Object.GetComponent<Image>().sprite;
            hero2.battlePos = h2Pos;
            if (worldManager.heroParty.Count >= 3)
            {
                hero3Object = Instantiate(worldManager.heroParty[2], h3Pos, Quaternion.identity);
                hero3 = hero3Object.GetComponent<Hero>();
                heroes.Add(hero3);
                heroObjects.Add(hero3Object);
                h3Stats.gameObject.SetActive(true);
                h3LevelText.text = hero3.currentLevel.ToString();
                h3TitleText.text = hero3.title;
                h3Icon = h3IconObject.GetComponent<Image>();
                h3Icon.sprite = hero3Object.GetComponent<Image>().sprite;
                hero3.battlePos = h3Pos;
                if (worldManager.heroParty.Count >= 4)
                {
                    hero4Object = Instantiate(worldManager.heroParty[3], h4Pos, Quaternion.identity);
                    hero4 = hero4Object.GetComponent<Hero>();
                    heroes.Add(hero4);
                    heroObjects.Add(hero4Object);
                    h4Stats.gameObject.SetActive(true);
                    h4LevelText.text = hero4.currentLevel.ToString();
                    h4TitleText.text = hero4.title;
                    h4Icon = h4IconObject.GetComponent<Image>();
                    h4Icon.sprite = hero4Object.GetComponent<Image>().sprite;
                    hero4.battlePos = h4Pos;
                }
            }
        }
        //for (int i = 0; i < worldManager.enemyParty.Count; i++)
        //{
        //    enemyObjects[i] = Instantiate(worldManager.enemyParty[i], (e1Pos + new Vector3((5 * i), 0, 0)), Quaternion.identity);
        //    enemies[i] = enemyObjects[i].GetComponent<Enemy>();
        //}
        enemy1Object = Instantiate(worldManager.enemyParty[0], e1Pos, Quaternion.identity);
        enemy1 = enemy1Object.GetComponent<Enemy>();
        enemies.Add(enemy1);
        enemyObjects.Add(enemy1Object);
        enemy1.battlePos = e1Pos;
        if (worldManager.enemyParty.Count >= 2)
        {
            enemy2Object = Instantiate(worldManager.enemyParty[1], e2Pos, Quaternion.identity);
            enemy2 = enemy2Object.GetComponent<Enemy>();
            enemies.Add(enemy2);
            enemyObjects.Add(enemy2Object);
            enemy2.battlePos = e2Pos;
            if (worldManager.enemyParty.Count >= 3)
            {
                enemy3Object = Instantiate(worldManager.enemyParty[2], e3Pos, Quaternion.identity);
                enemy3 = enemy3Object.GetComponent<Enemy>();
                enemies.Add(enemy3);
                enemyObjects.Add(enemy3Object);
                enemy3.battlePos = e3Pos;
                if (worldManager.enemyParty.Count >= 4)
                {
                    enemy4Object = Instantiate(worldManager.enemyParty[3], e4Pos, Quaternion.identity);
                    enemy4 = enemy4Object.GetComponent<Enemy>();
                    enemies.Add(enemy4);
                    enemyObjects.Add(enemy4Object);
                    enemy4.battlePos = e4Pos;
                }
            }

        }
        //participants list
        foreach (Character hero in heroes)
        {
            participants.Add(hero);
        }
        foreach (Character enemy in enemies)
        {
            participants.Add(enemy);
        }
        foreach (GameObject heroObject in heroObjects)
        {
            participantObjects.Add(heroObject);
        }
        foreach (GameObject enemyObject in enemyObjects)
        {
            participantObjects.Add(enemyObject);
        }
        foreach (Character hero in heroes)
        {
            hero.LoadCharStats();
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
        battleCamera = cameraAxis.GetComponent<battleCamera>();
        //initiate basic UI
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
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].isTurn)
                {
                    battleCamera.CircleCharacter(enemyObjects[i]);
                }
            }
        }
        if (isHeroTurn)
        {
            for (int i = 0; i < heroes.Count; i++)
            {
                if (heroes[i].isTurn)
                {
                    battleCamera.CircleCharacter(heroObjects[i]);
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (currentTarget == 0)
                {
                    currentTarget = (selectableTargets.Count);
                }
                Target(selectableTargets[currentTarget - 1]);
                currentTarget -= 1;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (currentTarget == (selectableTargets.Count - 1))
                {
                    currentTarget = -1;
                }
                Target(selectableTargets[currentTarget + 1]);
                currentTarget += 1;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                HeroAttack();
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                targets[0].ResetStats();
                UpdateStatsUI();
                Debug.Log("Reset " + targets[0] + "'s stats");
            }
        }
    }
    public void ChooseInitialTarget()
    {
        selectableTargets.Clear();
        foreach (Character participant in participants)
        {
            if (participant.isAlive)
            {
                selectableTargets.Add(participant);
            }
        }
        Target(selectableTargets[0]);
        currentTarget = 0;
        //for (int i = 0; i < selectableTargets.Count; i++)
        //{
        //    if (selectableTargets[i].isTargeted)
        //    {
        //        currentTarget = i;
        //    }
        //}
    }
    public void HeroTurn()
    {
        Debug.Log("HeroTurn. Active Character: " + charOrder[0]);
        isHeroTurn = true;
        playerOptions.gameObject.SetActive(true);
        ChooseInitialTarget();
    }
    public void EnemyTurn()
    {
        Debug.Log("EnemyTurn. Active Character: " + charOrder[0]);
        isEnemyTurn = true;
        RandomTarget();
        if (targets.Count > 0)
        {
            Attack(charOrder[0].attackDamage, charOrder[0].attackPower);
        }
        else
        {
            Debug.Log("No target for enemyAttack");
            EndTurn();
        }

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
        Target(targets[target]);

    }
    public void HeroAttack()
    {
        if (targets.Count > 0)
        {
            Attack(charOrder[0].attackDamage, charOrder[0].attackPower);
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
            Debug.Log(charOrder[0] + "'s attack missed" + agility + randomNum);
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
        SetSlotImages();
        for (int i = 0; i < turnOrder.Count; i++)
        {
            while (charOrder[i] == null)
            {
                foreach (Character participant in participants)
                {
                    if (turnOrder[i] == participant.turnValue && !participant.hasSlot && participant.isAlive)
                    {
                        charOrder[i] = participant;
                        charImage[i] = participant.characterIcon;
                        participant.hasSlot = true;
                        slotsList[i].GetComponent<Image>().sprite = charImage[i].sprite;
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
        StartCoroutine(PlaceholderDelayCoroutine());
    }
    public void Target(Character target)
    {
        ClearTargets();
        targets.Add(target);
        target.isTargeted = true;
        targetObject.gameObject.SetActive(true);
        targetObject.transform.position = (target.battlePos + targetOffset);
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
        h1HealthBar.GetComponent<Image>().fillAmount = Mathf.Clamp(hero1.health / hero1.baseHealth, 0, 1.0f);
        h1EtherBar.GetComponent<Image>().fillAmount = Mathf.Clamp(hero1.ether / hero1.baseEther, 0, 1.0f);
        if (heroes.Count >= 2)
        {
            h2HealthText.text = hero2.health.ToString() + "/" + hero2.baseHealth.ToString();
            h2EtherText.text = hero2.ether.ToString() + "/" + hero2.baseEther.ToString();
            h2HealthBar.GetComponent<Image>().fillAmount = Mathf.Clamp(hero2.health / hero2.baseHealth, 0, 1.0f);
            h2EtherBar.GetComponent<Image>().fillAmount = Mathf.Clamp(hero2.ether / hero2.baseEther, 0, 1.0f);
            if (heroes.Count >= 3)
            {
                h3HealthText.text = hero3.health.ToString() + "/" + hero3.baseHealth.ToString();
                h3EtherText.text = hero3.ether.ToString() + "/" + hero3.baseEther.ToString();
                h3HealthBar.GetComponent<Image>().fillAmount = Mathf.Clamp(hero3.health / hero3.baseHealth, 0, 1.0f);
                h3EtherBar.GetComponent<Image>().fillAmount = Mathf.Clamp(hero3.ether / hero3.baseEther, 0, 1.0f);
                if (heroes.Count >= 4)
                {
                    h4HealthText.text = hero4.health.ToString() + "/" + hero4.baseHealth.ToString();
                    h4EtherText.text = hero4.ether.ToString() + "/" + hero4.baseEther.ToString();
                    h4HealthBar.GetComponent<Image>().fillAmount = Mathf.Clamp(hero4.health / hero4.baseHealth, 0, 1.0f);
                    h4EtherBar.GetComponent<Image>().fillAmount = Mathf.Clamp(hero4.ether / hero4.baseEther, 0, 1.0f);
                }
            }
        }
    }
    public void CheckIfCharsAreDead()
    {
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
        float deadHeroCount = 0;
        foreach (Character hero in heroes)
        {
            if (hero.isAlive == false)
            {
                deadHeroCount += 1;
            }
        }
        if (deadHeroCount >= heroes.Count)
        {
            GameOver();
        }
        float deadEnemyCount = 0;
        foreach (Character enemy in enemies)
        {
            if (enemy.isAlive == false)
            {
                deadEnemyCount += 1;
            }
        }
        if (deadEnemyCount >= enemies.Count)
        {
            Victory();
        }
    }
    public void ClearUI()
    {
        mainBattleUI.SetActive(false);
    }
    public void GameOver()
    {
        ClearUI();
        Debug.Log("gameover");
        foreach (Character hero in heroes)
        {
            hero.SaveCharStats();
        }
        //ClearTargets();
        //ClearTurnBool();
        Debug.Log("Loading title scene");
        SceneManager.LoadScene("Title", LoadSceneMode.Single);
    }
    public void Victory()
    {
        ClearUI();
        Debug.Log("victory");
        victoryScreen.gameObject.SetActive(true);
        foreach (Character hero in heroes)
        {
            hero.SaveCharStats();
        }
        //ClearTargets();
        //ClearTurnBool();
        StartCoroutine(VictoryDelayCoroutine());
    }
    IEnumerator PlaceholderDelayCoroutine()
    {
        Debug.Log("PlaceholderDelayCoroutine()");
        yield return new WaitForSeconds(1);
        TurnOrder();
    }
    IEnumerator VictoryDelayCoroutine()
    {
        Debug.Log("VictoryDelayCoroutine()");
        yield return new WaitForSeconds(3);
        Debug.Log("Loading world scene");
        SceneManager.LoadScene("World", LoadSceneMode.Single);
    }
}
