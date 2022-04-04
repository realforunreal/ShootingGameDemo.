using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class UIManager : MonoBehaviour
{
    GameManager gamemanager;

    public Image p_Healthbar;
    Image p_Icon;
    string pilotIconName;

    [SerializeField]
    float playerHp;


    void Start()
    {
        gamemanager = GameManager.instance;
        playerHp = gamemanager.p_Hp;
        p_Healthbar = GameObject.Find("Hp_bar").GetComponent<Image>();
        p_Icon = GameObject.Find("Icon").GetComponent<Image>();
        pilotIconName = FindObjectOfType<BulletSet>().pilotName;
        PlayerIconLoad("PilotSprite/"+pilotIconName, p_Icon);
        FadeEffect fade = gamemanager.Instance.fade;
        fade.StartCoroutine(fade.Fade(1, 0));
    }

    AsyncOperationHandle handle;
    void PlayerIconLoad(string adress, Image img)
    {
        Addressables.LoadAssetAsync<Sprite>(adress).Completed
            += (AsyncOperationHandle<Sprite> obj) =>
            {
                handle = obj;
                img.sprite = obj.Result;
                //PilotSpriteUnload();
            };
    }

    void PilotSpriteUnload()
    {
        Addressables.Release("PilotSprite");
        Debug.Log("Unload PilotSprites");
    }

    void Update()
    {
        PlayerUI();
    }

    void PlayerUI()
    {
        p_Healthbar.fillAmount = gamemanager.p_Hp / playerHp;
    }
}
