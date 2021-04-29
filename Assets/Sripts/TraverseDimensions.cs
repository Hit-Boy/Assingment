using UnityEngine;

public class TraverseDimensions : MonoBehaviour
{

    ChangeDimensions changeDimensionsScript;
    decimal currentWorld = 1m;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        changeDimensionsScript = player.GetComponent<ChangeDimensions>();
    }

    private void Update()
    {
        if (changeDimensionsScript.stateOfDimension != currentWorld)
        {
            Debug.Log("Checked " + changeDimensionsScript.stateOfDimension + " " + currentWorld);
            ChangeWorlds();
            currentWorld = changeDimensionsScript.stateOfDimension;
        }
    }
    private void ChangeWorlds()
    {   
        Renderer dimensionObjectRenderer = GetComponent<Renderer>();
        Collider dimensionObjectCollider = GetComponent<Collider>();
      //  Renderer shadowObjectRenderer = GetComponentInChildren<Renderer>();

        dimensionObjectCollider.enabled = !dimensionObjectCollider.enabled;
        dimensionObjectRenderer.enabled = !dimensionObjectRenderer.enabled;
       // shadowObjectRenderer.enabled = !shadowObjectRenderer.enabled;
    }
}
