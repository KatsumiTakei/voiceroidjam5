using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProgressMamager))]
public class Toolbox : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        InputManager.ManualUpdate();
    }


}
