using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainMessageField : MonoBehaviour {

    Text text;

    [SerializeField] float clearDelay = 2f;

    private void OnEnable () {
        EventsManager.ADD_MessageBroadcastListener (UpdateUI);
        UpdateUI ("");
    }
    private void OnDisable () {
        EventsManager.REMOVE_MessageBroadcastListener (UpdateUI);
    }

    private void UpdateUI (string message) {
        StopCoroutine ("ClearMessage");
        if (text == null) { text = GetComponent<Text> (); }
        text.text = message;
        StartCoroutine ("ClearMessage");
    }

    IEnumerator ClearMessage () {
        yield return new WaitForSeconds (clearDelay);
        UpdateUI ("");
    }

}