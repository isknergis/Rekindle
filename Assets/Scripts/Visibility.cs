using System.Collections;
using UnityEngine;

public class Visibility : MonoBehaviour
{
    private Renderer obstacleRenderer;
    private Collider obstacleCollider;

    void Start()
    {
        obstacleRenderer = GetComponent<Renderer>();
        obstacleCollider = GetComponent<Collider>();
        StartCoroutine(ToggleVisibility());
    }

    IEnumerator ToggleVisibility()
    {
        while (true)
        {
            
            obstacleRenderer.enabled = false;
            obstacleCollider.enabled = false;
            yield return new WaitForSeconds(3f);

            
            obstacleRenderer.enabled = true;
            obstacleCollider.enabled = true;
            yield return new WaitForSeconds(3f);
        }
    }
}
