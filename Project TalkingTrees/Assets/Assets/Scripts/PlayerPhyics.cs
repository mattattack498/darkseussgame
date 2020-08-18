using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhyics : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private Rigidbody2D playerRb;
    [SerializeField]
    private bool isFacingRight = true;
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
    private Vector3 mVelocity = Vector3.zero;
    [SerializeField]
    private float jumpForce = 10f;
    [SerializeField]
    private bool isOnGround;


    void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(float move)
    {
        Vector3 targetVelocity = new Vector2(move * 10f, playerRb.velocity.y);
        playerRb.velocity = Vector3.SmoothDamp(playerRb.velocity, targetVelocity, ref mVelocity, movementSmoothing);

        // If the input is moving the player right and the player is facing left...
        if (move > 0 && !isFacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && isFacingRight)
        {
            // ... flip the player.
            Flip();
        }
    }

    private void Flip()
    {

        isFacingRight = !isFacingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}
