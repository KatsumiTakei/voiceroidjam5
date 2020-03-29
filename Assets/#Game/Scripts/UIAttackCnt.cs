using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class UIAttackCnt : MonoBehaviour
{
    #region		Variables 

    TMPro.TextMeshPro textmesh = null;

    #endregion  Variables 

    #region		Functions 

    void Start()
    {
        textmesh = GetComponent<TMPro.TextMeshPro>();
    }

    public void OnChangeAttackCnt(int attackCnt)
    {
        textmesh.text = attackCnt.ToString();
    }

    #endregion  Functions 

    #region		Events

    private void OnEnable()
    {
        EventManager.OnChangeAttackCnt += OnChangeAttackCnt;
    }

    private void OnDisable()
    {
        EventManager.OnChangeAttackCnt -= OnChangeAttackCnt;
    }

    #endregion  Events 
}