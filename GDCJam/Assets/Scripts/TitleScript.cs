using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    public Canvas titleCanvas;
    public Canvas storyCanvas;
    // Use this for initialization
    void Start ()
    {
        storyCanvas.enabled = false;
        storyCanvas.GetComponent<StoryScript> ().enabled = false;
    }

    // Update is called once per frame
    void Update ()
    {

    }

    public void BeginPressed ()
    {
        storyCanvas.enabled = true;
        storyCanvas.GetComponent<StoryScript> ().enabled = true;
        titleCanvas.enabled = false;
    }
}
