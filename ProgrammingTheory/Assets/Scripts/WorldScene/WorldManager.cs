using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public static WorldManager Instance { get; private set; }

    public GameObject hero1Object;
    public GameObject hero2Object;
    public GameObject hero3Object;
    public GameObject hero4Object;
    public GameObject heroGuy;
    private PlayerController playerController;
    public List<GameObject> heroParty = new List<GameObject>();
    public List<GameObject> enemyParty = new List<GameObject>();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    

    // Start is called before the first frame update
    void Start()
    {
        heroGuy = GameObject.FindWithTag("Hero");
        playerController = heroGuy.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            foreach (GameObject hero in heroParty)
            {
                hero.GetComponent<Hero>().ResetStats();
                hero.GetComponent<Hero>().SaveCharStats();
                Debug.Log("Reset " + hero + "'s stats");
            }

        }
    }
    public void AddAll()
    {
        heroParty.Add(hero1Object);
        heroParty.Add(hero2Object);
        heroParty.Add(hero3Object);
        heroParty.Add(hero4Object);
    }
    public void ClearAll()
    {
        heroParty.Clear();
    }
    public void AddHero1()
    {
        heroParty.Add(hero1Object);
    }
    public void AddHero2()
    {
        heroParty.Add(hero2Object);
    }
    public void AddHero3()
    {
        heroParty.Add(hero3Object);
    }
    public void AddHero4()
    {
        heroParty.Add(hero4Object);
    }
    public void SaveData()
    {
        foreach (GameObject hero in heroParty)
        {
            hero.GetComponent<Hero>().ResetStats();
            hero.GetComponent<Hero>().SaveCharStats();
            Debug.Log("Reset " + hero + "'s stats");
        }
    }
}
