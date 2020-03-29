using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.PlaySE("DropCoin");
    }

    private void Update()
    {
        transform.localPosition += Vector3.left * 0.05f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySE("PickCoin");
            EventManager.BroadcastAddScore(100);
            Destroy(gameObject);
        }
    }
}
