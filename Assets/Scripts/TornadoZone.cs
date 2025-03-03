using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoZone : MonoBehaviour
{
    public float pushForce = 5f; // �tme kuvveti
    public float slowDownForce = 2f; // �kinci oyuncunun yava�lat�lmas�
    public float upwardForce = 0.5f; // Hafif yukar� kald�rma (U�urmaz)

    private List<Rigidbody> playersInZone = new List<Rigidbody>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null && !playersInZone.Contains(rb))
            {
                playersInZone.Add(rb);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null && playersInZone.Contains(rb))
            {
                playersInZone.Remove(rb);
            }
        }
    }

    private void FixedUpdate()
    {
        if (playersInZone.Count == 2) // �ki oyuncu da hortumdaysa
        {
            Rigidbody firstPlayer = playersInZone[0];
            Rigidbody secondPlayer = playersInZone[1];

            // �lk oyuncuya g��l� bir itme uygula
            Vector3 direction1 = (firstPlayer.transform.position - transform.position).normalized;
            Vector3 force1 = (direction1 * pushForce) + (Vector3.up * upwardForce);
            firstPlayer.AddForce(force1, ForceMode.Force);

            // �kinci oyuncunun hareketini k�s�tla, ama �ok itme
            Vector3 direction2 = (secondPlayer.transform.position - transform.position).normalized;
            Vector3 force2 = (direction2 * slowDownForce); // Yaln�zca yava�lat
            secondPlayer.linearVelocity *= 0.9f; // Hareketini biraz k�s�tla

            secondPlayer.AddForce(force2, ForceMode.Force);
        }
    }
}
