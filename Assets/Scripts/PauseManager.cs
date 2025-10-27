using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isPaused;

    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
    }
}
