using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartController : MonoBehaviour
{
    public List<GameObject> partsList = new List<GameObject>();
    public List<GameObject> transparentPartsList = new List<GameObject>();

    public bool viewTransparentParts;


    public void EnableModelParts(int partNum)
    {
        ResetModel();

        for (int i = 0; i < partsList.Count; i++)
        {
            if (i == partNum)
            {
                partsList[i].SetActive(true);

            }
            else
            {
                partsList[i].SetActive(false);
            }
        }
        if (viewTransparentParts)
        {
            for (int j = 0; j < transparentPartsList.Count; j++)
            {
                if (j == partNum)
                {
                    transparentPartsList[j].SetActive(false);

                }
                else
                {
                    transparentPartsList[j].SetActive(true);
                }
            }
        }
    }

    public void ResetModel()
    {

        foreach(GameObject transparentObjects in transparentPartsList)
        {
            transparentObjects.SetActive(false);
        }

        for (int i = 0; i < partsList.Count; i++)
        {
            partsList[i].SetActive(true);

        }

        
    }
}