using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScoreManager : MonoBehaviour
{
    int score = 0;

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
        EventManager.OnGameResult += OnGameResult;
        EventManager.OnAddScore += OnAddScore;
        EventManager.OnChangeScore += OnChangeScore;
    }

    private void OnDisable()
    {
        EventManager.OnGameResult -= OnGameResult;
        EventManager.OnAddScore -= OnAddScore;
        EventManager.OnChangeScore -= OnChangeScore;
    }

    void OnGameResult()
    {
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(score);
    }

    void OnAddScore(int addScore)
    {
        score += addScore;
        view?.AnimChangeScore(addScore, score);
    }

    void OnChangeScore(int score)
    {
        this.score = score;
        view?.AnimChangeScore(0, score);
    }

}