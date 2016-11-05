using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class EnemyTimer : MonoBehaviour {
    
    public Text TimerLabel;

    float timeGoneBy = 0;
    public Game.GenerateEnemyDelegate generateAnEnemy;

    // Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        TimerLabel.text = string.Format ("{0}", Math.Round(Time.realtimeSinceStartup,3));
        timeGoneBy += Time.deltaTime;

        if (timeGoneBy >= 2) {
            timeGoneBy = 0;
            generateAnEnemy ();
        }
	}
}
