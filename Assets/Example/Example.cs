using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    [EnumData(typeof(TextStyle))]
    public TextData[] textData;
    public void Write(TextStyle style)
    {
        Debug.Log("Using size" + textData[(int)style]);
    }

    private void Start()
    {
        Write(TextStyle.Big);
    }
}

public enum TextStyle
{
    Medium,
    Tiny,
    Small,
    Big,
    Huge
}

[System.Serializable]
public class TextData
{
    public int size;
    public Color color;
}
