using UnityEngine;

public class DesiredPos : MonoBehaviour
{
    public Vector3 desiredPosition = new Vector3(-0.3010041f, 2.719396f, 0.3712f);

    void Start()
    {
        transform.position = desiredPosition;
    }
}
