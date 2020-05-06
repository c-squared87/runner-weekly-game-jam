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

    public delegate void OnMessageBroadcast (string message);
    static event OnMessageBroadcast onMessageBroadcast;

    public static void ADD_MessageBroadcastListener (EventsManager.OnMessageBroadcast _method) {
        onMessageBroadcast += _method;
    }
    public static void REMOVE_MessageBroadcastListener (EventsManager.OnMessageBroadcast _method) {
        onMessageBroadcast -= _method;
    }

    public static void BroadcastMessage (string message) {
        Debug.Log ("I am trying to broadcast " + message);
        if (onMessageBroadcast != null) {
            onMessageBroadcast (message);
        }
    }
}