using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonControl : MonoBehaviour
{
    public AudioClip buttonSound;
    private AudioSource audioSource;
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
    public void InitScene()
    {
        Debug.Log("status | Restarting the scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void PlayButtonClickSound()
    {
        if (buttonSound != null)
        {
            audioSource.clip = buttonSound;
            audioSource.Play();
            Debug.Log("sound start | CLICK!!!");
        }
        else
        {
            Debug.LogWarning("Button Click sound clip is not assigned!");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
