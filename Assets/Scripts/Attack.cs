using UnityEngine;

public class Attack: MonoBehaviour
{
    public float attackRange = 2f; // Sald�r� mesafesi
    public int attackDamage = 1;   // Bir sald�r�da verilen hasar
    public KeyCode attackKey = KeyCode.Mouse0; // Sol t�k ile sald�r�

    void Update()
    {
        if (Input.GetKeyDown(attackKey))
        {
            Attack_();
        }
    }

    void Attack_()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, attackRange))
        {
            if (hit.collider.CompareTag("Enemy")) // E�er vurulan nesne "Enemy" tag'ine sahipse
            {
                Enemy enemyHealth = hit.collider.GetComponent<Enemy>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(attackDamage);
                }
            }
        }
    }
}
