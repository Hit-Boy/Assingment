using UnityEngine;

public class MovingWithPlatform : MonoBehaviour
{
    RaycastHit bottomnHit;
    Vector3 ordinaryScale;
    Vector3 inversedScale;
    
    private void Start()
    {
        ordinaryScale = transform.localScale;
    }
    private void FixedUpdate()
    {
        int Layer = LayerMask.GetMask("Floor");


        if (Physics.SphereCast(transform.position - Vector3.up + Vector3.up * 0.55f, 0.5f, Vector3.down, out bottomnHit, 0.5f, Layer))
        {
            GameObject platform = bottomnHit.transform.gameObject;
            inversedScale = new Vector3(1/platform.transform.localScale.x, 1/platform.transform.localScale.y, 1/transform.localScale.z);
            
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
