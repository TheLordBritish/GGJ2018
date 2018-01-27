using UnityEngine;

public class Torch : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            var behaviour = other.GetComponent<EnemyMovement>();
            behaviour.CurrentState = EnemyState.Flee;

            var health = other.GetComponent<HealthSystem>();
            health.TakeDamage(1);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            var behaviour = other.GetComponent<EnemyMovement>();
            behaviour.CurrentState = EnemyState.Chase;
        }
    }
}
