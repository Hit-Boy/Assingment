using UnityEngine;

public class MovingWithPlatform : MonoBehaviour
{
    RaycastHit bottomnHit;
    Vector3 ordinaryScale;
    
    private void Start()
    {
        ordinaryScale = transform.localScale;
    }
    private void FixedUpdate()
    {
        int Layer = LayerMask.GetMask("Floor");


        if (Physics.SphereCast(transform.position - Vector3.up + Vector3.up * 0.55f, 0.5f, Vector3.down, out bottomnHit, 0.5f, Layer) && bottomnHit.transform.gameObject.CompareTag("Moving"))
        {
            GameObject platform = bottomnHit.transform.gameObject; 
            Transform emptyObject = platform.transform.Find("GameObject");
            transform.SetParent(emptyObject);
           // transform.localScale = ordinaryScale;
        }
        else 
        {
            transform.SetParent(null);
            transform.localScale = ordinaryScale;
        }
    }
}
