using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectSceneManager : MonoBehaviour
{
    public List<EquipCharacterSlot> equipSlots;

    public Pilot selectItem;
    public CharacterSelectSlot selectSlot;

    public GameObject characterPanel;

    private void Start()
    {
        characterPanel.SetActive(false);
    }

    public void OnSelectPanel()
    {
        characterPanel.SetActive(true);
        iTween.ScaleFrom(characterPanel, new Vector3(0.1f, 0.1f, 1f), 2f);
    }

    public void OnStart()
    {
        if (selectItem != null)
        {
            SavePilot();
            StopAllCoroutines();
            StartCoroutine(ToGame());
        }
    }

    public void SavePilot()
    {
        PilotData data = new PilotData();
        data.name = selectItem.name;
        data.bulletNum = selectItem.bulletnum;
        data.bulletPower = selectItem.bulletPower;
        data.bulletType = selectItem.bulletType;
        SaveLoadManager.Save(data);
        Debug.Log(data.name);
    }

    IEnumerator ToGame()
    {
        FadeEffect fade = GameManager.instance.fade;
        fade.gameObject.SetActive(true);
        StartCoroutine(fade.Fade(0, 1));
        yield return new WaitForSeconds(fade.fadeTime);
        SceneManager.LoadScene("GameScene");
        StartCoroutine(fade.Fade(1, 0));
        yield return new WaitForSeconds(fade.fadeTime);
    }
}
