using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

[System.Serializable]
public class PilotData
{
    public string name;
    public float bulletPower;
    public int bulletNum;
    public string bulletType;
}

public static class SaveLoadManager
{
    public static void Save(PilotData myData)
    {
        string filePath = Application.dataPath + "Resources";
        FileStream fstream = File.Create(filePath);
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(fstream, myData);
        fstream.Close();
    }
    public static PilotData Load()
    {
        string filePath = Application.dataPath + "Resources";
        FileStream fstream = File.OpenRead(filePath);

        BinaryFormatter formatter = new BinaryFormatter();
        PilotData myData = formatter.Deserialize(fstream) as PilotData;

        fstream.Close();
        return myData;
    }
}
