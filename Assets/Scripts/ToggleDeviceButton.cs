using UnityEngine;

public class ToggleDeviceButton : MonoBehaviour
{
    public string actionKeyword;
    private bool isOn = false;

    public GameObject onStateObject;  // Shows when ON
    public GameObject offStateObject; // Shows when OFF

    void Start()
    {
        // Make sure it starts in OFF state
        if (onStateObject) onStateObject.SetActive(false);
        if (offStateObject) offStateObject.SetActive(true);
    }

    void OnMouseDown()
    {
        isOn = !isOn;

        // Show only one state visual
        if (onStateObject) onStateObject.SetActive(isOn);
        if (offStateObject) offStateObject.SetActive(!isOn);

        // Notify TaskManager if this action is a match
        GameObject.Find("TaskManager")?.GetComponent<TaskManager>()?.PlayerDidAction(actionKeyword);
    }

    public bool IsOn() => isOn;
}
