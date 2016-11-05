using UnityEngine;
using System.Collections;

public class PlayerHitDetection : MonoBehaviour {

    public KillEnemyDelegate killEnemy;
    PlayerControlScript controlScript;
	// Use this for initialization
	void Start () {
        controlScript = GetComponentInParent<PlayerControlScript> ();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter2D (Collider2D coll)
    {
        if (coll.tag == "Bar") {
            if (controlScript.state == PlayerControlScript.PlayerStates.Dashing) {
                killEnemy (coll.gameObject);
            } else {
                controlScript.state = PlayerControlScript.PlayerStates.Dying;
            }
        }
        if (coll.tag == "DeathCircle") {
            controlScript.state = PlayerControlScript.PlayerStates.Dying;
        }
    }
}
