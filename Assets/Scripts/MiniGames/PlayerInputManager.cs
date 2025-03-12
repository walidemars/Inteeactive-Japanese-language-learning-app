using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    private MiniGameManager gameManager;
    InputAction jumpAction;
    Rigidbody2D playerRb;

    [SerializeField] bool isGround = true;

    [SerializeField] private float jumpForce = 2.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<MiniGameManager>();
        jumpAction = InputSystem.actions.FindAction("Jump");
        playerRb = this.GetComponent<Rigidbody2D>();

        if (playerRb ==  null)
        {
            Debug.LogError("RigidBody игрока не найден");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerJump();
    }

    void PlayerJump()
    {  
        if (jumpAction != null)
        {
            if (jumpAction.IsPressed() && isGround)
            {
                isGround = false;
                playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameManager.SubtractPoints(10);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Ieroglif"))
        {
            gameManager.AddPoints(10);
            Destroy(collision.gameObject);
        }
    }
}
