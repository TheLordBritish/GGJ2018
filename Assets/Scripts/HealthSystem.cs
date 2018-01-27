using UnityEngine;

public class HealthSystem
{
    [SerializeField]
    private int health;

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public bool IsDead()
    {
        return Health <= 0;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}
