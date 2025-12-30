using UnityEngine;

public class StudyParam : MonoBehaviour
{
    public int number = 10;
    
    void Start()
    {
        RefParameter(ref number);
    }

    private void NormalParameter(int n)
    {
        Debug.Log(n);
        n = 100;

        Debug.Log(number);
    }
    
    private void RefParameter(ref int number)
    {
        number = 2;
    }
    
    private void OutParameter(out int number)
    {
        number = 3;
    }
}
