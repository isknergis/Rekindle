using UnityEngine;

public class Laser : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    private LineRenderer lineRenderer;

    public float speed = 2f; 
    private Vector3 initialPosition;
    private float distance;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 2f;
        lineRenderer.endWidth = 2f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;

        initialPosition = startPoint.position; 
        distance = Vector3.Distance(startPoint.position, endPoint.position); 
    }

    void Update()
    {
        float offset = Mathf.PingPong(Time.time * speed, distance); 
        Vector3 newPos = new Vector3(initialPosition.x + offset, initialPosition.y, initialPosition.z);

        startPoint.position = newPos;
        endPoint.position = new Vector3(newPos.x + distance, endPoint.position.y, endPoint.position.z);

        lineRenderer.SetPosition(0, startPoint.position);
        lineRenderer.SetPosition(1, endPoint.position);
    }
}
