using UnityEngine;

public class TutorialTip : MonoBehaviour {

    [SerializeField] string message;

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.tag == "Player") {
            EventsManager.BroadcastMessage (message);
            Destroy (gameObject);
        }
    }
}