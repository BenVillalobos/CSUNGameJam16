using UnityEngine;
using System.Collections;

public class PlayerHitDetection : MonoBehaviour {

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
                Debug.Log ("Yo");
                EnemyScript eScript = coll.gameObject.transform.GetComponentInParent<EnemyScript> ();
                eScript.arms--;
                Destroy (coll.gameObject.transform.parent.gameObject);
            } else {
                controlScript.state = PlayerControlScript.PlayerStates.Dying;
            }
        }
        if (coll.tag == "DeathCircle") {
            controlScript.state = PlayerControlScript.PlayerStates.Dying;
        }
    }
}
