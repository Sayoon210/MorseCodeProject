using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonControl : MonoBehaviour
{
    public void ClickToMain() 
    {
        Debug.Log("back");
        SceneManager.LoadScene("MainScene");
    }
    public void ClickToPuzzle() 
    {
        Debug.Log("backtopuzz");
        SceneManager.LoadScene("PuzzleMenuScene");
    }
    public void InitScene() {
        Debug.Log("status | Restarting the scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
