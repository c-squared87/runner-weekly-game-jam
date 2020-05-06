using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public CanvasGroup whiteOutImage;

    public int currentLevel;
    [SerializeField] string nextLevelToLoad;

    void Start () {

        // whiteOutImage = GetComponent<CanvasGroup> ();
        // Time.timeScale = 1;
        // whiteOutImage.color = new Color (28, 0, 0, 0.1f);
        StartCoroutine (FadeCanvasGroup (whiteOutImage, 1, 0, 1));
    }

    private void Update () {
        // whiteOutImage.CrossFadeAlpha (1.0f, 2f, true);
    }

    public void EndLevel () {
        StartCoroutine (FadeCanvasGroupOut (whiteOutImage, 0, 1, 1));
    }

    // IEnumerator EndLevelSequence () {
    //     whiteOutImage.CrossFadeAlpha (1.0f, 2f, true);
    //     // yield return null;
    // }

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
        Debug.Log ("done");
    }
    public IEnumerator FadeCanvasGroupOut (CanvasGroup canvasGroup, float start, float end, float length) {

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
        // Debug.Log ("done");
        SceneManager.LoadScene (nextLevelToLoad);
    }
}