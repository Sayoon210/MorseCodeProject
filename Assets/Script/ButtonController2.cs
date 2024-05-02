using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEffect2 : MonoBehaviour
{
    public Sprite buttonUpSprite; // ButtonUp 스프라이트
    public Sprite buttonDownSprite; // ButtonDown 스프라이트

    private SpriteRenderer spriteRenderer; // 스프라이트 렌더러 컴포넌트

    void Start()
    {
        // 스프라이트 렌더러 컴포넌트 가져오기
        spriteRenderer = GetComponent<SpriteRenderer>();

        // 초기 상태는 버튼이 눌려있지 않은 상태로 설정
        SetButtonState(false);
    }

    void Update()
    {
        // T 키를 눌렀을 때 버튼의 상태를 변경
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SetButtonState(true);
        }
        // T 키를 뗏을 때 버튼의 상태를 변경
        else if (Input.GetKeyUp(KeyCode.Y))
        {
            SetButtonState(false);
        }
    }

    // 버튼 상태에 따라 스프라이트 변경하는 함수
    void SetButtonState(bool isDown)
    {
        spriteRenderer.sprite = isDown ? buttonDownSprite : buttonUpSprite;
    }
}