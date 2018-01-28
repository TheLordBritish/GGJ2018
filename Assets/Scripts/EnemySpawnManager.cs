using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject enemy;

    private float timer;
    private GeneratorManager generator;

	void Start () 
    {
        timer = 3.0f;
        generator = GameObject.FindGameObjectWithTag("Generator").GetComponent<GeneratorManager>();
	}
	
	void Update () 
    {
        timer -= Time.deltaTime;
        if (!generator.IsPoweredOn && timer <= 0.0f)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            timer = 3.0f;
        }
	}
}