using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioClip buttonSound; // 효과음 AudioClip

    private AudioSource audioSource; // AudioSource 컴포넌트

    void Start()
    {
        // AudioSource 컴포넌트 가져오기
        audioSource = GetComponent<AudioSource>();
    }

    // 효과음 재생 함수
    public void PlayButtonSound()
    {
        if (buttonSound != null)
        {
            audioSource.clip = buttonSound;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Button sound clip is not assigned!");
        }
    }
}
