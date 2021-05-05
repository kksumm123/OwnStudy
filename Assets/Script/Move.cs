using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 5f;
    public Animator animator;
    void Update()
    {
        float moveX = 0;
        float moveZ = 0;
        if (Input.GetKey(KeyCode.W))
            moveZ = 1;
        if (Input.GetKey(KeyCode.S))
            moveZ = -1;

        if (Input.GetKey(KeyCode.A))
            moveX = -1;
        if (Input.GetKey(KeyCode.D))
            moveX = 1;

        Vector3 position = transform.position;
        position.x += moveX * speed * Time.deltaTime;
        position.z += moveZ * speed * Time.deltaTime;
        transform.position = position;

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack01") == false)
        {
            if (moveX != 0 || moveZ != 0)
                animator.Play("RunForwardBattle");
            else
                animator.Play("Idle_Battle");
        }
    }
}
