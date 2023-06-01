using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 100;
    public float rotationSpeed = 100;
    public WorldManager worldManager;
    // Start is called before the first frame update
    void Start()
    {
        worldManager = GameObject.Find("WorldManager").GetComponent<WorldManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (worldManager.heroParty.Count > 0)
            {
            worldManager.enemyParty = other.GetComponent<WorldEnemy>().enemiesToSpawn;
            Debug.Log("AMBUSH");
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
            }
            else
            {
                Debug.Log("Blud forgot to choose his party members");
            }
        }
        if (other.tag == "TitleWarp")
        {
            SceneManager.LoadScene("Title", LoadSceneMode.Single);
        }
        if (other.tag == "SaveStation")
        {
            worldManager.SaveData();
        }
    }
}
