using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryScript : MonoBehaviour {

    public GameObject storyImage;
    public Text blinkyText;
    float elapsedTime = 0;
    public float showTimer = 30f;
    public float startScrollTimer = 1f;
	// Use this for initialization
	void Start () {
        blinkyText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= startScrollTimer) {
            if (blinkyText.enabled == false && elapsedTime >= showTimer) {
                blinkyText.enabled = true;
            }
            if (storyImage.transform.position.y <= 6.4) {
                storyImage.transform.Translate (new Vector3 (0, 0.008f, 0));
            }
        }
        if ((Input.GetButtonDown ("Xbox Right Shoulder Button") || Input.GetButtonDown ("Xbox Left Shoulder Button"))
                || Input.GetButtonDown ("Fire1") || Input.GetButtonDown ("Fire3")) {
            SceneManager.LoadScene (3, LoadSceneMode.Single);
        }
	}
}
