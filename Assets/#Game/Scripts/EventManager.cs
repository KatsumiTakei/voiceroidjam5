using System;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{

    public static Action<float> OnChangeTime = null;
    public static void BroadcastChangeTime(float currentTime) => OnChangeTime?.Invoke(currentTime);


    public static Action<eInputType> OnMultipleInput = null;
    public static void BroadcastMultipleInput(eInputType inputType) => OnMultipleInput?.Invoke(inputType);

    public static Action<bool> OnGameResult = null;
    public static void BroadcastGameResult(bool isResult) => OnGameResult?.Invoke(isResult);


}