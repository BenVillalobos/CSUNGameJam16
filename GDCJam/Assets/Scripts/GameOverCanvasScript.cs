using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverCanvasScript : MonoBehaviour {

    public Camera mainCam;
    Game gameScript;
    public Text scoreLabel;
    public float flashTime = 1.5f;
    float timeGoneBy = 0;

	// Use this for initialization
	void Start () {
        gameScript = mainCam.GetComponent<Game> ();
        timeGoneBy = 0;
	}

	// Update is called once per frame
	void Update () {
        scoreLabel.text = string.Format ("Score: {0}", gameScript.score);
        timeGoneBy += Time.deltaTime;

        if (timeGoneBy >= flashTime) {
            timeGoneBy = 0;
            scoreLabel.enabled = !scoreLabel.enabled;
        }
	}
}
