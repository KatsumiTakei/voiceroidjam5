using STLExtensiton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnim : MonoBehaviour
{

    [SerializeField]
    SpriteRenderer player = null;
    [SerializeField]
    Sprite []anims = null;
    Loop<int> spriteIndex = new Loop<int>(0, 2);
    int animCnt = 0;

    void Update()
    {
        if (animCnt++ % 10 == 0)
        {
            spriteIndex += 1;
            player.sprite = anims[spriteIndex];
        }
    }
}
