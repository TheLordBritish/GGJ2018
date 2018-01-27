using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public GameObject goal;
    public GameObject lighting;

    void Start()
    {
       
    }

    void Update()
    {
        if (!lighting.activeSelf)
        {
            UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            agent.destination = goal.transform.position;
        }
    }
}