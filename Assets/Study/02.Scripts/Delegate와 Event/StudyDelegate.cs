using UnityEngine;

public class StudyDelegate : MonoBehaviour
{
    // public delegate void MyDelegate(int a, int b);
    // public MyDelegate onDelegate;

    public delegate void MyDelegate(string str);
    public MyDelegate onKeyDown;
    public KeyCode keyCode = KeyCode.Space;
    void Start()
    {
        // // Delegate 할당의 예전 방식
        // onDelegate = new MyDelegate(MethodA);
        //
        // // Delegate 할당의 표준 방식
        // onDelegate = MethodA;
        //
        // // 직접 실행 방식
        // onDelegate();
        //
        // // 직접 실행과 동일한 방식
        // onDelegate.Invoke();
        //
        // // null 체크 방식 -> 가장 안전한 방식
        // onDelegate?.Invoke();
        
        
        // onDelegate = OnMethodA; // 할당 만약 앞에 다른 함수가 들어가 있으면 삭제되고 대신 들어감
        //
        // onDelegate += OnMethodA; //두 번 실행됨
        // onDelegate += OnMethodB;
        // onDelegate += OnMethodC;
        //
        // onDelegate -= OnMethodB;
        //
        // onDelegate?.Invoke(10, 20);
        
        
        onKeyDown = Respond;
        // onKeyDown += Respond;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            onKeyDown?.Invoke(keyCode.ToString()); // 델리게이트 실행
        }
    }

    private void Respond(string str)
    {
        Debug.Log($"{str} Key Down");
    }
    
    private void MethodA()
    {
        Debug.Log("Method A 실행");
    }
    
    private void OnMethodA(int a, int b)
    {
        Debug.Log("Method A 실행");
    }
    
    private void OnMethodB(int c, int d)
    {
        Debug.Log("Method B 실행");
    }
    
    private void OnMethodC(int e, int f)
    {
        Debug.Log("Method C 실행");
    }
}
