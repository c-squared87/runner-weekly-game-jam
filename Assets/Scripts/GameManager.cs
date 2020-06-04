using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    int totalHits;
    int hitsThisLevel;

    void Awake () {
        Screen.SetResolution (800, 600, false);
    }

    private void Start () {

        if (Instance == null) { Instance = this; }
        if (Instance != this) { Destroy (gameObject); return; }

        DontDestroyOnLoad (this);
    }

    private void OnEnable () {
        EventsManager.ADD_PlayerHitListener (AddHit);
        // EventsManager.ADD_OnLevelEndListener (EndLevel);
    }

    private void OnDisable () {
        EventsManager.REMOVE_PlayerHitListener (AddHit);
        // EventsManager.REMOVE_OnLevelEndListener (EndLevel);
    }

    // private void EndLevel () {
    //     totalHits += hitsThisLevel;
    //     // hitsThisLevel = 0;
    // }

    private void AddHit () {
        totalHits += 1;
        hitsThisLevel += 1;
    }

    // public void ResetHitsCount () {
    //     totalHits = 0;
    //     hitsThisLevel = 0;
    // }

    public string HitsThisGame () {
        Debug.Log ("hits called and it is " + hitsThisLevel);
        return hitsThisLevel.ToString ();
    }
}