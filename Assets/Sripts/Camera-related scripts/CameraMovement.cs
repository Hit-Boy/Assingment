using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    Transform player;


    // private Quaternion cameraRotation = PlayerMovement.targetRotation;
    [SerializeField]
    private float yOffset = 3f;
    [SerializeField]
    private float zOffset = -6f;
    [SerializeField]
    private float rotationSpeed = 1f;
    [SerializeField]
    private float baseXRotation = 15f;
    private Quaternion baseRotation;
    private Vector3 offsetPosition;

    private void Start()
    {
        baseRotation = Quaternion.Euler(baseXRotation, 0f, 0f);

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