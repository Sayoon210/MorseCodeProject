// 빌드 인덱스를 쓰는 것이 올바를 것이지만, 딱히 실력이 아직 없기 때문에 쉬운 방향으로 간다!!!!!!


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    private VisualElement _buttonContainer;
    private Button _buttonStart;

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        _buttonContainer = root.Q<VisualElement>("ButtonContainer");
        _buttonStart = root.Q<Button>("StartButton");

        _buttonStart.RegisterCallback<ClickEvent>(OnClickEvent);
    
    }

    public void LoadSpecificScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void OnClickEvent(ClickEvent evt) 
    {
        LoadSpecificScene("StartScene");
    }



    // Update is called once per frame
    void Update()
    {

    }
}
