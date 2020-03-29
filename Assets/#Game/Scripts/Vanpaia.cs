using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vanpaia : MonoBehaviour
{
    float spd = 0.1f;
    BoxCollider2D boxCollider = null;
    Rigidbody2D rigid = null;

    bool isDead = false;

    private void Start()
    {
        spd = Random.Range(0.005f, 0.05f);
        boxCollider = GetComponent<BoxCollider2D>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead)
            return;

        transform.localPosition += Vector3.left * spd;
    }


    public void HitDamage(Vector2 cutPos)
    {
        if (isDead)
            return;

        isDead = true;

        VanpaiaCutter.Cut(cutPos, transform.position + GetComponent<Collider2D>().bounds.size);
        LineRenserManager.Instance.ViewLine(cutPos, transform.position + GetComponent<Collider2D>().bounds.size);

        rigid.gravityScale = 0.98f;
        rigid.constraints = RigidbodyConstraints2D.FreezeRotation;

        boxCollider.enabled = false;

        EventManager.BroadcastGenerateCoin(transform.localPosition);
        AudioManager.Instance.PlaySE("Scream");
    }

}
