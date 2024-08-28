using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Puzzle1Manager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject gameClearUI;
    static public string puzzle_1;
    private bool isGameOver = false;
    private bool isGameCleared = false;
    public TMP_InputField inputField;  // 유니티 에디터에서 (textmeshpro)InputField를 할당합니다.
    public Button submitButton;    // 유니티 에디터에서 Button을 할당합니다.
    void Start()
    {
        InitializeGame();
    }

    void InitializeGame()
    {
        Debug.Log("Initializing game...");

        // 모듈화된 변수 불러오기
        puzzle_1 = KeyManager.puzzle_1;
        submitButton.onClick.AddListener(OnSubmitButtonClicked);

        gameOverUI.SetActive(false);
        gameClearUI.SetActive(false);
        isGameOver = false;
        isGameCleared = false;

        Debug.Log($"Answer is | {puzzle_1}");
        Debug.Log($"isGameOver: {isGameOver}, isGameCleared: {isGameCleared}");
    }

    void Update()
    {
        if(isGameCleared == true || isGameOver == true) {
            OnDestroy();
        }
    }

    
    // SubmitButton이 클릭될 때 호출되는 메서드
    void OnSubmitButtonClicked()
    {
        // InputField의 값을 가져옵니다.
        string inputValue = inputField.text;
        string targetString = puzzle_1;

        // 입력값을 주어진 문자열과 비교합니다.
        if (inputValue == targetString)
        {
            Debug.Log("입력값이 일치합니다!");
            TriggerGameClear();
        }
        else
        {
            Debug.Log("입력값이 일치하지 않습니다...");
            TriggerGameOver();
        }
    }
    void OnDestroy()
    {
        // 이벤트 등록 해제
        submitButton.onClick.RemoveListener(OnSubmitButtonClicked);
    }
    void TriggerGameClear()
    {
        isGameCleared = true;
        gameClearUI.SetActive(true);
        Debug.Log("Game Clear!");
    }

    void TriggerGameOver()
    {
        isGameOver = true;
        gameOverUI.SetActive(true);
        Debug.Log("Game Over!");
    }
}
