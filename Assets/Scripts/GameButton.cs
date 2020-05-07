using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameButton : MonoBehaviour {

    [SerializeField] string subText;
    [SerializeField] string sceneToLoad;

    Button thisButton;

    [SerializeField] bool quitButton = false;

    private void Start () {
        thisButton = GetComponent<Button> ();

        if (quitButton) {
            thisButton.onClick.AddListener (doExitGame);
            return;
        }

        thisButton.onClick.AddListener (LoadAScene);
    }

    void LoadAScene () {
        SceneManager.LoadScene (sceneToLoad);
    }

    void doExitGame () {
        Application.Quit ();
    }
}