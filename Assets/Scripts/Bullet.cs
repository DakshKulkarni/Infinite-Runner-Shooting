using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3f;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager=FindObjectOfType<GameManager>();
        Destroy(gameObject,life);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit!");
            Destroy(collision.gameObject);
           killEnemy();
        }
       Destroy(gameObject);
    }
    void killEnemy()
    {
        if(gameManager!=null)
        {
            gameManager.IncrementKills();
        }
    }
}
