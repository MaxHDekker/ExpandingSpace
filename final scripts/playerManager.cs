using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class playerManager : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;

    public float jumpTime;
    private float jumpTimeCounter;

    private bool onPlatform;
    public LayerMask whatIsPlatform;

    private bool doubleJumped;

    private Collider2D myCollider;

    private Rigidbody2D myRigidbody;
    private bool IsTiming = false;
    public float seconds;
    private float speed;

    public Animator myAnimator;

    void beginTimer()
    {
        seconds = 5;
        IsTiming = false;
    }

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        myAnimator = GetComponent<Animator>();

        jumpTimeCounter = jumpTime;
    }

    void FixedUpdate()
    {
        handleLayers();
    }

    void Update()
    {
        if (IsTiming)
        {
            seconds -= Time.deltaTime;
        }
        if (seconds <= 0)
        {
            IsTiming = false;
            moveSpeed = 9;
            seconds = 5;

        }
        onPlatform = Physics2D.IsTouchingLayers(myCollider, whatIsPlatform);

        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);


        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (onPlatform)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            }
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
        {
            if (jumpTimeCounter > 0)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            jumpTimeCounter = 0;
        }

        if (onPlatform)
        {
            jumpTimeCounter = jumpTime;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void handleLayers()
    {
        if (!onPlatform)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Animator>().SetLayerWeight(1, 1);
        }
        else
        {
            GetComponent<Animator>().SetLayerWeight(1, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "powerup")
        {
            bonusPickup tempPowerup;
            tempPowerup = collision.gameObject.GetComponent<bonusPickup>();
            moveSpeed += 1;
            Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);

            IsTiming = true;
        }
    }
}