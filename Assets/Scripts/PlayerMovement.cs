using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    //Speeds
    public float walkSpeed;
    public float runSpeed;
    public float sneakSpeed;

    public enum PlayerState
    {
        exploring,
        shopping,
        minigame,
        cutscene
    }

    public PlayerState playerState = PlayerState.exploring;

    enum MovementState
    {
        walking,
        running,
        sneaking
    }
    MovementState movementState = MovementState.walking;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (playerState)
        {
            case PlayerState.exploring:
                updateMovement();
                break;
            case PlayerState.shopping:
                //Shopping
                break;
            case PlayerState.minigame:
                //Minigame
                break;
            case PlayerState.cutscene:
                //Cutscene
                break;
        }
    }

    void updateMovementState()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementState = MovementState.running;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            movementState = MovementState.sneaking;
        }
        else
        {
            movementState = MovementState.walking;
        }
    }

    void updateMovement()
    {
        updateMovementState();
        switch (movementState)
        {
            case MovementState.walking:
                move(walkSpeed);
                break;
            case MovementState.running:
                move(runSpeed);
                break;
            case MovementState.sneaking:
                move(sneakSpeed);
                break;
        }
    }

    void move(float speed)
    {
        Vector2 inputDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 movement = inputDirection.normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

}

