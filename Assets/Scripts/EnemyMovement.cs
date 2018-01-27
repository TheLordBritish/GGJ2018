﻿using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    Chase,
    Attack,
    Flee
};

public class EnemyMovement : MonoBehaviour
{
    private GameObject player;
    private GeneratorManager generator;

    public GameObject particleBig;
    public GameObject particleSmall;

    private NavMeshAgent agent;
    private HealthSystem system;

    private float attackTimer;

    public EnemyState CurrentState { get; set; }
    public float distanceToAttack;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        generator = GameObject.FindGameObjectWithTag("Generator").GetComponent<GeneratorManager>();
        system = GetComponent<HealthSystem>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        attackTimer = 2.0f;
    }

    void Update()
    {
        switch (CurrentState)
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
        }

        if (generator.IsPoweredOn || system.IsDead())
        {
            Destroy(gameObject);
        }
    }

    public void ChasePlayer()
    {
        agent.isStopped = false;
        agent.destination = player.transform.position;

        if (Vector3.Distance(transform.position, player.transform.position) < distanceToAttack)
        {
            CurrentState = EnemyState.Attack;
        }
    }

    public void AttackPlayer()
    {
        if (attackTimer <= 0.0f)
        {
            var playerHealth = player.GetComponent<HealthSystem>();

            playerHealth.TakeDamage(1);
            attackTimer = 2.0f;
        }

        attackTimer -= Time.deltaTime;
        if (Vector3.Distance(transform.position, player.transform.position) > distanceToAttack)
        {
            CurrentState = EnemyState.Chase;
        }
    }

    public void RunAway()
    {
        agent.destination = transform.position;
        agent.isStopped = true;
    }

    public void OnDestroy()
    {
        Instantiate(particleBig, transform.position,Quaternion.identity);
        Instantiate(particleSmall, transform.position, Quaternion.identity);
    }
}