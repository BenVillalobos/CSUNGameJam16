using UnityEngine;
using System.Collections;

public enum AudioToPlay
{
    SongA,
    SongB,
    SongC,
    GameOver,
    Destroy,
    Dash
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
        if (game.gameOverCanvas.isActiveAndEnabled)
        {
            PlaySong(AudioToPlay.GameOver);
        }
        
	}

    public void PlaySong(AudioToPlay audio)
    {
        if(audio == AudioToPlay.GameOver)
        {
            source.Stop();
            source.PlayOneShot(gameOver);
            
        }
        else if(audio == AudioToPlay.Dash)
        {
            source.PlayOneShot(dash);
        }
    }

    void PlayDash()
    {
        PlaySong(AudioToPlay.Dash);
    }
}
