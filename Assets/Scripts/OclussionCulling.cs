using UnityEngine;
using System.Collections.Generic;
public class OclussionCulling : MonoBehaviour
{
    public List<GameObject> objectsToCull;
    private List<GameObject> cullObjs = new List<GameObject>();
    public float distance, rangeMultiplier = 2f;
    void Start()
    {
        // Create a temporary list to store child objects
        List<GameObject> childObjects = new List<GameObject>();

        // Automatically add all child objects to the childObjects list
        foreach (GameObject obj in objectsToCull)
        {
            Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();
            foreach (Renderer renderer in renderers)
            {
                childObjects.Add(renderer.gameObject);
            }
        }

        // Add all child objects to the objectsToCull list
        objectsToCull.AddRange(childObjects);
        foreach (var platform in FindObjectsOfType<MovingPlatform>())
        {
            objectsToCull.Add(platform.gameObject);
        }
    }



    void Update()
    {
        // Update the distance variable based on the current camera position
        distance = Vector3.Distance(transform.position, Camera.main.transform.position) * rangeMultiplier;

        // Loop through all objects in the objectsToCull list and enable/disable them based on their distance from the camera
        foreach (GameObject obj in objectsToCull)
        {
            if (Vector3.Distance(obj.transform.position, Camera.main.transform.position) > distance)
            {
                if (obj.activeSelf && obj.tag != "IgnoreCulling")
                {
                    obj.SetActive(false);
                }
            }
            else
            {
                if (!obj.activeSelf && obj.tag != "IgnoreCulling")
                {
                    obj.SetActive(true);
                }
            }
        }
    }


}