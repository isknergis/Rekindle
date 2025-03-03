using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float moveSpeed = 100f; 
    public float moveHeight = 300f; 

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool movingUp = true;

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + Vector3.up * moveHeight;
    }

    void Update()
    {
        if (movingUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPos) < 0.01f)
                movingUp = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, startPos) < 0.01f)
                movingUp = true;
        }
    }
}
