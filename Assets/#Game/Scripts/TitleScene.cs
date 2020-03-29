﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : SceneBase
{

    [SerializeField]
    SpriteRenderer spaceRender = null;

    [SerializeField]
    Sprite[] spaceSprites = null;

    int animCnt = 0;


    private void OnEnable()
    {
        print("OnEnable TitleScene");
        EventManager.OnMultipleInput += OnMultipleInput;

        spaceRender.sprite = spaceSprites[0];
        animCnt = 0;
    }

    private void OnDisable()
    {
        print("OnDisable TitleScene");
        EventManager.OnMultipleInput -= OnMultipleInput;
    }

    void Update()
    {

        if (animCnt++ % 60 == 0)
        {
            spaceRender.sprite = (spaceRender.sprite == spaceSprites[1]) ? spaceSprites[0] : spaceSprites[1];
        }

    }

    public void OnMultipleInput(eInputType inputType)
    {
        if (inputType == eInputType.Space)
        {
            ProgressManager.Instance.MoveScene(eSceneState.Play);
            AudioManager.Instance.PlaySE("Start" + Random.Range(0, 2));
        }
    }

    public override void Open()
    {
        gameObject.SetActive(true);
    }

    public override void Close()
    {
        gameObject.SetActive(false);
    }
}
