using UnityEngine;
using UnityEngine.UI;

public class AlarmButton : MonoBehaviour
{
    public Light emergencyLight; // Assign the emergency light in the Inspector

    private Button button;

    void Start()
    {
        // Get the Button component attached to this GameObject
        button = GetComponent<Button>();

        if (button != null)
        {
            // Add a listener to the button's onClick event
            button.onClick.AddListener(ToggleEmergencyLight);
        }
        else
        {
            Debug.LogWarning("Button component not found on " + gameObject.name);
        }
    }

    void ToggleEmergencyLight()
    {
        if (emergencyLight != null)
        {
            emergencyLight.enabled = !emergencyLight.enabled;
        }
        else
        {
            Debug.LogWarning("Emergency light is not assigned.");
        }
    }
}
