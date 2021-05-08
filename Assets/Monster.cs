using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int maxHP = 3;
    public int curHP;
    public float speed = 1.5f;
    public Animator animator;
    float originSpeed;
    public Transform hpBar;
    public TextMeshPro hptmPro;

    private void Start()
    {
        curHP = maxHP;
        originSpeed = speed;
        UpdateHP();
    }

    private void UpdateHP()
    {
        hptmPro.text = $"{curHP} / {maxHP}";
        var scale = hpBar.localScale;
        scale.x = curHP / (float)maxHP;
        hpBar.localScale = scale;
    }

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);

        curHP--;
        UpdateHP();
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
        var hpBarScale = hpBar.localScale;
        hpBarScale.x = 0;
        hpBar.localScale = hpBarScale;
        yield return new WaitForSeconds(dieDelay);

        Destroy(gameObject);
    }
}
