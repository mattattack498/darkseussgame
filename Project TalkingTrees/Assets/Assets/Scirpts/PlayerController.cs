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

    void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        CheckMovement();
    }

    #region
    void CheckMovement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            playerRb.AddForce(Vector2.right * moveSpeed, ForceMode2D.Force);
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerRb.AddForce(-Vector2.right * moveSpeed, ForceMode2D.Force);

        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
        }


    }
    #endregion
}
