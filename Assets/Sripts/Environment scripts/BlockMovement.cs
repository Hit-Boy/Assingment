using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    [SerializeField]
    private Vector3 firstPointOfWay;

    [SerializeField]
    private Vector3 secondPointOfWay;

    [SerializeField]
    private float speed = 1f;

    [SerializeField]
    private bool repeatable = true;

    private Vector3 vectorToFirstPoint;
    private Vector3 vectorToSecondPoint;
    private float previousMagnitudeToFirstPoint;
    private float previousMagnitudeToSecondPoint;

    private float direction = 1f;
    private Vector3 wayVector;

    private void Start()
    {
        transform.position = firstPointOfWay;

        wayVector = secondPointOfWay - firstPointOfWay;
        vectorToFirstPoint = firstPointOfWay - transform.position;
        vectorToSecondPoint = secondPointOfWay - transform.position;

        previousMagnitudeToFirstPoint = vectorToFirstPoint.magnitude;
        previousMagnitudeToSecondPoint = vectorToSecondPoint.magnitude;

    }

    private void FixedUpdate()
    {
        if (direction == -1 && repeatable == false)
            direction = 0;
        
        transform.position += direction * wayVector * speed * Time.fixedDeltaTime;
        CheckPoints();
    }

    void CheckPoints()
    {
        vectorToFirstPoint = firstPointOfWay - transform.position;
        vectorToSecondPoint = secondPointOfWay - transform.position;

        float deltaMagnitudeToFirstPoint = vectorToFirstPoint.magnitude - previousMagnitudeToFirstPoint;
        float deltaMagnitudeToSecondPoint = vectorToSecondPoint.magnitude - previousMagnitudeToSecondPoint;

        if (Mathf.Sign(deltaMagnitudeToFirstPoint) == Mathf.Sign(deltaMagnitudeToSecondPoint))
        {
            direction *= -1;

            if (vectorToFirstPoint.magnitude > vectorToSecondPoint.magnitude)
            {
                transform.position = secondPointOfWay;
            }
            else
            {
                transform.position = firstPointOfWay;
            }
        }

        previousMagnitudeToFirstPoint = vectorToFirstPoint.magnitude;
        previousMagnitudeToSecondPoint = vectorToSecondPoint.magnitude;

    }

}
