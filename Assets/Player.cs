using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    private float xInput;

    private int facingDir = 1;
    private bool facingRight = true;

    [Header("Collision info")]
    [SerializeField] private float groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    private bool isGrounded;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //de rigidbody tu gan vo gai tri rb
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frameS
    private void Update()
    {
        Movement();
        CheckInput();
        CollisionChecks();

        FlipController();
        AnimatorController();

    }

    private void CollisionChecks()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheck, whatIsGround);
    }

    private void CheckInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Movement()
    {
        rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

    }

    private void AnimatorController()
    {
        bool isMoving = rb.linearVelocity.x != 0;

        anim.SetBool("isMoving", isMoving);
    }

    private void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
    private void FlipController()
    {
        if (rb.linearVelocity.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (rb.linearVelocity.x < 0 && facingRight)
        {
            Flip();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundCheck));
    }
}