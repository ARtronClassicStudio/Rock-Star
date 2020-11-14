using UnityEngine;
using System.Runtime.Serialization.Formatters;
using System.IO;

public class SaveData : MonoBehaviour
{


    public GameManager player;
    public string path = "Assets/test.bin";

    private void OnApplicationQuit()
    {
        File.WriteAllText(path, JsonUtility.ToJson(player));
    }

    private void Start()
    {
        if (!File.Exists(path))
        {
            File.WriteAllText(path, JsonUtility.ToJson(player));
          
        }
        else
        {

         JsonUtility.FromJsonOverwrite(File.ReadAllText(path), player);

        }


    }
}
