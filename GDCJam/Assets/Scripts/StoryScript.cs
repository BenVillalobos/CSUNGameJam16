using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryScript : MonoBehaviour {

    public GameObject storyImage;
    public Text blinkyText;
    float elapsedTime = 0;
    public float startScrollTimer = 1f;
	// Use this for initialization
	void Start () {
        blinkyText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= startScrollTimer) {
            if (storyImage.transform.position.y <= 580) {
                storyImage.transform.Translate (new Vector3 (0, 0.6f, 0));
            } else {
                blinkyText.enabled = true;
            }
        }
        if ((Input.GetButtonDown ("Xbox Right Shoulder Button") || Input.GetButtonDown ("Xbox Left Shoulder Button"))
                || Input.GetButtonDown ("Fire1") || Input.GetButtonDown ("Fire3")) {
            SceneManager.LoadScene (3, LoadSceneMode.Single);
        }
	}
}
