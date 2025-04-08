using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class DeathManager : MonoBehaviour
{
    public GameObject blackoutPanel;      // Fullscreen black image
    public AudioSource jumpscareSound;    // AudioSource with jumpscare .wav
    public float blackoutDelay = 0.5f;    // Delay before blackout
    public float resetDelay = 3f;         // Delay before restarting scene

    public void TriggerDeath()
    {
        StartCoroutine(DeathSequence());
    }

    IEnumerator DeathSequence()
    {
        yield return new WaitForSeconds(blackoutDelay);

        if (blackoutPanel != null)
            blackoutPanel.SetActive(true);

        if (jumpscareSound != null)
            jumpscareSound.Play();

        yield return new WaitForSeconds(resetDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
