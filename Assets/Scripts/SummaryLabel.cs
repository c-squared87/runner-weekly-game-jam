using UnityEngine;
using UnityEngine.UI;

public class SummaryLabel : MonoBehaviour {

    Text text;

    void Start () {
        text = GetComponent<Text> ();

        // string _text = FindObjectOfType<GameManager> ().HitsThisGame ();

        text.text = "You died " + ScoreManager.TotalHitsThisGame () + " times";

        // FindObjectOfType<GameManager> ().ResetHitsCount ();
    }

}