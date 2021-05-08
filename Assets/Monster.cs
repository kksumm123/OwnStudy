using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int maxHP = 3;
    public int curHP;
    public float speed = 1.5f;
    public Animator animator;
    float originSpeed;
    private void Start()
    {
        curHP = maxHP;
        originSpeed = speed;
    }

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);

        curHP--;
        if (curHP > 0)
            StartCoroutine(Attacked());
        else
            StartCoroutine(Die());

    }

    public float attackedDelay = 0.3f;
    private IEnumerator Attacked()
    {
        animator.Play("GetHit", 0, 0);
        speed = 0;
        yield return new WaitForSeconds(attackedDelay);
        speed = originSpeed;
    }

    public float dieDelay = 1.3f;
    private IEnumerator Die()
    {
        GameManager.instance.AddScore(50);

        GetComponent<Collider>().enabled = false;
        enabled = false;
        animator.Play("Die", 0, 0);

        yield return new WaitForSeconds(dieDelay);

        Destroy(gameObject);
    }
}
