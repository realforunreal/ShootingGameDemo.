using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour
{
    [Range(0.01f, 10.0f)]
    public float fadeTime;
    [SerializeField]
    AnimationCurve fadeCurve;
    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public IEnumerator Fade(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;
        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            Color color = image.color;
            color.a = Mathf.Lerp(start, end, fadeCurve.Evaluate(percent));
            image.color = color;
            yield return null;
        }
    }
}
