using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour {

    static int enemyCount;
    public int maxEnemies;
    public GameObject enemy;
    public GameObject target;

    public float timer;
    private bool hasSpawned;

	// Use this for initialization
	void Start () 
    {
        timer = 3.0f;
        enemyCount = 0;
        hasSpawned = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (timer >= 3.0f)
        {
            if (enemyCount < maxEnemies)
            {
                Instantiate(enemy, transform.position, Quaternion.identity);
                enemyCount++;
                hasSpawned = true;
                timer = 0.0f;
            }
        }

        if (hasSpawned)
            timer += Time.deltaTime;

        else
            timer = 3.0f;
	}
}