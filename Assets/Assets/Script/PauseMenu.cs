using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    [SerializeField] private GameObject pauseOverlay;

    public void Toggle() {
        if (pauseOverlay.activeInHierarchy) {
            pauseOverlay.SetActive(false);
            Time.timeScale = 1f;
        }
        else {
            pauseOverlay.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    // Exit to title menu
    public void Exit () {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(0);
    }
 
    // Reload current scene
	public void Restart () {
		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

	void LateUpdate () {
        // Toggle paused state on Esc key
        if (Input.GetButtonDown("Cancel"))
            Toggle();

        // Restart if r pressed
        if (Input.GetButtonDown("Restart"))
            Restart();
    }
}
