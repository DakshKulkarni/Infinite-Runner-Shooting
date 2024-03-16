using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;
    public float frequency = 2f; 
    public float amplitude = 3f; 

    private Vector3 startPosition;
    private float minX;
    private float maxX;

    void Start()
    {
        startPosition = transform.position;
    }

    public void SetMovementBounds(float minBound, float maxBound)
    {
        minX = minBound;
        maxX = maxBound;
    }

    void Update()
    {
        MovePeriodically();
    }

    void MovePeriodically()
    {
        float offsetX = Mathf.Sin(Time.time * frequency) * amplitude;
        float clampedX = Mathf.Clamp(startPosition.x + offsetX, minX, maxX);
        transform.position = new Vector3(clampedX, startPosition.y, startPosition.z);
    }
}
