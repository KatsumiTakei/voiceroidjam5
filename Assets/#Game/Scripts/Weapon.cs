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

        AudioManager.Instance.PlaySE("Attack" + Random.Range(0, 2));

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

            EventManager.BroadcastChangeAttackCnt(useCntMax - useCnt);
        }

    }

    public void Dump()
    {
        EventManager.BroadcastChangeAttackCnt(0);
        Destroy(gameObject);
    }

    public void Equipment()
    {
        boxCollider.enabled = false;
        spriteRenderer.flipX = false;
        spriteRenderer.flipY = false;
        transform.localPosition = new Vector3(0.4f, -0.2f, 0.0f);

        EventManager.BroadcastChangeAttackCnt(useCntMax);
    }

    private void Update()
    {
        if (!transform.parent.gameObject.CompareTag("Player"))
            transform.localPosition += Vector3.left * spd;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!transform.parent.gameObject.CompareTag("Player"))
            return;

        if (collision.gameObject.CompareTag("Vanpaia"))
        {
            var enemy = collision.gameObject.GetComponent<Vanpaia>();
            enemy?.HitDamage(transform.position);
        }
    }

}
