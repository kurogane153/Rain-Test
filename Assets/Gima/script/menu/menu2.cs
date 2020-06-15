using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UIコンポーネントの使用

public class menu2 : MonoBehaviour {

    Button GameStart;

    void Start()
    {
        // ボタンコンポーネントの取得
        GameStart = GameObject.Find("/Canvas 1/Game End").GetComponent<Button>();

        // 最初に選択状態にしたいボタンの設定
        GameStart.Select();
    }
}
