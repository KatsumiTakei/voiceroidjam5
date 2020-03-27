using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Weapon : MonoBehaviour
{
    float spd = 0.1f;
    int useCnt = 0;
    protected int useCntMax = 0;

    Vector3 rotateValue = new Vector3(0, 0, -90);

    BoxCollider2D boxCollider = null;
    SpriteRenderer spriteRenderer = null;

    private void Start()
    {
        spd = Random.Range(0.01f, 0.07f);
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!transform.parent.gameObject.CompareTag("Player"))
            transform.localPosition += Vector3.left * spd;
    }

    public void Attack()
    {
        if (boxCollider.enabled)
            return;

        boxCollider.enabled = true;
        transform.DOLocalRotate(rotateValue, 0.5f)
            .OnComplete(
            () => transform.DOLocalRotate(Vector3.zero, 0.5f)
            .OnComplete(() =>
            {
                boxCollider.enabled = false;
                if (useCnt++ >= useCntMax)
                {
                    Destroy(gameObject);
                }
            })
            );
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!transform.parent.gameObject.CompareTag("Player") && collision.gameObject.CompareTag("Player"))
        {
            boxCollider.enabled = false;
            spriteRenderer.flipX = true;
        }

        if (!transform.parent.gameObject.CompareTag("Player"))
            return;

        if (collision.gameObject.CompareTag("Vanpaia"))
        {
            var enemy = GetComponent<Vanpaia>();
            enemy.HitDamage();
        }

    }

}
