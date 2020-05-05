using UnityEngine;

public static class EventsManager {

    public delegate void OnPlayerHit ();
    static event OnPlayerHit onPlayerHit;

    public static void ADD_PlayerHitListener (EventsManager.OnPlayerHit _method) {
        onPlayerHit += _method;
    }
    public static void REMOVE_PlayerHitListener (EventsManager.OnPlayerHit _method) {
        onPlayerHit -= _method;
    }

    public static void PlayerHit () {
        if (onPlayerHit != null) {
            onPlayerHit ();
        }
    }
}