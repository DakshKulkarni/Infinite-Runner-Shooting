using UnityEngine;

public class Coins : MonoBehaviour
{
    public float turnSpeed = 90f;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogWarning("GameManager not found in the scene.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Obstacle>()!=null)
        {
            Destroy(gameObject);
            return;
        }
        if (other.CompareTag("Player"))
        {
          CollectCoin();
        }
    }

    void Update()
    {
        transform.Rotate(0f, 0f, turnSpeed * Time.deltaTime);
    }

    void CollectCoin()
    {
        if (gameManager != null)
        {
            gameManager.IncrementScore();
        }
        else
        {
            Debug.LogWarning("GameManager not assigned.");
        }

        Destroy(gameObject);
    }
}
