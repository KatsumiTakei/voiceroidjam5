using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScene : SceneBase
{

    private void OnEnable()
    {
        print("OnEnable ResultScene");
    }

    private void OnDisable()
    {
        print("OnDisable ResultScene");
    }


    public void OnMultipleInput(eInputType inputType)
    {
        if (inputType == eInputType.Space)
        {
            ProgressManager.Instance.MoveScene(eSceneState.Title);
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