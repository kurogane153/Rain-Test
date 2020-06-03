using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour {

    Button GameStart;
    Button GameEnd;

    void Start () {

        // ボタンコンポーネントの取得
        GameStart = GameObject.Find("/Canvas/ReStart").GetComponent<Button>();
        GameEnd = GameObject.Find("/Canvas/Titel").GetComponent<Button>();

        // 最初に選択状態にしたいボタンの設定
        GameStart.Select();
    }
	
	void Update () {
        
    }
}
