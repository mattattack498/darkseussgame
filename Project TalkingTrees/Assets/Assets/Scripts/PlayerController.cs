using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float jumpForce = 10f;
    [SerializeField]
    private Rigidbody2D playerRb;
    [SerializeField]
    private bool isOnGround;
    [SerializeField]
    private float health;

    //Variable to help detemine when the sprite flips. 
    private float horizontalMove = 0f;

    
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f; 
    private Vector3 m_Velocity = Vector3.zero;

    bool isFacingRight;
    void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && isOnGround != false)
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
        }

    }

    void FixedUpdate()
    {
        Move(horizontalMove * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
           
        }
    }

    #region Movement
    void Move(float move)
    {

        Vector3 targetVelocity = new Vector2(move * 10f, playerRb.velocity.y);
        playerRb.velocity = Vector3.SmoothDamp(playerRb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

        if (move < 0 && !isFacingRight)
        {
            Flip();
        }
  
        else if (move > 0 && isFacingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    #endregion Movement
}
