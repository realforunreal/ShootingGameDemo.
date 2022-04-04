using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbillitySlot : MonoBehaviour
{
    public Abillity abillity;

    public Image abillityIcon;
    public Image[] level;

    public GameObject dataBox;


    public void OnClick()
    {
        abillity.level++;
        for(int i = 0; i < abillity.level; i++)
        {
            //level[i].GetComponent<AbillityLevel>().levelPref
        }
    }

}
