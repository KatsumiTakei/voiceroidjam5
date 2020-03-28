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

    protected void Init()
    {
        spd = Random.Range(0.01f, 0.07f);
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipY = true;
    }

    public void Attack()
    {
        if (useCnt >= useCntMax
            || boxCollider.enabled)
            return;

        boxCollider.enabled = true;
        transform.DOLocalRotate(rotateValue, 0.15f)
            .OnComplete(onCompleteSwing);

        void onCompleteSwing()
        {
            transform.DOLocalRotate(Vector3.zero, 0.25f)
                .OnComplete(onCompleteSetup);
        }
        
        void onCompleteSetup()
        {
            boxCollider.enabled = false;
            if (++useCnt >= useCntMax)
                Destroy(gameObject);
        }

    }

    public void Equipment()
    {
        boxCollider.enabled = false;
        spriteRenderer.flipX = false;
        spriteRenderer.flipY = false;
    }

    private void Update()
    {
        if (!transform.parent.gameObject.CompareTag("Player"))
            transform.localPosition += Vector3.left * spd;

        if (transform.localPosition.y < -6f)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!transform.parent.gameObject.CompareTag("Player"))
            return;

        if (collision.gameObject.CompareTag("Vanpaia"))
        {
            var enemy = collision.gameObject.GetComponent<Vanpaia>();
            enemy.HitDamage();
        }
    }

}
