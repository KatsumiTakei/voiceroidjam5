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
    

    public static Action<int> OnAddScore = null;
    public static void BroadcastAddScore(int addScore) => OnAddScore?.Invoke(addScore);

    
    public static Action<int> OnChangeScore = null;
    public static void BroadcastChangeScore(int score) => OnChangeScore?.Invoke(score);


    
    public static Action<Player> OnChangeLife = null;
    public static void BroadcatChangeLife(Player player) => OnChangeLife?.Invoke(player);

    
    
    public static Action<int> OnChangeAttackCnt = null;
    public static void BroadcastChangeAttackCnt(int attackCnt) => OnChangeAttackCnt?.Invoke(attackCnt);
    
    
    public static Action<Vector2> OnGenerateCoin = null;
    public static void BroadcastGenerateCoin(Vector2 generatePos) => OnGenerateCoin?.Invoke(generatePos);


}