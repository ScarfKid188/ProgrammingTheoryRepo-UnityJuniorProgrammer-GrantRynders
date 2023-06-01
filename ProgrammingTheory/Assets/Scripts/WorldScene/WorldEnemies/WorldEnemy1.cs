using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEnemy1 : WorldEnemy
{
    public GameObject enemy1Object;
    public GameObject enemy2Object;
    public GameObject enemy3Object;
    public GameObject enemy4Object;

    public void Start()
    {
        enemiesToSpawn.Add(enemy1Object);
        enemiesToSpawn.Add(enemy2Object);
        enemiesToSpawn.Add(enemy3Object);
        enemiesToSpawn.Add(enemy4Object);
    }
}
