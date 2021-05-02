using UnityEngine;

public class RepeatableBlockMovement : MonoBehaviour
{
    [SerializeField]
    private Vector3 firstPointOfWay;

    [SerializeField]
    private Vector3 secondPointOfWay;

    [SerializeField]
    private float speed = 1f;

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
