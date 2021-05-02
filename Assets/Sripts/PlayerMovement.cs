using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody playerRigidbody;

    [SerializeField]
    Transform Camera;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float rotationSpeed = 150f;
    [SerializeField]
    private float jumpHeight = 2f;
    [SerializeField]
    private float fallMultiplier = 3.5f;
    [SerializeField]
    private float lowJumpMultiplier = 2f;


    private float inputX;
    private float inputZ;
    private bool jumpAvailability;
    private float targetRotation;

    void Start()
    {
      
        playerRigidbody = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector3 movementDirection = new Vector3(inputX, 0f, inputZ);
        if (movementDirection.magnitude > 0.1f)
        {
            targetRotation = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, targetRotation, 0f) * Quaternion.Euler(0f, Camera.eulerAngles.y, 0f), rotationSpeed * Time.fixedDeltaTime);
            transform.position += Quaternion.Euler(0f, Camera.eulerAngles.y, 0f) * movementDirection * speed * Time.fixedDeltaTime;
        }

        Jump();
        JumpTweaking();
    }

    void Jump()
    {
        int Layer = LayerMask.GetMask("Floor");
        RaycastHit hit;
        jumpAvailability = Physics.SphereCast(transform.position - Vector3.up + Vector3.up * 0.55f, 0.5f, Vector3.down, out hit, 0.5f, Layer);

        if (jumpAvailability)
            if (Input.GetKeyDown("space") || Input.GetKey("space"))
            {
                Debug.Log(1);
                playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, 0f, playerRigidbody.velocity.z);
                playerRigidbody.AddForce(Vector3.up * (float)Mathf.Sqrt(jumpHeight * (2 * 9.81f)), ForceMode.VelocityChange);
            }
    }

    void JumpTweaking()
    {
        if (playerRigidbody.velocity.y < 0f)
        {
            playerRigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1f) * Time.fixedDeltaTime;
        }
        else if (playerRigidbody.velocity.y > 0f && !Input.GetKey("space"))
        {
            playerRigidbody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1f) * Time.fixedDeltaTime;
        }
    }


}
