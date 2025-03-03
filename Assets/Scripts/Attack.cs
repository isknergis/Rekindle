using UnityEngine;

public class Attack: MonoBehaviour
{
    public float attackRange = 2f; // Saldýrý mesafesi
    public int attackDamage = 1;   // Bir saldýrýda verilen hasar
    public KeyCode attackKey = KeyCode.Mouse0; // Sol týk ile saldýrý

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
            if (hit.collider.CompareTag("Enemy")) // Eðer vurulan nesne "Enemy" tag'ine sahipse
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
