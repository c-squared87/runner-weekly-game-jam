using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadePanel : MonoBehaviour {

    CanvasGroup thisGroup;
    Text labelText;

    [SerializeField] bool fadeIn = false;

    [SerializeField] string labelTextOpening;

    private void Start () {
        thisGroup = GetComponent<CanvasGroup> ();

        labelText = GetComponentInChildren<Text> ();

        labelText.text = labelTextOpening;

        if (fadeIn) {
            StartCoroutine (FadeCanvasGroup (thisGroup, 0, 1, 1));
        } else {
            StartCoroutine (FadeCanvasGroup (thisGroup, 1, 0, 1));
        }
    }

    private void OnEnable () {
        EventsManager.ADD_OnLevelEndListener (EndLevel);
    }

    private void OnDisable () {
        EventsManager.REMOVE_OnLevelEndListener (EndLevel);
    }

    void EndLevel () {
        StartCoroutine (FadeCanvasGroupOut (thisGroup, 0, 1, 1));
    }

    public IEnumerator FadeCanvasGroup (CanvasGroup canvasGroup, float start, float end, float length) {

        float _timeStartedLerp = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerp;
        float _percentageComplete = timeSinceStarted / length;

        while (true) {

            timeSinceStarted = Time.time - _timeStartedLerp;
            _percentageComplete = timeSinceStarted / length;

            float currentValue = Mathf.Lerp (start, end, _percentageComplete);

            canvasGroup.alpha = currentValue;

            if (_percentageComplete >= 1) {
                break;
            }

            yield return new WaitForEndOfFrame ();
        }
        if (!fadeIn) { labelText.text = ""; }
    }

    public IEnumerator FadeCanvasGroupOut (CanvasGroup canvasGroup, float start, float end, float length) {

        labelText.text = "Killed " + FindObjectOfType<GameManager> ().HitsThisGame () + " Times So Far. Good Job.";

        float _timeStartedLerp = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerp;
        float _percentageComplete = timeSinceStarted / length;

        while (true) {

            timeSinceStarted = Time.time - _timeStartedLerp;
            _percentageComplete = timeSinceStarted / length;

            float currentValue = Mathf.Lerp (start, end, _percentageComplete);

            canvasGroup.alpha = currentValue;

            if (_percentageComplete >= 1) {
                break;
            }

            yield return new WaitForEndOfFrame ();
        }
        // SceneManager.LoadScene (nextLevelToLoad);
    }
}