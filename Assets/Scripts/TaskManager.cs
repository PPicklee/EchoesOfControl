using UnityEngine;
using System.Collections;
using Neocortex;
using Neocortex.Data;

public class TaskManager : MonoBehaviour
{
    public Light warningLight;
    public DeathManager deathManager;
    public NeocortexSmartAgent aiAgent;

    public float taskInterval = 20f;
    public float failTime = 10f;

    private string currentTask;
    private bool taskActive = false;
    private bool taskCompleted = false;

    void Start()
    {
        StartCoroutine(TaskLoop());

        // Listen for AI response (if needed)
        if (aiAgent != null)
        {
            aiAgent.OnChatResponseReceived.AddListener(OnAgentResponse);
        }
    }

    private void OnAgentResponse(ChatResponse response)
    {
        Debug.Log("[AI] " + response.message);
        // Optional: Update chat UI or trigger audio here
    }

    IEnumerator TaskLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(taskInterval);
            GenerateTask();

            yield return new WaitForSeconds(failTime);

            if (!taskCompleted)
            {
                TriggerWarning();
                yield return new WaitForSeconds(3f);
                deathManager.TriggerDeath();
            }

            ResetTask();
        }
    }

    void GenerateTask()
    {
        string[] tasks = { "lock the door", "turn off the light", "sound the alarm" };
        currentTask = tasks[Random.Range(0, tasks.Length)];
        taskActive = true;
        taskCompleted = false;

        if (aiAgent != null)
        {
            aiAgent.TextToText($"The system is unstable. You must {currentTask}.");
        }
    }

    public void PlayerDidAction(string action)
    {
        if (taskActive && action == currentTask)
        {
            taskCompleted = true;
            taskActive = false;
            Debug.Log("Task completed: " + action);

            if (warningLight != null)
            {
                warningLight.color = Color.green;
                warningLight.intensity = 0.3f;
            }
        }
    }

    void TriggerWarning()
    {
        if (warningLight != null)
        {
            warningLight.color = Color.red;
            warningLight.intensity = 6f;
        }
    }

    void ResetTask()
    {
        currentTask = "";
        taskActive = false;
        taskCompleted = false;
    }
}
