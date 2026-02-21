using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    //Speeds
    public float walkSpeed;
    public float runSpeed;
    public float sneakSpeed;
    public bool isHiding = false;
    public Animator animator;
    public References references;
    private bool movementKeyReleasedSinceHiding = false;

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
    [Header("Player Sounds")]
    public AudioClip walkSound;
    public AudioSource audioSource;
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
        //Pausing
        if (WorldData.gamePaused) { return; }


        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        float movement = new Vector2(h, v).magnitude;
        animator.SetFloat("movement", movement);
        if (h == 0 && v == 0)
        {
            if(audioSource.clip == walkSound)
            {
                audioSource.Stop();
            }
            movementState = MovementState.idle;
            return;
        }
        else
        {
            audioSource.clip = walkSound;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            animator.SetBool("isIdle", false);
            if(h > 0) //Right
            {
                animator.SetInteger("direction", 1);
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if(h < 0) //Left
            {
                animator.SetInteger("direction", 3);
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        if(v > 0) //Up
        {
            animator.SetInteger("direction", 0);
        }
        else if(v < 0) //Down
        {
            animator.SetInteger("direction", 2);
        }
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
            case MovementState.hiding:
                UpdateHiding();
            break;
            case MovementState.idle:
                animator.SetBool("isIdle", true);
                break;
        }
    }

    void UpdateHiding()
    {

        bool movementKeyHeld = Input.GetKey(KeyCode.W) ||
                           Input.GetKey(KeyCode.A) ||
                           Input.GetKey(KeyCode.S) ||
                           Input.GetKey(KeyCode.D);
        if (!movementKeyHeld)
        {
            movementKeyReleasedSinceHiding = true;
        }
        if (movementKeyReleasedSinceHiding)
        {
            bool movementKeyDown = Input.GetKey(KeyCode.W) ||
                           Input.GetKey(KeyCode.A) ||
                           Input.GetKey(KeyCode.S) ||
                           Input.GetKey(KeyCode.D);
            if (movementKeyDown)
            {
                Unhide();
            }
        }
    }
    public void Unhide()
    {
        isHiding = false;
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
        movementKeyReleasedSinceHiding = false;
    }
    void move(float speed)
    {
        Vector2 inputDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 movement = inputDirection.normalized * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }

}

