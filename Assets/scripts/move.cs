using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField] float speed = 1f;
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
        Vector2 move = new Vector2(moveX, moveY);

        rb.velocity = move * speed;

        
        animator.SetFloat("MoveX", moveX);
        animator.SetFloat("MoveY", moveY);
        animator.SetBool("isMoving", move.sqrMagnitude > 0);
    }
}