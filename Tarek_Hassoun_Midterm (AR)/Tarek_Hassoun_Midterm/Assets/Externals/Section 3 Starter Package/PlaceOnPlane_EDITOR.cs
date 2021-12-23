using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Author: Tim Kanellitsas , KairosXR
/// Edited by: Andy Jevsevar , KairosXR
///
/// Responsibilities:
/// 1. Spawns an object
///
/// How to use:
/// Add it to an empty gameobject. We called the empty gameobject "ObjectSpawner"
/// </summary>

public class PlaceOnPlane_EDITOR : MonoBehaviour
{
    public GameObject objectToSpawn;
    GameObject spawnedObject;
    Camera currentCamera;
    Ray raycast;
    RaycastHit hit;
    int layerMask = 1 << 9;
    private int fingerID = -1;
    private void Awake()
    {
        currentCamera = FindObjectOfType<Camera>();
#if !UNITY_EDITOR
     fingerID = 0; 
#endif
    }

    //check to see if screen touch is over a UI object
    private void Update()
    {
                SpawnObject();
    }

    //If not over a UI element, call the TouchScreenToPlane method (below)
    public void SpawnObject()
    {
            if (Application.isEditor)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    TouchScreenToPlane();
                }
            }

            if (Application.isMobilePlatform)
            {
                if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
                {
                    TouchScreenToPlane();
                }
            }
        
    }


    //Raycast from screen touch/mouse to intersection with collider, and instantiate an object
    public void TouchScreenToPlane()
    {
        if (Application.isEditor)
        {
            raycast = currentCamera.ScreenPointToRay(Input.mousePosition);
        }

        if (Application.isMobilePlatform)
        {

            raycast = currentCamera.ScreenPointToRay(Input.GetTouch(0).position);
        }

        
        if (Physics.Raycast(raycast, out hit))
        {
            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(objectToSpawn, hit.point, hit.transform.rotation);
            }
            else
            {
                spawnedObject.transform.position = hit.point;
            }
        }
    }
}