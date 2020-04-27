using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UIコンポーネントの使用

public class menu : MonoBehaviour {

    Button GameStart;
    Button GameEnd;

    void Start()
    {
        // ボタンコンポーネントの取得
        GameStart = GameObject.Find("/Canvas/Game Start").GetComponent<Button>();
        GameEnd = GameObject.Find("/Canvas/Game End").GetComponent<Button>();

        // 最初に選択状態にしたいボタンの設定
        GameStart.Select();
    }
}
