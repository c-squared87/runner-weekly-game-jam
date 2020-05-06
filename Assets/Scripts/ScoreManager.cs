using UnityEngine;

public static class ScoreManager {

    static int totalHits;
    static int hitsThisLevel;
    static float timer;

    public static void ResetScores () {
        totalHits = 0;
        hitsThisLevel = 0;
        timer = 0;
    }

    public static void PlayerHit () {
        totalHits++;
    }
}