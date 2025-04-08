using UnityEngine;

public class ChatPanelManager : MonoBehaviour
{
    public GameObject chatPanel; // Assign your chat panel GameObject in the Inspector
    public GameObject customCursor; // Assign your custom cursor GameObject in the Inspector
    private bool isChatActive = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ToggleChatPanel();
        }
    }

    void ToggleChatPanel()
    {
        isChatActive = !isChatActive;
        chatPanel.SetActive(isChatActive);
        customCursor.SetActive(!isChatActive); // Hide custom cursor when chat is active

        if (isChatActive)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Notify the PlayerCam script about the chat panel state
        FindObjectOfType<PlayerCam>().SetChatActive(isChatActive);
    }
}
