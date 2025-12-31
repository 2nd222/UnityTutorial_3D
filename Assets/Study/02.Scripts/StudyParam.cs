using UnityEngine;

public class StudyParam : MonoBehaviour
{
    public int number = 10;
    public int[] numbers = { 1, 2, 3, 4, 5 };
    
    public GameObject player;
    public GameObject enemy;
    public GameObject item;
    
    void Start()
    {
        RefParameter(ref number);
        
        ParamsParameter(1,2,3);
        ParamsParameter(numbers);
        
        GameObjectActivate(true, player, enemy, item); // 인수로 들어간 대상을 SetActive(true);
        
        // GameObjectActivate(false, player, enemy, item); // 인수로 들어간 대상을 SetActive(false);
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
    
    private void OutParameter(out int n0, out int n1, out int n2)
    {
        n0 = 100;
        n1 = 100;
        n2 = 100;
    }
    
    private void ArrayParameter(int[] numbers)
    {
        string s = "";
        foreach (var n in numbers)
            s += n.ToString() + " ";

        Debug.Log(s);
    }
    
    private void ParamsParameter(params int[] numbers)
    {
        string s = "";
        foreach (var n in numbers)
            s += n.ToString() + " ";

        Debug.Log(s);
    }
    
    private void GameObjectActivate(bool isOn, params GameObject[] objs)
    {
        foreach (GameObject obj in objs)
            obj.SetActive(isOn);
    }
}
