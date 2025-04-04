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
            Debug.LogWarning("Animator bileþeni bulunamadý! Animasyonlar çalýþmayacaktýr.");
        }
    }

    void Update()
    {
        // Zemin kontrolü
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        if (animator != null)
        {
            // Zýplama animasyonunu kontrol et
            animator.SetBool("IsJumping", !isGrounded);
        }

        // Hareket ve zýplama iþlemleri
        MovePlayer();
        Jump();
    }

    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = new Vector3(moveHorizontal, 0, moveVertical).normalized;

        isWalking = moveDirection.magnitude > 0;  // Hareket ediyor mu?
        isRunning = isWalking && Input.GetKey(KeyCode.LeftShift);  // Shift tuþu ile koþma

        float speed = isRunning ? runSpeed : walkSpeed;
        Vector3 movement = moveDirection * speed;

        // linearVelocity kullanýmý
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z); // Zýplama için y'nin korunmasý

        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);  // Yumuþak dönüþ
        }

        // Animasyon parametrelerini güncelle
        if (animator != null)
        {
            // Yürüyüþ animasyonu
            animator.SetBool("IsWalking", isWalking && !isRunning);

            // Koþma animasyonu
            animator.SetBool("IsRunning", isRunning);

            Debug.Log("IsWalking: " + isWalking + " | IsRunning: " + isRunning);  // Animasyonlarýn tetiklendiðini görmek için Debug logu
        }
    }

    void Jump()
    {
        // Zýplama iþlemi: Sol Control tuþuna basýldýðýnda zýpla
        if (isGrounded && Input.GetKeyDown(KeyCode.LeftControl))  // Zýplama için LeftControl tuþu
        {
            isJumping = true;  // Zýplama baþladýðýnda true yap
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);  // Zýplama kuvvetini uygula
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
