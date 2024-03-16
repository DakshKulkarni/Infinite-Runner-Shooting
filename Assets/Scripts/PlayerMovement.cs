using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;
    public float playerSpeed = 10f;
    public float horSpeedMultiplier = 2.3f;
    public Rigidbody rb;
    float horizontalInput;
    public float speedIncrease = 0.1f;
    public float jumpForce = 800f;
    public float jumpCooldown = 0.5f; 
    public float maxHeight = 17f;

    private bool isJumping = false;
    private int jumpCount = 0;
    private float lastJumpTime = 0f;

    private void FixedUpdate()
    {
        if (!alive)
            return;

        Vector3 MoveForward = transform.forward * playerSpeed * Time.fixedDeltaTime;
        Vector3 HorizontalMove = transform.right * horizontalInput * horSpeedMultiplier * playerSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + MoveForward + HorizontalMove);
    }

    private void Update()
    {
        if (!alive)
            return;

        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (transform.position.y < -5)
        {
            Die();
        }
    }

    public void Die()
    {
        alive = false;
        Invoke("Restart", 2);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Jump()
    {
        if (Time.time - lastJumpTime > jumpCooldown || jumpCount < 2)
        {
            lastJumpTime = Time.time;
            float height = GetComponent<Collider>().bounds.size.y;
            bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, LayerMask.GetMask("Ground"));

            if (isGrounded || !isJumping)
            {
                if (transform.position.y < maxHeight)
                {
                    rb.AddForce(Vector3.up * Mathf.Min(jumpForce, maxHeight - transform.position.y), ForceMode.Impulse);
                    isJumping = true;
                    jumpCount++;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            jumpCount = 0;
        }
    }
}
