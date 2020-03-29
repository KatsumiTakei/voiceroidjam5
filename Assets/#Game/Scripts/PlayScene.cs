using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayScene : SceneBase
{
    int blessCnt = 0;
    int blessTime = 300;

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


        }
    }


    public override void Open()
    {
        enabled = true;
    }

    public override void Close()
    {
        enabled = false;
    }
}
