using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelectSlot : MonoBehaviour
{
    public Image character_Image;
    public GameObject selectBox;
    public GameObject pilotDataBox;
    public TextMeshProUGUI pilotText;
    [SerializeField]
    Tab mytab;

    public Pilot item;

    [SerializeField] bool selected = false;

    SelectSceneManager manager;

    void Start()
    {
        selectBox.gameObject.SetActive(false);
        character_Image.sprite = item.icon;
        manager = GameObject.Find("SelectSceneManager").GetComponent<SelectSceneManager>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(notSelect());
        }
    }
    public void OnClick()
    {
        if (manager.selectItem != item || manager.selectItem == null)
        {
            selected = true;
            selectBox.gameObject.SetActive(true);
            manager.selectItem = item;
            manager.selectSlot = this;
            pilotDataBox.gameObject.SetActive(true);
            pilotText.text = "Bullet : " + item.bulletnum + "\nBulletDamage : " + item.bulletPower
            + "\nShotSpeed : " + item.shotTime + "\nShotType : " + item.bulletType;

            //++Character Select Animation Run
        }
    }
    IEnumerator notSelect()
    {
        if (manager.selectSlot != this)
        {
            selectBox.gameObject.SetActive(false);
            pilotDataBox.gameObject.SetActive(false);
        }
        yield return null;
    }
}
