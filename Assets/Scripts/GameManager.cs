using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public int totalHits;
    public int hitsThisLevel;

    private void Start () {

        if (Instance == null) { Instance = this; }
        if (Instance != this) { Destroy (gameObject); return; }

        DontDestroyOnLoad (this.gameObject);

        ResetHitsCount ();
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

    private void AddHit () {
        Debug.Log ("add hit called" + hitsThisLevel);
        hitsThisLevel += 1;
    }

    public void ResetHitsCount () {
        totalHits = 0;
        hitsThisLevel = 0;
    }
}