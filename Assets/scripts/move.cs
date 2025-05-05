using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField] private Talk dialogueSystem;
    [SerializeField] private float speed = 1f;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 move = new Vector2(moveX, moveY).normalized;

        if (dialogueSystem.IsActive == true)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            animator.enabled = false;
        }
        else
        {
            animator.enabled = true;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.velocity = move * speed;

            if (animator != null)
            {
                animator.SetFloat("MoveX", moveX);
                animator.SetFloat("MoveY", moveY);
                animator.SetBool("isMoving", move.sqrMagnitude > 0);
            }
        }
        
    }
}
