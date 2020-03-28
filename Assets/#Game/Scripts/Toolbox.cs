using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProgressMamager))]
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
    }

    void Update()
    {
        InputManager.ManualUpdate();
    }


}
