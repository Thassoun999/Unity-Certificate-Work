using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelManipulationManager : MonoBehaviour
{
    public PartController partController;

    public Slider scaleSlider;
    public Slider rotateSlider;

    Transform spawnedObjectTransformValues;

    public void EnableParts(int partNum)
    {
        if (partController != null)
        {
            partController.EnableModelParts(partNum);
        }

    }

    public void ResetModelTransform()
    {
        if (partController != null)
        {
            partController.gameObject.transform.position = spawnedObjectTransformValues.position;
            partController.gameObject.transform.rotation = spawnedObjectTransformValues.rotation;
            partController.gameObject.transform.localScale = spawnedObjectTransformValues.localScale;
            scaleSlider.value = 1;
            rotateSlider.value = 1;
        }
    }

    public void UpdateObjectRotationScale()
    {
        partController.gameObject.transform.eulerAngles = new Vector3(0, rotateSlider.value*360, 0);
        partController.gameObject.transform.localScale = new Vector3(scaleSlider.value, scaleSlider.value, scaleSlider.value);
        Debug.Log("in method- updateobjectrotationscale");
    }

    
    void Update()
    {
        if (partController == null)
        {
            Debug.Log("looking for partcontroller");
            partController = FindObjectOfType<PartController>().GetComponent<PartController>();
            spawnedObjectTransformValues = partController.gameObject.transform;
        }
        else
        {
            UpdateObjectRotationScale();
            Debug.Log("updateobjectrotationscale");
        }
    }
}