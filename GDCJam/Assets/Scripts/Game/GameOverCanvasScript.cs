using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverCanvasScript : MonoBehaviour {

    public Camera mainCam;
    public GameObject Nixon;
    public GameObject Ussr;
    Game gameScript;
    public Text scoreLabel;
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


	}
}
