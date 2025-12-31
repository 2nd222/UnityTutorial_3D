using System.Collections;
using UnityEngine;

public class TimerDelegate : MonoBehaviour
{
    public delegate void TimerStart();
    public static TimerStart onTimerStart;

    public delegate void TimerEnd();
    public static TimerEnd onTimerEnd;
    
    public delegate void StopTimer();
    public static StopTimer onTimerStop;

    private float timer = 10f;
    private bool isTimer = true;
    
    public KeyCode keyCode = KeyCode.Space;

    void OnEnable()
    {
        onTimerStart += StartEvent;
        onTimerEnd += EndEvent;
        onTimerStop += Respond;
    }
    
    void OnDisable()
    {
        onTimerStart -= StartEvent;
        onTimerEnd -= EndEvent;
        onTimerStop -= Respond;
    }
    
    void Start()
    {
        onTimerStart?.Invoke();
        
        StartCoroutine(TimerRoutine());
    }
    
    void Update()
    {
        if (Input.GetKeyDown(keyCode))
            onTimerStop?.Invoke();
    }

    IEnumerator TimerRoutine()
    {
        while (isTimer)
        {
            Debug.Log(timer);
            yield return new WaitForSeconds(1f);
            timer--;
            
            if (timer <= 0f)
            {
                isTimer = false;
                onTimerEnd?.Invoke();
            }
        }
    }

    public void StartEvent()
    {
        Debug.Log("폭탄이 설치되었습니다.");
    }

    public void EndEvent()
    {
        Debug.Log("폭탄이 터졌습니다.");
    }
    
    private void Respond()
    {
        isTimer = false;
        Debug.Log("폭탄이 해제되었습니다.");
    }
}
