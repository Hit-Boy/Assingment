using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody playerRigidbody;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private Transform Camera;
    [SerializeField]
    private float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();

    }

    
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 movementDirection = new Vector3 (Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized; 

        if (movementDirection.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg + Camera.eulerAngles.y;
            float actualAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, actualAngle, 0f);

            Vector3 direction = Quaternion.Euler(0f, actualAngle, 0f) * Vector3.forward;
            // Debug.Log(direction.normalized + "hey");
           // playerRigidbody.AddForce(Vector3.forward, ForceMode.VelocityChange);
         //   playerRigidbody.AddForce(direction.normalized * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
            playerRigidbody.velocity = direction.normalized * speed * Time.fixedDeltaTime;
            Debug.Log(playerRigidbody.velocity);
        }

        playerRigidbody.velocity = new Vector3(0f, playerRigidbody.velocity.y, 0f); 
    }
}
