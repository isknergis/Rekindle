using UnityEngine;

public class PContr1 : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpForce = 7f;

    private Rigidbody rb;
    private Animator animator;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private bool isGrounded = false;
    private bool isWalking = false;
    private bool isRunning = false;
    private bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogWarning("Animator bile�eni bulunamad�! Animasyonlar �al��mayacakt�r.");
        }
    }

    void Update()
    {
        // Zemin kontrol�
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        if (animator != null)
        {
            // Z�plama animasyonunu kontrol et
            animator.SetBool("IsJumping", !isGrounded);
        }

        // Hareket ve z�plama i�lemleri
        MovePlayer();
        Jump();
    }

    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = new Vector3(moveHorizontal, 0, moveVertical).normalized;

        isWalking = moveDirection.magnitude > 0;  // Hareket ediyor mu?
        isRunning = isWalking && Input.GetKey(KeyCode.LeftShift);  // Shift tu�u ile ko�ma

        float speed = isRunning ? runSpeed : walkSpeed;
        Vector3 movement = moveDirection * speed;

        // linearVelocity kullan�m�
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z); // Z�plama i�in y'nin korunmas�

        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);  // Yumu�ak d�n��
        }

        // Animasyon parametrelerini g�ncelle
        if (animator != null)
        {
            // Y�r�y�� animasyonu
            animator.SetBool("IsWalking", isWalking && !isRunning);

            // Ko�ma animasyonu
            animator.SetBool("IsRunning", isRunning);

            Debug.Log("IsWalking: " + isWalking + " | IsRunning: " + isRunning);  // Animasyonlar�n tetiklendi�ini g�rmek i�in Debug logu
        }
    }

    void Jump()
    {
        // Z�plama i�lemi: Sol Control tu�una bas�ld���nda z�pla
        if (isGrounded && Input.GetKeyDown(KeyCode.LeftControl))  // Z�plama i�in LeftControl tu�u
        {
            isJumping = true;  // Z�plama ba�lad���nda true yap
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);  // Z�plama kuvvetini uygula
        }
    }

    void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
