using UnityEngine;

public static class TraverseWorlds 
{

    private static void ChangeWorlds(GameObject[] firstWorld, GameObject[] secondWorld)
    {
        foreach (GameObject item in firstWorld)
        { 
            Collider itemCollider = item.GetComponent<Collider>();
            Renderer itemRenderer = item.GetComponent<Renderer>();
            itemCollider.enabled = !itemCollider.enabled;
            itemRenderer.enabled = !itemRenderer.enabled;

        }

        foreach (GameObject item in secondWorld)
        {
            Collider itemCollider = item.GetComponent<Collider>();
            Renderer itemRenderer = item.GetComponent<Renderer>();
            itemCollider.enabled = !itemCollider.enabled;
            itemRenderer.enabled = !itemRenderer.enabled;
        }
    }
}
