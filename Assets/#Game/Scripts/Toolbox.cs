using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProgressManager))]
[RequireComponent(typeof(AudioManager))]
public class Toolbox : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Initialize()
    {
        new GameObject("Manager", typeof(Toolbox));
    }


    void Start()
    {
        AudioManager.PlayBGM("BGM");
    }

    void Update()
    {
        InputManager.ManualUpdate();
    }


}
