using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.Audio;

public class MorseSfxControllerNetwork : NetworkBehaviour
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
        if (IsClient)
        {
            // DOT 키 입력 처리
            if (Input.GetKeyDown(dotKey))
            {
                SendInputToServerRpc(true);
                largeSpacingOk = true;
            }
            // DASH 키 입력 처리
            else if (Input.GetKeyDown(dashKey))
            {
                SendInputToServerRpc(false);
                largeSpacingOk = true;
            }
            else if (Time.time - lastInputTime >= 0.3f)
            {
                if (Input.GetKey(dotKey))
                {
                    SendInputToServerRpc(true);
                    largeSpacingOk = true; // DOT 출력
                }
                else if (Input.GetKey(dashKey))
                {
                    SendInputToServerRpc(false);
                    largeSpacingOk = true; // DASH 출력
                }
            }

            // 일정 시간 입력이 없으면 큰 공백 추가
            if (Time.time - lastInputTime >= inputCooldown && spawnedObjects.Count > 0 && largeSpacingOk)
            {
                AddLargeSpacing();
                lastInputTime = Time.time;
                largeSpacingOk = false;
            }
        }

        // 스프라이트 왼쪽으로 이동
    }

    [ServerRpc(RequireOwnership = false)]
    public void SendInputToServerRpc(bool isDot, ServerRpcParams rpcParams = default)
    {
        PlaySoundOnClientsClientRpc(isDot);
    }

    [ClientRpc]
    public void PlaySoundOnClientsClientRpc(bool isDot)
    {
        if (isDot)
        {
            AddSprite(dotPrefab);
        }
        else
        {
            AddSprite(dashPrefab);
        }
    }

    float GetPrefabSpriteWidth(GameObject prefab)
    {
        SpriteRenderer spriteRenderer = prefab.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            // Sprite의 bounds를 통해 width를 구합니다.
            return spriteRenderer.sprite.bounds.size.x * prefab.transform.localScale.x;
        }
        return 0f;
    }

    private void AddSprite(GameObject prefab)
    {
        // 마지막 입력 시간 갱신
        lastInputTime = Time.time;

        if (spawnedObjects.Count >= 1)
        {
            float spriteWidth1 = GetSpriteWidth(spawnedObjects[spawnedObjects.Count - 1]);
            float spriteWidth2 = GetPrefabSpriteWidth(prefab);
            Debug.Log($"width is {spriteWidth1} {spriteWidth2}");
            MoveSprites(spriteWidth1 / 2 + spriteWidth2 / 2 + normalSpacing);
        }
        // 새로운 스프라이트 생성
        GameObject newSprite = Instantiate(prefab, transform);
        newSprite.transform.position = new Vector3(18f, -6.5f, 0); // 지정된 위치에 생성
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
