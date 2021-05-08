using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float ArrowDestroyTime = 2.5f;
    public float speed = 8f;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(SubUpdate());
    }

    private IEnumerator SubUpdate()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);

        yield return new WaitForSeconds(ArrowDestroyTime);

        Destroy(gameObject);
    }
}
