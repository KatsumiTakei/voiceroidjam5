using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScoreManager : MonoBehaviour
{
    int score = 0;
    double currentTime = 0;

    ScoreCounterView view = null;
    public const int LimitScore = 999999999;

    public void Reset()
    {
        score = 0;
        view.AnimChangeScore(0, score);
    }

    private void Start()
    {
        view = new ScoreCounterView(GetComponent<TMPro.TextMeshPro>(), 0.5f, 10f);
    }

    private void OnEnable()
    {
        //EventManager.OnGameResult += OnGameResult;
        EventManager.OnAddScore += OnAddScore;
        EventManager.OnChangeScore += OnChangeScore;
        EventManager.OnChangeTime += OnChangeTime;
    }

    private void OnDisable()
    {
        //EventManager.OnGameResult -= OnGameResult;
        EventManager.OnAddScore -= OnAddScore;
        EventManager.OnChangeScore -= OnChangeScore;
        EventManager.OnChangeTime -= OnChangeTime;
    }

    //void OnGameResult(bool isResult)
    //{
    //    naichilab.RankingLoader.Instance.SendScoreAndShowRanking(score);
    //}

    void OnChangeTime(float currentTime)
    {
        this.currentTime = currentTime;
    }

    void OnAddScore(int addScore)
    {
        view.AnimChangeScore(addScore, score);
    }

    void OnChangeScore(int score)
    {
        this.score = score;
        view.AnimChangeScore(0, score);
    }

}