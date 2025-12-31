using System;
using UnityEngine;

public class StudyPredicate : MonoBehaviour
{
    Predicate<float> myPredicate;
    private SpriteRenderer spriteRenderer;


    void Start()
    {
        myPredicate = SetFlip;
    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        spriteRenderer.flipX = myPredicate(h);
    }
    
    private bool SetFlip(float h)
    {
        if (h < 0)
            return true;
        else if (h > 0)
            return false;

        return false;
    }
}
