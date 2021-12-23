using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsManager : MonoBehaviour
{
    public PartController partController;

    public void EnableParts(int partNum)
    {
        if (partController != null)
        {
            partController.EnableModelParts(partNum);
        }
        
    }

    public void ResetModelParts()
    {
        if (partController != null)
        {
            partController.ResetModel();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(partController == null)
        {
            Debug.Log("looking for partcontroller");
            partController = FindObjectOfType<PartController>().GetComponent<PartController>();
        }
        else
        {
            return;
        }
    }
}
