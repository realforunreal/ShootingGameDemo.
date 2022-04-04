using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public UnityEngine.UI.Image img;

    public List<GameObject> Items ;
    public float lootEnergy;
    public float currentLootEnergy;
    public int lootEnergyStage;

    private void Start()
    {
        img = GameObject.Find("Loot_bar").GetComponent<UnityEngine.UI.Image>();
    }

    private void Update()
    {
        LootSystem();
        img.fillAmount =  currentLootEnergy/ lootEnergy;
    }

    void LootSystem()       //경험치
    {
        if (currentLootEnergy >= lootEnergy)
        {
            currentLootEnergy = currentLootEnergy - lootEnergy;
            lootEnergyStage++;
            lootEnergy = lootEnergy * 1.5f * lootEnergyStage;
            ItemSpawn();
        }
    }
    void ItemSpawn()
    {
        Instantiate(Items[Random.Range(0, Items.Count)], transform.position, transform.rotation);
    }


}
