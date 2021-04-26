using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    Transform player;


    // private Quaternion cameraRotation = PlayerMovement.targetRotation;
    [SerializeField]
    private float yOffset = 7f;
    [SerializeField]
    private float zOffset = -10;
    [SerializeField]
    private float rotationSpeed = 1;
    private Vector3 beforeCheckTransform;
    private Quaternion baseRotation = Quaternion.Euler(20f, 0f, 0f);
    private Vector3 offsetPosition;

    private void Start()
    {
        
        offsetPosition = new Vector3(0f, yOffset, zOffset);
        transform.position = player.transform.position + offsetPosition;
        transform.rotation = baseRotation;
    }
    void Update()
    {
        Quaternion mouseRotation = Quaternion.Euler(0f, Input.GetAxis("Mouse X") * rotationSpeed, 0f);
        transform.rotation = mouseRotation * transform.rotation;
        offsetPosition = mouseRotation * offsetPosition;
        transform.position = player.position + offsetPosition;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offsetPosition;
    }

    void CheckVisibility()
    { 
    
    }
}