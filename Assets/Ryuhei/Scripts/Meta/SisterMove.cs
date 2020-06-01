using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SisterMove : MonoBehaviour {

    private int Timer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        transform.position += new Vector3(0, Mathf.Sin(Timer / 30) * 0.050f, 0);


        if (++Timer >= 300)
        {

            // transformを取得
            Transform myTransform = this.transform;

            // 座標を取得
            Vector3 pos = myTransform.position;
            pos.x += 0.05f;    // x座標へ0.01加算

            myTransform.position = pos;  // 座標を設定
        }
        if (Timer >= 480)
        {
            this.gameObject.SetActive(false);
        }

	}
}
