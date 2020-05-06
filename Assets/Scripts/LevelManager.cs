using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public CanvasGroup whiteOutImage;

    public int currentLevel;
    [SerializeField] string nextLevelToLoad;

    void Start () {

        StartCoroutine (FadeCanvasGroup (whiteOutImage, 1, 0, 1));
    }

    private void OnEnable () {
        EventsManager.ADD_OnLevelEndListener (EndLevel);
    }
    private void OnDisable () {
        EventsManager.REMOVE_OnLevelEndListener (EndLevel);
    }

    void EndLevel () {
        StartCoroutine (FadeCanvasGroupOut (whiteOutImage, 0, 1, 1));
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
        SceneManager.LoadScene (nextLevelToLoad);
    }
}