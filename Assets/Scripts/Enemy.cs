using UnityEngine;

public class Enemy:MonoBehaviour
{
    public int maxHealth = 3; // Kaç vuruþta yok olacaðý
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(gameObject.name + " has " + currentHealth + " health left!");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " has been destroyed!");
        Destroy(gameObject);
    }
}
