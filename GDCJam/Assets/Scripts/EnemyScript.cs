using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    public GameObject Player;
    public float speed = 0.01f;

	// Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards (transform.position, Player.transform.position, speed);
        transform.Rotate (Vector3.forward * -1);
	}
}
