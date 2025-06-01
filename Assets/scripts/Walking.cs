using UnityEngine;

public class Walking: MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform groundCheck;
    public float groundCheckDistance = 0.5f;
    public LayerMask obstacleLayer;

    private Vector2 moveDirection = Vector2.right;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Рух
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Анімація
        animator.SetFloat("MoveX", moveDirection.x);
        animator.SetFloat("MoveY", moveDirection.y);

        // Перевірка на перешкоду попереду
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, moveDirection, groundCheckDistance, obstacleLayer);
        if (hit.collider != null && hit.collider.gameObject.CompareTag("WallRichochet"))
        {
            // Зміна напрямку руху
            moveDirection *= -1;

            // Візуальний розворот (якщо потрібно)
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

   

    private void OnDrawGizmosSelected()
    {
        // Відображення рейкаста у редакторі
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(groundCheck.position, groundCheck.position + (Vector3)(moveDirection.normalized * groundCheckDistance));
        }
    }
}
