using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    Game game;
    public GameObject [] AllEnemyTypes;
    public GameObject [] SpawnPoints;
    GameObject [] allEnemies;

	// Use this for initialization
	void Start () {
        game = GetComponentInParent<Game> ();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void GenerateRandomEnemy ()
    {
        GameObject newEnemy = (GameObject)Instantiate 
            (AllEnemyTypes[UnityEngine.Random.Range(0, AllEnemyTypes.Length)], 
             SpawnPoints [UnityEngine.Random.Range (0, SpawnPoints.Length)].transform.position, Quaternion.identity);
        EnemyScript newScript = newEnemy.GetComponent<EnemyScript> ();
        newScript.Player = game.player;
        game.allEnemies.Add (newEnemy);
    }
}
