using UnityEngine;

public class ParticleClass : MonoBehaviour
{
    void Awake()
    {
        TimerDelegate.onTimerEnd += Explosion;
    }
    
    public void Explosion()
    {
        Debug.Log("폭발 이펙트");
    }
}
