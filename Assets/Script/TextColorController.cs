using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextColorController : MonoBehaviour
{
    public SpriteRenderer dotTextSprite;
    public SpriteRenderer dashTextSprite;
    public KeyCode dotKey;
    public KeyCode dashKey;


    // Start is called before the first frame update
    void Start()
    {
        dotKey = KeyManager.dotKey;
        dashKey = KeyManager.dashKey;

    }

    // Update is called once per frame
    void Update()
    {
        // Dot Key Control
        if (Input.GetKey(dotKey))
        {
            // 연두색(RGBA 값이 (0, 1, 0, 1))으로 변경
            dotTextSprite.color = new Color(0f, 1f, 0f, 1f);
        }
        else
        {
            // 흰색(RGBA 값이 (1, 1, 1, 1))으로 변경
            dotTextSprite.color = Color.white;
        }

        // Dash Key Control
        if (Input.GetKey(dashKey))
        {
            // 연두색(RGBA 값이 (0, 1, 0, 1))으로 변경
            dashTextSprite.color = new Color(0f, 1f, 0f, 1f);
        }
        else
        {
            // 흰색(RGBA 값이 (1, 1, 1, 1))으로 변경s
            dashTextSprite.color = Color.white;
        }
    }
}
