using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    // ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    // ゲームオーバーを表示するテキスト
    private GameObject gameoverText;
    private GameObject scoreText;

    // スコアポイントの初期値
    private int ScorePoints = 0;

	// Use this for initialization
	void Start () {
        // シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        this.scoreText = GameObject.Find("Score");
    }
	
	// Update is called once per frame
	void Update () {
		// ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            // GameoverTextにゲームオーバーを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
	}

    //OnCollisionEnter()
    private void OnCollisionEnter(Collision collision)
    {
        //Sphereが衝突したオブジェクトがPlaneだった場合
        if (collision.gameObject.tag == "SmallStarTag")
        {
            ScorePoints += 5;
            this.scoreText.GetComponent<Text>().text = "得点：" + ScorePoints;
        }
        else if (collision.gameObject.tag == "LargeStarTag")
        {
            ScorePoints += 50;
            this.scoreText.GetComponent<Text>().text = "得点：" + ScorePoints;
        }
        else if (collision.gameObject.tag == "SmallCloudTag")
        {
            ScorePoints += 10;
            this.scoreText.GetComponent<Text>().text = "得点：" + ScorePoints;
        }
        else if (collision.gameObject.tag == "LargeCloudTag")
        {
            ScorePoints += 30;
            this.scoreText.GetComponent<Text>().text = "得点：" + ScorePoints;
        }
    }
}
