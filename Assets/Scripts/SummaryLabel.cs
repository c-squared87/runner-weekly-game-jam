using UnityEngine;
using UnityEngine.UI;

public class SummaryLabel : MonoBehaviour {

    Text text;

    void Start () {
        text = GetComponent<Text> ();
        text.text = "You died " + FindObjectOfType<GameManager> ().HitsThisGame () + " times";

        FindObjectOfType<GameManager> ().ResetHitsCount ();
    }

}