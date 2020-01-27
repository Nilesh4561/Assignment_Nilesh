using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem{

    public static void SaveScore()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/score.hide";
        FileStream stream = new FileStream(path, FileMode.Create);

        HighScoreData data = new HighScoreData();

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static HighScoreData LoadData()
    {
        string path = Application.persistentDataPath + "/score.hide";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            HighScoreData data = formatter.Deserialize(stream) as HighScoreData;
            stream.Close();
            Debug.Log("file present");
            return data;
            
        }
        else
        {
            Debug.LogError("file not found !" + path);
            return null;
        }
    }

}
