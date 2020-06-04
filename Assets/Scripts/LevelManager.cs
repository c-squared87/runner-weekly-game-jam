using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public CanvasGroup whiteOutImage;

    public int currentLevel;
    [SerializeField] string nextLevelToLoad;

    void Start () {
        Time.timeScale = 1;
    }

    private void OnEnable () {
        EventsManager.ADD_OnLevelEndListener (EndLevel);
    }
    private void OnDisable () {
        EventsManager.REMOVE_OnLevelEndListener (EndLevel);
    }

    void EndLevel () {
        StartCoroutine (LoadNext (3));
    }

    IEnumerator LoadNext (float time) {
        yield return new WaitForSeconds (time);
        SceneManager.LoadScene (nextLevelToLoad);
    }
}