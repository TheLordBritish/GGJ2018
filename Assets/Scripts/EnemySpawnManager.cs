using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    static int enemyCount;
    public int maxEnemies;
    public GameObject enemy;

    private float timer;
    private GeneratorManager generator;

	// Use this for initialization
	void Start () 
    {
        timer = 3.0f;
        enemyCount = 0;

        generator = GameObject.FindGameObjectWithTag("Generator").GetComponent<GeneratorManager>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer -= Time.deltaTime;

        if (!generator.IsPoweredOn)
        {
            if (timer <= 0.0f)
            {
                if (enemyCount < maxEnemies)
                {
                    Instantiate(enemy, transform.position, Quaternion.identity);
                    enemyCount++;
                    timer = 3.0f;
                }
            }
        }
	}
}