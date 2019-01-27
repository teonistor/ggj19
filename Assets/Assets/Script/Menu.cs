using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour {

    [SerializeField] private GameObject[] titleScreen, rulesScreen;

    private void Awake () {
        // In case we return to title screen from paused game
        Time.timeScale = 1f;
        activateAll(titleScreen);
    }

    public void Play () {
        deactivateAll(titleScreen);
        SceneManager.LoadSceneAsync(1);
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
    }

    public void Rules () {
        deactivateAll(titleScreen);
        activateAll(rulesScreen);
    }

    public void Quit () {
        Application.Quit();
    }

    public void Back () {
        deactivateAll(rulesScreen);
        activateAll(titleScreen);
    }

    private void activateAll (GameObject[] objs) {
        foreach (GameObject o in objs)
            o.SetActive(true);
    }

    private void deactivateAll (GameObject[] objs) {
        foreach (GameObject o in objs)
            o.SetActive(false);
    }
}
