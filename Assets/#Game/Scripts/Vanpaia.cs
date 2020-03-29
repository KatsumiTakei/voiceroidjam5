using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vanpaia : MonoBehaviour
{
    float spd = 0.1f;
    Rigidbody2D rigid = null;

    bool isDead = false;

    private void Start()
    {
        spd = Random.Range(0.005f, 0.05f);
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

        var collider = GetComponent<Collider2D>();

        VanpaiaCutter.Cut(cutPos, transform.position + collider.bounds.size);
        LineRenserManager.Instance.ViewLine(cutPos, transform.position + collider.bounds.size);

        rigid.gravityScale = 0.98f;
        rigid.constraints = RigidbodyConstraints2D.FreezeRotation;

        collider.enabled = false;

        EventManager.BroadcastGenerateCoin(transform.localPosition);
        AudioManager.Instance.PlaySE("Scream");
    }

}
