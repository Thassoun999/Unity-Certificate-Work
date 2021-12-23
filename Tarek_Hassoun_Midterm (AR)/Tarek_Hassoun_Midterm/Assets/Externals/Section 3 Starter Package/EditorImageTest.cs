using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorImageTest : MonoBehaviour
{
    public GameObject spawnedObject;
    public bool isSpawned;
    public GameObject image;


    RaycastHit hit;

    GameObject spawnedObjectClone;

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.transform.tag == "EditorTest" && !isSpawned)
            {
                spawnedObjectClone = Instantiate(spawnedObject, hit.transform.position, hit.transform.rotation);
                spawnedObjectClone.transform.SetParent(hit.collider.gameObject.transform);
                isSpawned = true;
            }
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Hit Image");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);

            if (spawnedObjectClone != null)
            { 
                Destroy(spawnedObjectClone);
            }
            isSpawned = false;


            Debug.Log("Did not Hit");
        }
    }
}