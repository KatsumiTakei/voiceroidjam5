using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using STLExtensiton;

[DefaultExecutionOrder(1)]
public class Player : MonoBehaviour
{

    [SerializeField]
    Weapon defaultWeapon = null;

    [SerializeField]
    Sprite[] sprites = null;

    float spd = 0.04f;
    Vector3 moveValue = Vector3.zero;
    SpriteRenderer spriteRenderer = null;

    int animCnt = 0;
    Loop<int> spriteIndex = new Loop<int>(0, 2);

    Weapon weapon = null;

    public int Life { get; set; } = 3;

    bool isInvisible = false;
    int invisibleCnt = 0;
    int InvisibleCntMax = 180;

    public void Reset()
    {
        transform.localPosition = new Vector3(-4f, -0.2f);

        Life = 3;
        EventManager.BroadcatChangeLife(this);

        isInvisible = false;
        invisibleCnt = 0;
        InvisibleCntMax = 180;

        weapon = Instantiate(defaultWeapon, transform);

        StartCoroutine(CoEquipment());
    }

    IEnumerator CoEquipment()
    {
        yield return new WaitForEndOfFrame();

        weapon.Equipment();

    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (invisibleCnt++ >= InvisibleCntMax)
        {
            invisibleCnt = 0;
            isInvisible = false;
        }
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

        weapon?.Dump();
        weapon = null;
    }

    public bool CanEquipment()
    {
        return weapon == null;
    }

    void HitEnemy()
    {
        if (isInvisible)
            return;

        isInvisible = true;
        invisibleCnt = 0;

        AudioManager.Instance.PlaySE("Damage" + Random.Range(0, 2));
        if (--Life <= 0)
        {
            EventManager.BroadcastGameResult();
        }
        EventManager.BroadcatChangeLife(this);
    }

    void OnMultipleInput(eInputType inputType)
    {
        if (inputType == eInputType.MoveRightKey)
        {
            if (transform.localPosition.x < 4.5f)
                moveValue.x += spd;
        }
        if (inputType == eInputType.MoveLeftKey)
        {
            if (transform.localPosition.x > -4.5f)
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

        if (inputType == eInputType.Cancel)
        {
            weapon.Dump();
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
                weapon.Equipment();
            }
        }

        if (collision.gameObject.CompareTag("Vanpaia"))
        {
            HitEnemy();
        }
    }

}
