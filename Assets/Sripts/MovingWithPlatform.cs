using UnityEngine;

public class MovingWithPlatform : MonoBehaviour
{
    RaycastHit bottomnHit;

    private void FixedUpdate()
    {
        int Layer = LayerMask.GetMask("Floor");


        if (Physics.SphereCast(transform.position - Vector3.up + Vector3.up * 0.55f, 0.5f, Vector3.down, out bottomnHit, 0.5f, Layer))
        {
            transform.SetParent(bottomnHit.transform);
        }
        else 
        {
            transform.SetParent(null);
        }
    }
}
