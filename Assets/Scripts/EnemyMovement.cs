using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public enum EnemyState
{
    Chase,
    Attack,
    Flee
};

public class EnemyMovement : MonoBehaviour
{
    public GameObject goal;
    public GameObject lighting;
    public GameObject particleBig;
    public GameObject particleSmall;

    private NavMeshAgent agent;
    private float attackTimer;

    public EnemyState currentState;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        //lighting = GameObject.FindGameObjectsWithTag("Light")[0];
        currentState = EnemyState.Chase;
        // agent = GetComponent<NavMeshAgent>();

        attackTimer = 2.0f;
    }

    void Update()
    {
        switch(currentState)
        {
            case EnemyState.Chase:
                ChasePlayer();
                break;

            case EnemyState.Attack:
                AttackPlayer();
                break;

            case EnemyState.Flee:
                RunAway();
                break;

            default:
                ChasePlayer();
                break;
        }

        if (lighting.activeSelf)
            Destroy(this.gameObject);
    }

    public void ChasePlayer()
    {
        if (!lighting.activeSelf)
        {
            agent.destination = goal.transform.position;

            float distance = Vector3.Distance(transform.position, goal.transform.position);

            if (distance < 1.0f)
            {
                currentState = EnemyState.Attack;
            }
        }
    }

    public void AttackPlayer()
    {
        var playerHealth = goal.GetComponent<HealthSystem>();

        if (attackTimer <= 0.0f)
        {
            playerHealth.TakeDamage(1);
            attackTimer = 2.0f;
        }

        attackTimer -= Time.deltaTime;

        float distance = Vector3.Distance(transform.position, goal.transform.position);

        if (distance > 1.0f)
        {
            currentState = EnemyState.Chase;
        }
    }

    public void RunAway()
    {
        
    }

    public void OnDestroy()
    {
        Instantiate(particleBig, transform.position,Quaternion.identity);
        Instantiate(particleSmall, transform.position, Quaternion.identity);
    }
}