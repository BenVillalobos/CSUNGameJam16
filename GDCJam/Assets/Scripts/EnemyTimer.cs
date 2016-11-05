using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class EnemyTimer : MonoBehaviour {
    
    public Text TimerLabel;
    public GameObject [] SpawnPoints;
    public GameObject BasicEnemy;
    public GameObject player;
    float timeGoneBy = 0;

    // Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        TimerLabel.text = string.Format ("{0}", Math.Round(Time.realtimeSinceStartup,3));
        timeGoneBy += Time.deltaTime;

        if (timeGoneBy >= 2) {
            timeGoneBy = 0;
            GameObject newEnemy = (GameObject)Instantiate (BasicEnemy, SpawnPoints [UnityEngine.Random.Range (0, SpawnPoints.Length)].transform.position, Quaternion.identity);

            EnemyScript newScript = newEnemy.GetComponent<EnemyScript> ();
            newScript.Player = player;
        }
	}
}
