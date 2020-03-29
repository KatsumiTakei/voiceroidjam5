using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityDLL;
using DG.Tweening;

public class LineRenserManager : SingletonMonoBehaviour<LineRenserManager>
{
    LineRenderer lineRenderer = null;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void ViewLine(Vector2 start, Vector2 end)
    {
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;

        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);

        lineRenderer.DOColor(new Color2(Color.red, Color.red), new Color2(Color.clear, Color.clear), 0.5f);
    }
}
