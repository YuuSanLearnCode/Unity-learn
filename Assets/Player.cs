using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private float moveSpeed ;
    [SerializeField]private float jumpForce ;

    private float xInput;
    

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

        AnimatorController();
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
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    private void AnimatorController()
    {
        bool isMoving = rb.linearVelocity.x != 0;

        anim.SetBool("isMoving", isMoving);
    }


}