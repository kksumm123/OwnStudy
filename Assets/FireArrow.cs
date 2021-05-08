using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArrow : MonoBehaviour
{
    public GameObject arrow;
    public Transform arrowPointTransform;
    public float fireDelay = 0.2f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            StartCoroutine(OnFireArrow());
    }

    private IEnumerator OnFireArrow()
    {
        yield return new WaitForSeconds(fireDelay);

        Instantiate(arrow, arrowPointTransform.position, this.transform.rotation);
    }
}
