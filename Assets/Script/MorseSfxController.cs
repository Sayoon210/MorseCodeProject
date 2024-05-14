using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorseSfxController : MonoBehaviour
{
    public bool largeSpacingOk = false;
    public GameObject dotPrefab; // dot 스프라이트 프리팹
    public GameObject dashPrefab; // dash 스프라이트 프리팹
    public float normalSpacing = 0.5f; // 스프라이트 간 공백
    public float largeSpacing = 2f; // 큰 공백
    public float inputCooldown = 3f; // 입력 간격 시간

    private float lastInputTime = 0f; // 마지막 입력 시간
    private List<GameObject> spawnedObjects = new List<GameObject>(); // 생성된 스프라이트 리스트

    public KeyCode dotKey;
    public KeyCode dashKey;


    // Start is called before the first frame update
    void Start()
    {
        dotKey = KeyManager.dotKey;
        dashKey = KeyManager.dashKey;

    }

    void Update()
    {
        // DOT 키 입력 처리
        if (Input.GetKeyDown(dotKey))
        {
            AddSprite(dotPrefab);
            largeSpacingOk = true;
        }
        // DASH 키 입력 처리
        else if (Input.GetKeyDown(dashKey))
        {
            AddSprite(dashPrefab);
            largeSpacingOk = true;
        }

        // 일정 시간 입력이 없으면 큰 공백 추가
        if (Time.time - lastInputTime >= inputCooldown && spawnedObjects.Count > 0 && largeSpacingOk)
        {
            //AddLargeSpacing();
            lastInputTime = Time.time;
            largeSpacingOk = false;
        }

        // 스프라이트 왼쪽으로 이동
        
    }

    private void AddSprite(GameObject prefab)
    {
        // 마지막 입력 시간 갱신
        lastInputTime = Time.time;
        if(spawnedObjects.Count >= 1) {
            // 기존 스프라이트들 왼쪽으로 이동
            float spriteWidth1 = GetSpriteWidth(spawnedObjects[spawnedObjects.Count - 1]);
            float spriteWidth2 = GetSpriteWidth(prefab);
            Debug.Log($"width is {spriteWidth1} {spriteWidth2}");
            MoveSprites(spriteWidth1/2 + spriteWidth2/2 + normalSpacing);
        }
        // 새로운 스프라이트 생성
        GameObject newSprite = Instantiate(prefab, transform);
        newSprite.transform.position = new Vector3(17.5f, -6.5f, 0); // 지정된 위치에 생성
        spawnedObjects.Add(newSprite);
    }

    private void AddLargeSpacing()
    {
        // 모든 기존 스프라이트 왼쪽으로 큰 공백만큼 이동
        MoveSprites(largeSpacing);
    }

    private void MoveSprites(float distance)
    {
        foreach (var obj in spawnedObjects)
        {
            obj.transform.position -= new Vector3(distance, 0, 0);
        }
    }

    private float GetSpriteWidth(GameObject prefab)
    {
        // 스프라이트의 폭을 계산
        SpriteRenderer renderer = prefab.GetComponent<SpriteRenderer>();
        if (renderer != null)
        {
            return renderer.bounds.size.x;
        }
        return 0f;
    }
}
