using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public static KeyCode dotKey;
    public static KeyCode dashKey;
    public static string puzzle_1;
    public static List<string> puzzle_2;
    public static string puzzle_3;
    

    void Awake()
    {
        LoadKeys();
    }

    void LoadKeys()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "keys.json");
        if (File.Exists(path))
        {
            string jsonString = File.ReadAllText(path);

            // Deserialize JSON using JsonUtility
            Keys keys = JsonUtility.FromJson<Keys>(jsonString);

            // Convert string array to char list
            puzzle_1 = keys.PUZZLE_1;
            puzzle_2 = new List<string>();
            puzzle_3 = keys.PUZZLE_3;
            foreach (string s in keys.PUZZLE_2)
            {
                if (s.Length == 1)
                {
                    puzzle_2.Add(s);
                }
            }

            dotKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), keys.DOTKEY);
            dashKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), keys.DASHKEY);
            Debug.Log($"Key Code is {dotKey} {dashKey}");
        }
        else
        {
            Debug.LogError("keys.json not found!");
        }
    }

    // Define a class to represent the structure of the JSON file
    [System.Serializable]
    private class Keys
    {
        public string DOTKEY;
        public string DASHKEY;
        public string PUZZLE_1;
        public string[] PUZZLE_2; // Changed to string array
        public string PUZZLE_3; // Changed to string array
        // Add properties for other keys as needed
    }
}
