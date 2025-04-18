using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float move_force = 10f;
    public float jump_force = 11f;
    private float movement_x;

    public Rigidbody2D my_body;
    private SpriteRenderer sprite;
    private Animator animator;

    // Constants
    private string WALK_ANIMATION = "Walk";
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";

    private bool is_grounded;

    private void Awake()
    {
        my_body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite  = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
    }

    private void FixedUpdate()
    {
        PlayerJump();
    }

    void PlayerMoveKeyboard()
    {
        movement_x = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movement_x, 0f, 0f) * Time.deltaTime * move_force;
    }

    void AnimatePlayer()
    {
        // Goes to the right side
        if (movement_x > 0)
        {
            animator.SetBool(WALK_ANIMATION, true);
            sprite.flipX = false; // Flips to the right side
        }
        // Goes to the left side
        else if (movement_x < 0)
        {
            animator.SetBool(WALK_ANIMATION, true);
            sprite.flipX = true; // Flips to the left side
        }
        // Stops the animation
        else
        {
            animator.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && is_grounded)
        {
            is_grounded = false; // Does not allow to jump second time
            my_body.AddForce(new Vector2(0f, jump_force), ForceMode2D.Impulse); //
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            is_grounded = true;
        }

        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject); // Destroys the current player object
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
}