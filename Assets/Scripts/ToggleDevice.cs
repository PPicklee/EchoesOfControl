using UnityEngine;

public class ToggleDevice : MonoBehaviour
{
    private bool isOn = false;

    public void Toggle()
    {
        isOn = !isOn;
        gameObject.SetActive(isOn);
    }
}
