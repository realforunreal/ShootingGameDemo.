using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleDirector : MonoBehaviour
{
    public GameObject titleImage;
    public Button startButton;

    private void Start()
    {
        //타이틀 애니메이션
        iTween.MoveTo(titleImage.gameObject, iTween.Hash(
            "easeType", "easeOutBounce",
            "Time", 2.0f,
            "y", 1200f
            ));
        //시작버튼 애니메이션
        iTween.MoveTo(startButton.gameObject, iTween.Hash(
            "easeType", "easeOutElastic",
            "Time", 4.0f,
            "x", 450
            ));
    }
}
