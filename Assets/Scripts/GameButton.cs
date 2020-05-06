﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameButton : MonoBehaviour {

    [SerializeField] string subText;
    [SerializeField] string sceneToLoad;

    Button thisButton;

    private void Start () {
        thisButton = GetComponent<Button> ();
        thisButton.onClick.AddListener (LoadAScene);
    }

    void LoadAScene () {
        // Debug.Log ("I am going to load " + sceneToLoad);
        SceneManager.LoadScene (sceneToLoad);
    }
}