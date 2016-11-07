using UnityEngine;
using System.Collections;

public class PlayerHitDetection : MonoBehaviour {

    public KillEnemyDelegate killEnemy;
    PlayerControlScript controlScript;
    public SoundScript sounds;
    public Camera mainCam;
    public GameObject dogWeed;
    public GameObject arcaine;
    Game game;

	// Use this for initialization
	void Start () {
        controlScript = GetComponentInParent<PlayerControlScript> ();
        sounds = mainCam.GetComponent<SoundScript> ();
        game = sounds.GetComponentInParent<Game> ();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter2D (Collider2D coll)
    {
        if (coll.tag == "Bar") {
                killEnemy (coll.gameObject);
                sounds.PlaySong (AudioToPlay.Destroy);
                if (Random.Range (0, 15) == 1) {
                    Instantiate
                    (dogWeed, coll.transform.position, Quaternion.identity);
                }
                if (Random.Range (0, 15) == 1) {
                    Instantiate
                    (arcaine, coll.transform.position, Quaternion.identity);
                }
                sounds.PlaySong (AudioToPlay.GameOver);

        } else if (coll.tag == "DeathCircle") {
            if (controlScript.state == PlayerControlScript.PlayerStates.DogWeed) {
                sounds.PlaySong (AudioToPlay.SongA);
            }
            controlScript.state = PlayerControlScript.PlayerStates.Dying;
            sounds.PlaySong (AudioToPlay.GameOver);

        } else if (coll.tag == "Dogweed") {
            if (controlScript.state == PlayerControlScript.PlayerStates.DogWeed) {
                sounds.PlaySong (AudioToPlay.SongA);
            }
            controlScript.state = PlayerControlScript.PlayerStates.DogWeed;
            sounds.PlaySong (AudioToPlay.SongB);
        } else if (coll.tag == "Arcaine") {
            sounds.PlaySong (AudioToPlay.OneUp);
            game.lives++;
            game.livesLabel.text = string.Format ("Lives: {0}", game.lives);
        }
    }
}
