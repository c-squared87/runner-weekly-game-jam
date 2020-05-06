using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    int totalHits = 9;
    int hitsThisLevel = 9;

    private void Start () {

        if (Instance == null) { Instance = this; }
        if (Instance != this) { Destroy (gameObject); return; }

        DontDestroyOnLoad (this.gameObject);

    }

    private void OnEnable () {
        EventsManager.ADD_PlayerHitListener (AddHit);
        // EventsManager.ADD_OnLevelEndListener (EndLevel);
    }

    private void OnDisable () {
        EventsManager.REMOVE_PlayerHitListener (AddHit);
        // EventsManager.REMOVE_OnLevelEndListener (EndLevel);
    }

    private void EndLevel () {
        totalHits += hitsThisLevel;
        // hitsThisLevel = 0;
    }

    private void Update () {
        Debug.Log (HitsThisGame ());
    }

    private void AddHit () {
        totalHits += 1;
        hitsThisLevel += 1;

    }

    // public void ResetHitsCount () {
    //     totalHits = 0;
    //     hitsThisLevel = 0;
    // }

    public string HitsThisGame () {
        Debug.Log ("hitstsss" + hitsThisLevel);
        return totalHits.ToString ();
    }
}