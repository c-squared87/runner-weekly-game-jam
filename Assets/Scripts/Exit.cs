using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {
    private void OnTriggerEnter2D (Collider2D other) {
        Debug.Log("ding");
        if(other.tag == "Player"){
            SceneManager.LoadScene("TestLevel");
        }
    }
}