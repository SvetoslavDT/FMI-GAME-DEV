using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;

    public float speed = 2f;
    public float detectionRange = 5f;
    public float sameLevelThreshold = 1f;

    public float groundCheckDistance = 1.2f;

    private Rigidbody2D rb;
    private int direction;

    private float damageCooldown = 1f;
    private float lastDamageTime;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distanceX = player.position.x - transform.position.x;
        float distanceY = Mathf.Abs(player.position.y - transform.position.y);

        bool isPlayerInRange = Mathf.Abs(distanceX) < detectionRange;
        bool isSameLevel = distanceY < sameLevelThreshold;

        if (isPlayerInRange && isSameLevel)
        {
            direction = (distanceX > 0) ? 1 : -1;
            Move();
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }

        
    }

    private void Move()
    {
        Vector2 origin = new Vector2(transform.position.x + direction * 0.5f, transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, groundCheckDistance);

        if (hit.collider == null)
        {
            direction *= -1;
            return;
        }

        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time - lastDamageTime > damageCooldown)
            {
                GameManager.instance.removeHealth();
                lastDamageTime = Time.time;
            }
        }
    }
}
