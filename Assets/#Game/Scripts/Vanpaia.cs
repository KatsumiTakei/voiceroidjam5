using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vanpaia : MonoBehaviour
{
    float spd = 0.1f;
    private void Start()
    {
        spd = Random.Range(0.005f, 0.05f);
    }

    void Update()
    {
        transform.localPosition += Vector3.left * spd;
    }


    public void HitDamage()
    {
        Destroy(gameObject);
    }
}
