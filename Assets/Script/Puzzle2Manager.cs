using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2Manager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject gameClearUI;
    public GameObject buttons;
    public KeyCode dotKey;
    public KeyCode dashKey;
    public List<string> puzzle_2;
    public List<KeyCode> puzzle_2_keycode;

    private bool isGameOver = false;
    private bool isGameCleared = false;
    private int answerIdx = 0;

    void Start()
    {
        InitializeGame();
    }

    void InitializeGame()
    {
        Debug.Log("Initializing game...");
        dotKey = KeyManager.dotKey;
        dashKey = KeyManager.dashKey;
        puzzle_2 = KeyManager.puzzle_2;

        gameOverUI.SetActive(false);
        gameClearUI.SetActive(false);
        buttons.SetActive(true);
        answerIdx = 0;
        isGameOver = false;
        isGameCleared = false;
        Debug.Log($"lenofAnswer | {puzzle_2.Count}");
        Debug.Log($"isGameOver: {isGameOver}, isGameCleared: {isGameCleared}");
    }

    void Update()
    {
        if (!isGameCleared && !isGameOver)
        {
            if (Input.anyKeyDown)
            {
                Debug.Log("KeyDown detected");
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
                {
                    Debug.Log("Mouse button pressed, ignoring.");
                }
                else if (Input.inputString == puzzle_2[answerIdx])
                {
                    answerIdx++;
                    Debug.Log($"Correct answer: {puzzle_2[answerIdx - 1]}");
                    if (answerIdx >= puzzle_2.Count)
                    {
                        isGameCleared = true;
                        StartCoroutine(WaitForEvent());
                    }
                }
                else
                {
                    Debug.Log($"Incorrect answer: {Input.inputString}");
                    TriggerGameOver();
                }
            }
        }
    }

    IEnumerator WaitForEvent()
    {
        Debug.Log("WaitForEvent started");
        yield return new WaitForSecondsRealtime(0.2f);
        TriggerGameClear();
        Debug.Log("0.2 seconds have passed.");
    }

    void TriggerGameClear()
    {
        isGameCleared = true;
        gameClearUI.SetActive(true);
        buttons.SetActive(false);
        Time.timeScale = 0f;
        Debug.Log("Game Clear!");
    }

    void TriggerGameOver()
    {
        isGameOver = true;
        gameOverUI.SetActive(true);
        buttons.SetActive(false);
        Time.timeScale = 0f;
        Debug.Log("Game Over!");
    }
}
