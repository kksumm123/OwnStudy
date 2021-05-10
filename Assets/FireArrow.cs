using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArrow : MonoBehaviour
{
    public GameObject arrow;
    public Transform arrowPointTransform;
    public Animator animator;
    public float fireDelay = 0.2f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            StartCoroutine(OnFireArrow());
    }

    private IEnumerator OnFireArrow()
    {
        animator.Play("Attack01", 0, 0);

        yield return new WaitForSeconds(fireDelay);

        Instantiate(arrow, arrowPointTransform.position, this.transform.rotation);
    }
}
