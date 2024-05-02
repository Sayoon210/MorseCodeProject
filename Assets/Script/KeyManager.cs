using System.IO;
using UnityEngine;


// 다른 스크립트에서 jumpKey 사용 예시
// KeyCode jumpKey = KeyManager.jumpKey;

public class KeyManager : MonoBehaviour
{
    public static KeyCode dotKey;
    public static KeyCode dashKey;

    void Awake()
    {
        LoadKeys();
    }

    void LoadKeys()
    {
        string path = Application.dataPath + "/keys.txt";
        if (File.Exists(path))
        {
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] keyValue = line.Split('=');
                string keyName = keyValue[0].Trim();
                string keyCode = keyValue[1].Trim();
                
                switch (keyName)
                {
                    case "dot":
                        dotKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), keyCode);
                        break;
                    case "dash":
                        dashKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), keyCode);
                        break;
                    // Handle other keys as needed
                }
            }
        }
        else
        {
            Debug.LogError("keys.txt not found!");
        }
    }
}