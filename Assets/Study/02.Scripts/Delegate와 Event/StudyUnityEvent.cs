using UnityEngine;
using UnityEngine.Events;

public class StudyUnityEvent : MonoBehaviour
{
    // [SerializeField]
    // private UnityEvent onSomethingHappened; // 인스펙터 노출 (private)
    //
    // public void AddListener(UnityAction listener)
    // {
    //     onSomethingHappened.AddListener(listener); // 외부 구독 가능
    // }
    //
    // public void Trigger()
    // {
    //     onSomethingHappened?.Invoke(); // 내부에서만 실행
    // }
    
    public UnityEvent uEvent;

    void Start()
    {
        uEvent.AddListener(MethodA);
        uEvent.AddListener(MethodB);

        uEvent.RemoveListener(MethodB);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            uEvent?.Invoke();
        }
    }

    private void MethodA()
    {
        Debug.Log("Method A 실행");
    }
    
    private void MethodB()
    {
        Debug.Log("Method B 실행");
    }
}
