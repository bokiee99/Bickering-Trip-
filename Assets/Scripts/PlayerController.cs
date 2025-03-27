using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public Rigidbody2D theRB;
    public float moveSpeed, jumpForce, climbSpeed;

    private float velocity, velocity2, gravityScaleAtStart;

    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    public Animator anim;
    public bool isKeyboard2;

    public GameObject Player1, player1_good_emotion, player1_bad_emotion;
    public GameObject Player2, player2_good_emotion, player2_bad_emotion;
    public GameObject distUI1;
    public GameObject distUI2;
    public GameObject checkpick;
    public float dist, targetdist;

    CapsuleCollider2D myBody;

    public int hiddenCnt = 0;

    public float powerUpCounter;
    public float speedStore, climbStore;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(gameObject);
        GameManager.instance.AddPlayer(this);

        myBody = GetComponent<CapsuleCollider2D>();
        speedStore = moveSpeed;
        climbStore = climbSpeed;

        gravityScaleAtStart = theRB.gravityScale;
        targetdist = 25;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector2.Distance(Player1.transform.position, Player2.transform.position);
        if (dist > targetdist)
        {
            StartCoroutine(FarDist());
        }

        if (isKeyboard2)
        {
            velocity = 0f;
            velocity2 = 0f;

            if (Keyboard.current.leftArrowKey.isPressed)
            {
                velocity = -1f;
            }
            if (Keyboard.current.rightArrowKey.isPressed)
            {
                velocity = 1f;
            }

            if (Keyboard.current.upArrowKey.isPressed)
            {
                velocity2 = 1f;
            }
            if (Keyboard.current.downArrowKey.isPressed)
            {
                velocity2 = -1f;
            }

            if (isGrounded && Keyboard.current.rightShiftKey.wasPressedThisFrame)
            {
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
            }

            if (!isGrounded && Keyboard.current.rightShiftKey.wasReleasedThisFrame && theRB.velocity.y > 0)
            {
                theRB.velocity = new Vector2(theRB.velocity.x, theRB.velocity.y * .5f);
            }

        }

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

        theRB.velocity = new Vector2(velocity * moveSpeed, theRB.velocity.y);

        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("ySpeed", theRB.velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(theRB.velocity.x));

        if (theRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (theRB.velocity.x > 0)
        {
            transform.localScale = Vector3.one;
        }

        if (GravityController.instance.gcheck == false)
        {
            ClimbLadder();
        }

        if (powerUpCounter > 0)
        {
            powerUpCounter -= Time.deltaTime;
            if (powerUpCounter <= 0)
            {
                moveSpeed = speedStore;
                climbSpeed = climbStore;
            }
        }

    }
    public void Move(InputAction.CallbackContext context)
    {
        velocity = context.ReadValue<Vector2>().x;
        velocity2 = context.ReadValue<Vector2>().y; 
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started && isGrounded)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }

        if (!isGrounded && context.canceled && theRB.velocity.y > 0f)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, theRB.velocity.y * .5f);
        }
    }

    void ClimbLadder()
    {
        if (!myBody.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            theRB.gravityScale = gravityScaleAtStart;
            anim.SetBool("isClimbing", false);
            return;
        }

        Vector2 climbVelocity = new Vector2(theRB.velocity.x, velocity2 * climbSpeed);
        theRB.velocity = climbVelocity;
        theRB.gravityScale = 0f;

        bool playerVerticalSpeed = Mathf.Abs(theRB.velocity.y) > Mathf.Epsilon;
        anim.SetBool("isClimbing", playerVerticalSpeed);
    }

    public void Pick(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            checkpick.SetActive(true);
            anim.SetTrigger("isPicking");
            AudioManager.instance.PlaySFX(6);
        }

        if (context.canceled)
        {
            checkpick.SetActive(false);
        }
    }

    public void SetGravity(float gravityScale)
    {
        theRB.gravityScale = gravityScale;
    }

    public void SetSpeed(float speed, float speed2, float jump)
    {
        moveSpeed = speed;
        climbSpeed = speed2;
        jumpForce = jump;
    }

    IEnumerator FarDist()
    {
        distUI1.SetActive(true);
        distUI2.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
