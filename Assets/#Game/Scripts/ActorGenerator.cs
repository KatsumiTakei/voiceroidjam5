using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using STLExtensiton;
using UnityDLL;

public class ActorGenerator : MonoBehaviour
{

    [SerializeField]
    Vanpaia vanpaiaPrefab = null;

    [SerializeField]
    Vector3 topRail = Vector3.zero;

    [SerializeField]
    Vector3 centerRail = Vector3.zero;

    [SerializeField]
    Vector3 bottomRail = Vector3.zero;

    [SerializeField]
    Weapon[] weapons = null;

    Vector3[] rails = null;

    int tempoLevel = 0;
    float enemyGenerateCnt = 0;
    float generateTempo = 1f;

    float weaponGenerateCnt = 0;

    static List<KeyValuePair<Weapon, float>> itemDict = null;

    void Start()
    {
        itemDict = new List<KeyValuePair<Weapon, float>>() {
        new KeyValuePair<Weapon, float>(weapons[0], 90f),
        new KeyValuePair<Weapon, float>(weapons[1], 10f),
        };

        rails = new Vector3[] { topRail, centerRail, bottomRail };
    }

    void Update()
    {
        enemyGenerateCnt += generateTempo;

        if (enemyGenerateCnt >= 45f)
        {
            enemyGenerateCnt = 0;
            tempoLevel++;

            var vanpaia = Instantiate(vanpaiaPrefab, transform);
            vanpaia.transform.localPosition = rails[Random.Range(0, 3)];
        }

        weaponGenerateCnt += generateTempo;
        if (weaponGenerateCnt >= 60f)
        {
            weaponGenerateCnt = 0;
            Weapon weaponPrefab = RandomWithWeight.Lotto(itemDict);
            Weapon weapon = Instantiate(weaponPrefab, transform);
            weapon.transform.localPosition = rails[Random.Range(0, 3)];
        }

        if (tempoLevel >= 15)
        {
            tempoLevel = 0;
            generateTempo += 0.2f;
        }
    }
}
