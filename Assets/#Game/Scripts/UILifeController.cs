using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using STLExtensiton;
using UnityDLL;
using UnityEngine.UI;

public class UILifeController : MonoBehaviour
{ 
    #region		Variables 

    [SerializeField]
    SpriteRenderer lifeImage = null;

    #endregion  Variables 

    #region		Functions 

    public void OnChangeLife(Player player)
    {
        int currentLifeMax = player.Life;
        if (currentLifeMax >= 0)
            lifeImage.size = new Vector2(0.25f * currentLifeMax, 0.25f);
    }

    #endregion  Functions 

    #region		Events

    private void OnEnable()
    {
        EventManager.OnChangeLife += OnChangeLife;
    }

    private void OnDisable()
    {
        EventManager.OnChangeLife -= OnChangeLife;
    }

    #endregion  Events 
}
