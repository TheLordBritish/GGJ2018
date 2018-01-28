using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject enemy;

    private float timer;
    private GeneratorManager generator;

    public int maxEnemies;
    public int EnemyCount{ get; set; }

	void Start () 
    {
        timer = 3.0f;
        generator = GameObject.FindGameObjectWithTag("Generator").GetComponent<GeneratorManager>();
	}
	
	void Update () 
    {
        timer -= Time.deltaTime;
        if (EnemyCount <= maxEnemies && !generator.IsPoweredOn && timer <= 0.0f)
        {
            GameObject go = Instantiate(enemy, transform.position, Quaternion.identity) as GameObject;
            go.GetComponent<EnemyMovement>().Spawner = this;

            EnemyCount++;
            timer = 3.0f;
        }
	}

    public void ResetEnemy()
    {
        timer = 3.0f;
        EnemyCount--;
    }
}