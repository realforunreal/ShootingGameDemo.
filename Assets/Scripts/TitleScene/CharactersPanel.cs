using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Tab { Character, Abillity}

public class CharactersPanel : MonoBehaviour
{
    public InventoryContainer getItems, otherItems;
    public GameObject itemSlotPrefab, abillitySlotPrefab;

    [SerializeField]
    Tab myTab;
    [SerializeField]
    List<GameObject> charactersList;
    [SerializeField]
    List<GameObject> abillitysList;

    private void Start()
    {
        Create();
    }
    void Create()
    {
        StopAllCoroutines();
        myTab = Tab.Abillity;
        StartCoroutine(itemCreate(getItems, true));
        StartCoroutine(itemCreate(otherItems, false));
        IsActiveList(abillitysList, false);
        myTab = Tab.Character;
        StartCoroutine(itemCreate(getItems, true));
        StartCoroutine(itemCreate(otherItems, false));
    }
    public void TabClick(string tabState)
    {
        if(tabState == "Abillitys")
        {
            myTab = Tab.Abillity;
            IsActiveList(charactersList, false);
            IsActiveList(abillitysList, true);
        }
        else if(tabState == "Characters")
        {
            myTab = Tab.Character;
            IsActiveList(abillitysList, false);
            IsActiveList(charactersList, true);
        }
        else
        {
            Debug.Log("Cannot Find Tab data");
        }
    }

    void IsActiveList(List<GameObject> list, bool b)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].SetActive(b);
        }
    }
    private IEnumerator itemCreate(InventoryContainer container, bool isget)
    {
        if (myTab == Tab.Character)
        {
            for (int i = 0; i < container.pilotList.Count; i++)
            {
                GameObject clone = Instantiate(itemSlotPrefab, transform.transform);
                clone.GetComponent<CharacterSelectSlot>().item = container.pilotList[i];
                charactersList.Add(clone);
            }
        }
        else if(myTab == Tab.Abillity)
        {
            for (int i = 0; i < container.abillityList.Count; i++)
            {
                GameObject clone = Instantiate(abillitySlotPrefab, transform.transform);
                clone.GetComponent<AbillitySlot>().abillity = container.abillityList[i];
                abillitysList.Add(clone);
                //어빌리티 클론에 어빌리티 슬롯(새로 생성) 추가
            }
        }
        if (!isget)
        {
            //clone.GetComponent<CharacterSelectSlot>().character_Image.color /= 2f;
            //clone.GetComponent<UnityEngine.UI.Button>().interactable = false;
        }
        yield return null;
    }
}
