// 빌드 인덱스를 쓰는 것이 올바를 것이지만, 딱히 실력이 아직 없기 때문에 쉬운 방향으로 간다!!!!!!


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private VisualElement _buttonContainer;
    private Button _buttonStart;
    private Button _buttonPuzzle;
    private Button _buttonMultiplay;
    private Button _buttonExit;


    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        _buttonContainer = root.Q<VisualElement>("ButtonContainer");
        _buttonStart = root.Q<Button>("StartButton");
        _buttonPuzzle = root.Q<Button>("PuzzleButton");
        _buttonMultiplay = root.Q<Button>("MultiButton");
        _buttonExit = root.Q<Button>("ExitButton");

        _buttonStart.RegisterCallback<ClickEvent>(StartSceneChanger);
        _buttonPuzzle.RegisterCallback<ClickEvent>(PuzzleSceneChanger);
        _buttonMultiplay.RegisterCallback<ClickEvent>(MultiSceneChanger);
        _buttonExit.RegisterCallback<ClickEvent>(ExitGame);
    }

    public void LoadSpecificScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void StartSceneChanger(ClickEvent evt)
    {
        LoadSpecificScene("StartScene");
    }

    private void MultiSceneChanger(ClickEvent evt)
    {
        LoadSpecificScene("MultiplayScene");
    }

    private void PuzzleSceneChanger(ClickEvent evt)
    {
        LoadSpecificScene("PuzzleMenuScene");
    }

    private void ExitGame(ClickEvent evt)
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }



    // Update is called once per frame
    void Update()
    {

    }
}
