using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float health;
    [SerializeField]
    private float horizontalMovement;

    public PlayerPhyics playerPhys;

    void Update()
    {

        horizontalMovement = Input.GetAxisRaw("Horizontal") * moveSpeed;

    }

    void FixedUpdate()
    {
        playerPhys.Move(horizontalMovement * Time.fixedDeltaTime);
    }
}
