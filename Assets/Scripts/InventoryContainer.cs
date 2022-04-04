using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName ="Data/InventoryContainer")]
public class InventoryContainer : ScriptableObject
{
    public List<Pilot> pilotList;
    public List<Abillity> abillityList;
}
