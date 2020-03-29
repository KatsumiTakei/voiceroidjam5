using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(1)]
[RequireComponent(typeof(ProgressManager))]
[RequireComponent(typeof(AudioManager))]
public class Toolbox : MonoBehaviour
{
    void Start()
    {
        AudioManager.PlayBGM("BGM");
    }

    void Update()
    {
        InputManager.ManualUpdate();
    }


}
