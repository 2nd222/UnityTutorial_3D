using System;
using UnityEngine;
using UnityEngine.AI;

public class MazePlayer : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector3 moveDir;
    public float moveSpeed = 3f;
    public float rotSpeed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        moveDir = new Vector3(h, v, 0).normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveDir * moveSpeed;

        if (moveDir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, moveDir);
            rb.MoveRotation(Quaternion.Lerp(transform.rotation, targetRotation, rotSpeed * Time.fixedDeltaTime));
        }
    }
}
