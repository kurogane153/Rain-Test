using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UIコンポーネントの使用

public class move1menu : MonoBehaviour {

    Button GameStart;

    void Start()
    {
        // ボタンコンポーネントの取得
        GameStart = GameObject.Find("/Canvas 1/Game Start").GetComponent<Button>();

        // 最初に選択状態にしたいボタンの設定
        GameStart.Select();
    }
}
