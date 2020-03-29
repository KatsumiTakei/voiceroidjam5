using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityDLL;
using DG.Tweening;

public class PlayScene : SceneBase
{
    [SerializeField]
    Player player = null;


    [SerializeField]
    SpriteRenderer blessPrefab = null;

    int blessCnt = 0;
    int blessTime = 300;

    public void Reset()
    {
        player.Reset();
        EventManager.BroadcastChangeScore(0);
    }

    void Start()
    {
        AudioManager.PlayBGM("BGM");
    }

    void Update()
    {
        if (++blessCnt >= blessTime)
        {
            blessCnt = 0;
            blessTime = Random.Range(300, 450);
            AudioManager.Instance.PlaySE("Bless2");

            var bless = Instantiate(blessPrefab, transform);
            bless.flipX = (blessCnt % 2 == 0);
            bless.DOColor(Color.clear, 1f).SetEase(Ease.InExpo);
            bless.transform.GetChild(0).transform.localPosition = new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));
            bless.transform.GetChild(0).GetComponent<SpriteRenderer>().DOColor(Color.clear, 1f).SetEase(Ease.InExpo);
        }
    }

    public override void Open()
    {
        gameObject.SetActive(true);
        Reset();
    }

    public override void Close()
    {
        var coins = FindObjectsOfType<Coin>();
        var vanpaias = FindObjectsOfType<Vanpaia>();
        var weapons = FindObjectsOfType<Weapon>();

        foreach(var target in coins)
        {
            Destroy(target.gameObject);
        }
        foreach(var target in weapons)
        {
            Destroy(target.gameObject);
        }
        foreach(var target in vanpaias)
        {
            Destroy(target.gameObject);
        }

        gameObject.SetActive(false);

    }
}
