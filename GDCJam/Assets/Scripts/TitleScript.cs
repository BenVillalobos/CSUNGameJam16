﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{

    // Use this for initialization
    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {

    }

    public void BeginPressed ()
    {
        SceneManager.LoadScene (1, LoadSceneMode.Single);
    }
}