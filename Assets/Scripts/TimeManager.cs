using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour
{
    public void SetTimeScale(float timeScale, float duration)
    {
        StartCoroutine(SlowTimeForDuration(timeScale, duration));
    }
    private IEnumerator SlowTimeForDuration(float timeScale, float duration)
    {
        Time.timeScale = timeScale;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1;
    }
}
