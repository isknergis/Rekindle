using UnityEngine;

public class SidewaysMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Hareket hýzý
    public float moveDistance = 5f; // Saða ve sola hareket mesafesi

    private Vector3 startPos;
    private Vector3 rightPos;
    private Vector3 leftPos;
    private int moveStage = 0; // 0: Saða, 1: Sola, 2: Baþlangýca

    void Start()
    {
        startPos = transform.position;
        rightPos = startPos + Vector3.right * moveDistance;
        leftPos = startPos + Vector3.left * moveDistance;
    }

    void Update()
    {
        if (moveStage == 0) 
        {
            transform.position = Vector3.MoveTowards(transform.position, rightPos, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, rightPos) < 0.01f)
                moveStage = 1;
        }
        else if (moveStage == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, leftPos, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, leftPos) < 0.01f)
                moveStage = 2;
        }
        else if (moveStage == 2) 
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, startPos) < 0.01f)
                moveStage = 0; 
        }
    }
}
