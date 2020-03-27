using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{

    public static void ManualUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            EventManager.BroadcastMultipleInput(eInputType.AttackAndDecide);
        }     
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            EventManager.BroadcastMultipleInput(eInputType.Cancel);
        }    
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            EventManager.BroadcastMultipleInput(eInputType.MoveUpKey);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            EventManager.BroadcastMultipleInput(eInputType.MoveDownKey);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            EventManager.BroadcastMultipleInput(eInputType.MoveLeftKey);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            EventManager.BroadcastMultipleInput(eInputType.MoveRightKey);
        }
    }

}


public enum eInputType
{

    MoveLeftKey,
    MoveRightKey,
    MoveUpKey,
    MoveDownKey,

    AttackAndDecide,
    Cancel,

    Random = 99,

}
