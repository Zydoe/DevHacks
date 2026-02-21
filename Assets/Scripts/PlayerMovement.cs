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
    public bool isHiding = false;
    public References references;

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
        sneaking,
        idle,
        hiding
    }
    MovementState movementState = MovementState.idle;
    // Start is called before the first frame update
    void Start()
    {
        references = GameObject.Find("References").GetComponent<References>();
    }

    // Update is called once per frame
    void FixedUpdate()
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
        if (WorldData.gamePaused) { return; }
        if (isHiding)
        {
            movementState = MovementState.hiding;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            movementState = MovementState.running;
        }
        else if (!references.dayNightManager.isDay)
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
        Vector2 movement = inputDirection.normalized * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }

}

