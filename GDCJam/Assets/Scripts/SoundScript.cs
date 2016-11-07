using UnityEngine;
using System.Collections;

public enum AudioToPlay
{
    SongA,
    SongB,
    SongC,
    GameOver,
    Destroy,
    Dash,
    OneUp
}
public class SoundScript : MonoBehaviour {

    Game game;
    PlayerControlScript controls;
    public AudioClip songA;
    public AudioClip songB;
    public AudioClip songC;
    public AudioClip gameOver;
    public AudioClip destroy;
    public AudioClip dash;
    public GameObject player;
    public AudioClip oneUp;
    AudioSource source;

    // Use this for initialization
    void Start () {
        game = GetComponentInParent<Game>();
        source = GetComponentInParent<AudioSource>();
        controls = game.player.GetComponent<PlayerControlScript>();
        controls.playDash = PlayDash;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void PlaySong(AudioToPlay audio)
    {
        switch (audio) {
        case AudioToPlay.GameOver:
            source.PlayOneShot (gameOver);
            break;
        case AudioToPlay.Dash:
            source.PlayOneShot (dash);
            break;
        case AudioToPlay.Destroy:
            source.PlayOneShot (destroy);
            break;
        case AudioToPlay.SongA:
            source.clip = songA;
            source.Play ();
            break;
        case AudioToPlay.SongB:
            source.clip = songB;
            source.Play ();
            break;
        case AudioToPlay.OneUp:
            source.PlayOneShot (oneUp);
            break;
        }
    }

    public void GameOver()
    {
        source.loop = false;
        source.clip = gameOver;
        source.Play ();
    }

    void PlayDash()
    {
        PlaySong(AudioToPlay.Dash);
    }
}
