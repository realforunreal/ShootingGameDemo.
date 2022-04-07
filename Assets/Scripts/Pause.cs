using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{

    public GameObject pausePanel;
    Image myimg;

    void Start()
    {
        myimg = GetComponent<Image>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamePause();
        }
    }
    public void GamePause()
    {
        Time.timeScale = 0;
        if(pausePanel != null && !pausePanel)
        {
            pausePanel.SetActive(true);
            myimg.enabled = false;
        }
        else if (pausePanel)
        {
            pausePanel.SetActive(false);
            Invoke("ResetTimeScale", 3);
            myimg.enabled = true;
        }
        else
        {
            Debug.Log("pausePanel can't find");
        }
    }
    void ResetTimeScale()
    {
        Time.timeScale = 1;
    }
}
