using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipCharacterSlot : MonoBehaviour
{
    public Pilot item;
    public Image CharacterImage;

    public SelectSceneManager manager;

    public void OnSelect()
    {
        if (manager.selectItem != null)
        {
            item = manager.selectItem;
            CharacterImage.sprite = item.icon;
            manager.selectItem = null;
            manager.selectSlot.selectBox.gameObject.SetActive(false);
            manager.selectSlot = null;
        }
    }
}
