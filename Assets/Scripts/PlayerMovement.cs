using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Add this component to a GameObject to allow control of it via keyboard.
The Horizontal axis controlls will move the player left and right.
Pressing the space bar will cause the character to jump, but only if the character is in contact with a gameObject tagged with "Floor"
*/
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] LayerMask layer;

    public float movementSpeed = 5f;
    public float jumpForce = 500f;
    public SoundManagerScript SoundManager;
    Vector2 spawn;
    Animator camAnimator;
    Animator animator;

    public GameObject Shadow;

    public bool respawned = false;

    float xAxisInput = 0;

    public Dialog playerDialog;

    Transform freeze;
    float knockBackDir;
    float knockBackForce = 15;
    float timer = 0;

    bool addForce = false;

    Rigidbody2D rb;
    BoxCollider2D Collider;

    /// indicates wether the gameObject is touching a "Floor"


    public bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(Collider.bounds.center, Collider.bounds.size, 0f, Vector2.down, 0.05f, layer);

        return raycastHit2D.collider != null;

    }
    /// Add a vertical force equal to jumpForce
    public void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
        SoundManager.PlaySound("jump");
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        camAnimator = GameObject.Find("Main Camera").GetComponent<Animator>();
        Collider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        spawn = FindObjectOfType<StartSpawn>().transform.position;
    }


    private void Rotate() //takes character scale and change the face into the direction
    {
        Vector3 CharacterScale = transform.localScale;
        if (xAxisInput > 0)
        {
            CharacterScale.x = 1f;
        }
        else if (xAxisInput < 0)
        {
            CharacterScale.x = -1f;
        }
        transform.localScale = CharacterScale;
    }

    private void Update()
    {
        freeze = gameObject.transform;
        xAxisInput = Input.GetAxis("Horizontal");
        if (playerDialog.inDialog == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (IsGrounded())
                {
                    Shadow.SetActive(false);
                    animator.SetTrigger("Jump");
                    animator.SetBool("isJumping", true);
                    Jump();
                }
            }
            Rotate();
        }
        if(IsGrounded())
        {
            Shadow.SetActive(true);
        }
        else if(IsGrounded()==false)
        {
            Shadow.SetActive(false);
        }
        //if(xAxisInput !=0 && IsGrounded())
        //{
        //    StartCoroutine(soundDelay());
        //}
        animator.SetFloat("velocityY", rb.velocity.y);

        if (IsGrounded() && rb.velocity.y == 0)
        {
            animator.SetBool("isJumping", false);
        }

        IEnumerator soundDelay()
        {
            //SoundManager.PlaySound("walk");
            yield return new WaitForSeconds(0.5f);
        }
    }
    void FixedUpdate()
    {
        if (playerDialog.inDialog == false)
        {
            if (xAxisInput == 0)
            {
                animator.SetBool("isRuning", false);
            }
            else
            {
                animator.SetBool("isRuning", true);
            }
            rb.velocity = new Vector2(movementSpeed * xAxisInput, rb.velocity.y);
        }
        if (playerDialog.inDialog == true)
        {
            transform.position = freeze.transform.position;
        }
        if (addForce && ((timer += Time.deltaTime) < 0.2f))
        {
            Respawn();
            rb.velocity = (new Vector2(knockBackDir, 0.3f) * knockBackForce);
        }
        else
        {
            addForce = false;
            timer = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag.Contains("Spikes"))
        {

            GetknockBackDir(other);
            camAnimator.SetTrigger("Hart");
            addForce = true;
        }
        if (other.gameObject.CompareTag("Spikes"))
        {
            SoundManager.PlaySound("damage");
        }
    }


   
    void GetknockBackDir(Collision2D collider)
    {
        Vector2 playerPos = transform.position;
        Vector2 colliderPos = collider.transform.position;

        if (playerPos.x < colliderPos.x)
        {
            knockBackDir = -1;
        }
        else
        {
            knockBackDir = 1;
        }
    }

    void Respawn()
    {
        transform.position = spawn;
        respawned = true;
    }
}
