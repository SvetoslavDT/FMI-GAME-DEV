using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private Animator animator;

    private void Reset()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        if (!animator) animator = GetComponent<Animator>();
        if (!movement) movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        animator.SetFloat("Speed", movement.CurrentSpeed);
        animator.SetBool("IsGrounded", movement.IsOnGround);

        if (Input.GetButtonDown("Jump") && movement.IsOnGround)
        {
            animator.SetTrigger("Jump");
        }
    }

    public void PlayHurt()
    {
        animator.SetTrigger("Hurt");
    }
}