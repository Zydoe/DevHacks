using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject nextPatrolPoint;
    public References references;
    public float walkSpeed;
    public float chaseSpeed;
    public GameObject visionObject;
    public GameObject torch;
    private GuardVision vision;
    public int searchDuration;
    public enum GuardState
    {
        idle,
        patrolling,
        chasing,
        searching
    }
    public GuardState currentState = GuardState.idle;
    [Header("Guard Sounds")]
    public AudioClip grunt;
    public AudioClip discover; //Hey YOU!
    public AudioClip suspicious;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void OnEnable()
    {
        DayNightManager.OnDayStarted += handleOnDayStarted;
        DayNightManager.OnNightStarted += handleOnNightStarted;
    }

    void OnDisable()
    {
        DayNightManager.OnDayStarted -= handleOnDayStarted;
        DayNightManager.OnNightStarted -= handleOnNightStarted;
    }

    void Start()
    {
        vision = visionObject.GetComponent<GuardVision>();
        references = GameObject.Find("References").GetComponent<References>();
        if (references.dayNightManager.isDay)
            handleOnDayStarted();
        else
            handleOnNightStarted();
    }

    void FixedUpdate()
    {
        if (WorldData.gamePaused) { return; }
        CheckForPlayer();
        switch (currentState)
        {
            case GuardState.idle:
                //Idle
                break;
            case GuardState.patrolling:
                UpdatePatrolling();
                break;
            case GuardState.chasing:
                UpdateChasing();
                break;
            case GuardState.searching:
                UpdateSearching();
                break;
        }
    }
    void CheckForPlayer()
    {
        if (currentState != GuardState.idle)
        {
            if (canSeePlayer() && currentState != GuardState.chasing)
            {
                StartChase();
            }
            else
            {
                if (currentState == GuardState.chasing && !canSeePlayer())
                {
                    StartSearch();
                }
            }
        }

    }

    void StartSearch()
    {
        audioSource.PlayOneShot(suspicious);
        StopAllCoroutines();
        currentState = GuardState.searching;
        StartCoroutine(searchTimer());
    }
    bool canSeePlayer()
    {
        GameObject player = references.player.gameObject;
        LayerMask visionMask = LayerMask.GetMask("Default");
        if (vision.playerInSight)
        {
            
            Vector2 dir = (player.transform.position - transform.position).normalized;
            float dist = Vector2.Distance(transform.position, player.transform.position);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, dist, visionMask);

            if (hit.collider == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    void StartChase()
    {
        audioSource.PlayOneShot(discover);
        StopAllCoroutines();
        currentState = GuardState.chasing;
        references.chaseManager.JoinChase(gameObject);
    }

    void UpdatePatrolling()
    {
        Vector2 target = nextPatrolPoint.transform.position;
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, walkSpeed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
    }
    void UpdateChasing()
    {
        Vector2 target = references.player.transform.position;
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, chaseSpeed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
    }
    void UpdateSearching()
    {
        //Go to last known player position
        Vector2 target = vision.lastKnownPlayerPosition;
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, walkSpeed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
    }
    void handleOnDayStarted()
    {
        torch.SetActive(false);
        currentState = GuardState.idle;
        audioSource.PlayOneShot(grunt);
    }
    void handleOnNightStarted()
    {
        torch.SetActive(true);
        currentState = GuardState.patrolling;
    }

    IEnumerator searchTimer()
    {
        yield return new WaitForSeconds(searchDuration);
        currentState = GuardState.patrolling;
        references.chaseManager.LeaveChase(gameObject);
    }
}
