using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; 
    public Vector3 desiredPosition = new Vector3(-0.3010041f, 2.719396f, 0.3712f);
    
    void Start()
    {
        desiredPosition += new Vector3(0f, 2f, 0f);
        transform.position = desiredPosition;
    }
    void LateUpdate()
    {
        if (target == null)
            return;
        transform.position = target.position;
    }
}
