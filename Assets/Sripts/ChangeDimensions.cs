using UnityEngine;

public class ChangeDimensions : MonoBehaviour
{

    public decimal stateOfDimension = 1m;
    
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            switch (stateOfDimension)
            {
                case 1:
                    stateOfDimension = 2m;
                    break;
                case 2:
                    stateOfDimension = 1m;
                    break;
                default:
                    Debug.Log("ChangeDimensions broke");
                    break;

            }
        }

    }
}
