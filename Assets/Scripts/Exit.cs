using UnityEngine;

public class Exit : MonoBehaviour {

    [SerializeField] string sceneToLoad;

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.tag == "Player") {
            FindObjectOfType<LevelManager> ().EndLevel ();

            //TODO: LEVEL END EVENT - TRIGGERS PLAYTER ACTIONS TOO - FLY AWAY?
        }
    }

}

/*
           When player triggers the exit,
            we need to show an end level screen, and 
            give options for the player to go to the next level, 
           */