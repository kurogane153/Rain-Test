using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainController_Stairs : MonoBehaviour
{
    public GameObject rainPrefab;
    public float interval; // 雨が降る間隔
    private float time = 0f; // 経過時間

    private void Update()
    {
        time += Time.deltaTime;

        if (time > interval)
        {
            GameObject rain = Instantiate(rainPrefab);

            rain.transform.position = this.transform.position; // このプレハブの位置から生成

            time = 0f; // 経過時間のリセット
        }
    }
}
