using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public List<GameObject> uIMenus = new List<GameObject>();

    public void SwitchUI(int partNum)
    {
        for (int i = 0; i < uIMenus.Count; i++)
        {
            if (i == partNum)
            {
                uIMenus[i].SetActive(true);

            }
            else
            {
                uIMenus[i].SetActive(false);
            }

        }
    }
}
