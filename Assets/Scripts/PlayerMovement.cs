using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpForce = 10f;

    private float horizontal;
    private Rigidbody2D rb;

    private bool isJumping;
    private bool isOnGround;

    public bool IsOnGround => isOnGround;
    public float HorizontalInput => horizontal;
    public float CurrentSpeed => Mathf.Abs(horizontal);

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (!isJumping)
        {
            isJumping = Input.GetButtonDown("Jump") && isOnGround;
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);

        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = false;
            isOnGround = false;
        }
    }

    private void Flip()
    {
        if (Mathf.Abs(rb.linearVelocity.x) > 0.01f)
        {
            float lookDirection = rb.linearVelocity.x > 0 ? 1f : -1f;
            transform.localScale = new Vector3(lookDirection, 1f, 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CheckIfGrounded(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        CheckIfGrounded(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOnGround = false;
    }

    private void CheckIfGrounded(Collision2D collision)
    {
        isOnGround = false;

        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                isOnGround = true;
                return;
            }
        }
    }
}