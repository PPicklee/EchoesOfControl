using UnityEngine;
using UnityEngine.UI;

public class CameraSwitcher : MonoBehaviour
{
    public RawImage feedDisplay;
    public RenderTexture[] cameraFeeds;

    public void SwitchCamera(int index)
    {
        if (index >= 0 && index < cameraFeeds.Length)
        {
            feedDisplay.texture = cameraFeeds[index];
        }
    }
}
