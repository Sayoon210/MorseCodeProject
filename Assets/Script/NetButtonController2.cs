using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetButtonController2 : MonoBehaviour
{
    public Sprite buttonUpSprite; // ButtonUp 스프라이트
    public Sprite buttonDownSprite; // ButtonDown 스프라이트
    public KeyCode dashKey;
    private SpriteRenderer spriteRenderer; // 스프라이트 렌더러 컴포넌트
    private bool isKeyPressed = false; // T 키가 눌렸는지 여부를 나타내는 변수
    private float lastKeyPressTime = 0f; // 마지막으로 T 키가 눌린 시간을 저장하는 변수

    void Start()
    {
        dashKey = KeyManager.dashKey; // dashKey가져오는 부분

        //print($"dash key is {dashKey}");
        // 스프라이트 렌더러 컴포넌트 가져오기
        spriteRenderer = GetComponent<SpriteRenderer>();

        // 초기 상태는 버튼이 눌려있지 않은 상태로 설정
        SetButtonState(false);
    }

    void Update()
    {
        // T 키를 누른 순간
        if (Input.GetKeyDown(dashKey))
        {
            isKeyPressed = true; // T 키가 눌린 상태로 설정
            lastKeyPressTime = Time.time; // 현재 시간 저장
            SetButtonState(true); // 버튼 상태 변경
            CheckYKeyState(); // dash 출력
        }
        // T 키를 누르고 있는 동안
        else if (Input.GetKey(dashKey))
        {
            // 마지막으로 T 키가 눌린 후 0.3초 이상이 지났을 때
            if (Time.time - lastKeyPressTime >= 0.3f)
            {
                lastKeyPressTime = Time.time; // 현재 시간 저장
                CheckYKeyState(); // dash 출력
            }
        }
        // T 키를 누르지 않은 경우
        else if (Input.GetKeyUp(dashKey))
        {
            isKeyPressed = false; // T 키가 떼진 상태로 설정
            SetButtonState(false); // 버튼 상태 변경
        }
    }

    // 버튼 상태에 따라 스프라이트 변경하는 함수
    void SetButtonState(bool isDown)
    {
        spriteRenderer.sprite = isDown ? buttonDownSprite : buttonUpSprite;
    }

    void CheckYKeyState()
    {
        Debug.Log("dash"); // dash 출력

        // 효과음 재생
        ButtonSoundDashNetwork buttonSound = GetComponent<ButtonSoundDashNetwork>();
        if (buttonSound != null)
        {
            buttonSound.PlayButtonSound();
        }

    }
}
