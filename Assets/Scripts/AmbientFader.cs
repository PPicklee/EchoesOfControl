using UnityEngine;
using System.Collections;

public class AmbientFader : MonoBehaviour
{
    public AudioSource audioSource;
    public float fadeTime = 2f;

    void Start()
    {
        if (audioSource != null)
        {
            audioSource.volume = 0f;
            StartCoroutine(FadeIn());
        }
    }

    IEnumerator FadeIn()
    {
        float t = 0;
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0, 1, t / fadeTime);
            yield return null;
        }
        audioSource.volume = 1f;
    }
}
