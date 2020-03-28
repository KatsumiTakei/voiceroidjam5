using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using STLExtensiton;

public class Player : MonoBehaviour
{
    [SerializeField]
    Sprite[] sprites = null;

    float spd = 0.04f;
    Vector3 moveValue = Vector3.zero;
    SpriteRenderer spriteRenderer = null;

    int animCnt = 0;
    Loop<int> spriteIndex = new Loop<int>(0, 2);

    Weapon weapon = null;

    int life = 3;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        weapon = GetComponentInChildren<Sword>();
        weapon.Equipment();
    }

    void Update()
    {
        if (animCnt++ % 10 == 0)
        {
            spriteIndex += 1;
            spriteRenderer.sprite = sprites[spriteIndex];
        }

        transform.localPosition += moveValue;
        moveValue = Vector3.zero;
    }

    private void OnEnable()
    {
        animCnt = 0;
        EventManager.OnMultipleInput += OnMultipleInput;
    }

    private void OnDisable()
    {
        EventManager.OnMultipleInput -= OnMultipleInput;
    }

    public bool CanEquipment()
    {
        return weapon == null;
    }

    void HitEnemy()
    {
        print("hit");
        if (--life <= 0)
        {

        }
    }

    void OnMultipleInput(eInputType inputType)
    {
        if (inputType == eInputType.MoveRightKey)
        {
            moveValue.x += spd;
        }
        if (inputType == eInputType.MoveLeftKey)
        {
            moveValue.x -= spd;
        }
        if (inputType == eInputType.MoveUpKey)
        {
            if (transform.localPosition.y < -0.21f)
                moveValue.y += 0.75f;
        }
        if (inputType == eInputType.MoveDownKey)
        {
            if (transform.localPosition.y > -1.69f)
                moveValue.y -= 0.75f;
        }



        if (inputType == eInputType.AttackAndDecide)
        {
            weapon.Attack();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Weapon"))
        {
            if (CanEquipment())
            {
                weapon = collision.gameObject.GetComponent<Weapon>();
                weapon.transform.parent = transform;
                weapon.transform.localPosition = new Vector3(0.4f, -0.2f, 0.0f);
                weapon.Equipment();
            }
        }

        if (collision.gameObject.CompareTag("Vanpaia"))
        {
            HitEnemy();
        }
    }

}
