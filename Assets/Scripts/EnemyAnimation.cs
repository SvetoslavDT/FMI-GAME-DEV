using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{

    [SerializeField] private float idleThreshold = 0.1f;

    private Rigidbody2D rb;
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float speed = Mathf.Abs(rb.linearVelocity.x);
        anim.SetFloat("Speed", speed);
    }
}
