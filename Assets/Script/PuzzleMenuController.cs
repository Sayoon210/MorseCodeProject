// 빌드 인덱스를 쓰는 것이 올바를 것이지만, 딱히 실력이 아직 없기 때문에 쉬운 방향으로 간다!!!!!!


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PuzzleMenuController : MonoBehaviour
{
    private VisualElement _buttonContainer;
    private Button _Puzzle1;
    private Button _Puzzle2;
    // private Button _buttonMultiplay;
    private Button _Puzzle3;
    private Button _Back;

   void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        _buttonContainer = root.Q<VisualElement>("ButtonContainer");
        _Puzzle1 = root.Q<Button>("Puzzle1");
        _Puzzle2 = root.Q<Button>("Puzzle2");
        _Puzzle3 = root.Q<Button>("Puzzle3");
        _Back = root.Q<Button>("Back");

        //_Puzzle1.RegisterCallback<ClickEvent>(PuzzleChanger1);
        _Puzzle2.RegisterCallback<ClickEvent>(PuzzleChanger2);
        //_Puzzle3.RegisterCallback<ClickEvent>(PuzzleChanger3);
        _Back.RegisterCallback<ClickEvent>(Back);
    
    }

    public void LoadPuzzleScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void PuzzleChanger1(ClickEvent evt) 
    {
        LoadPuzzleScene("Puzzle1");
    }

    private void PuzzleChanger2(ClickEvent evt) 
    {
        LoadPuzzleScene("Puzzle2");
    }

    private void PuzzleChanger3(ClickEvent evt) 
    {
        LoadPuzzleScene("Puzzle3");
    }

    private void Back(ClickEvent evt) 
    {
        LoadPuzzleScene("MainScene");
    }


    // Update is called once per frame
    void Update()
    {

    }
}
