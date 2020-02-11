using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayAreaController playAreaCtrl;
    public GameObject gameOverOverlay;
    public GameObject playerOne;
    public GameObject playerTwo;

    private bool deathNotYetPerformed;

    // Start is called before the first frame update
    void Start () {
        deathNotYetPerformed = true;
        playAreaCtrl.isShrinking = true;
    }

    private void FixedUpdate()
    {
        if(!playAreaCtrl.isShrinking)
        {
            print("[Game-Control] Reached endgame");
        }

        if(!playerOne || !playerTwo)
        {
            print("[Game-Control] One player is kill");
            EndGame();
        }
    }

    private void EndGame () {
        if (deathNotYetPerformed) {
            deathNotYetPerformed = false;
            Time.timeScale = 0f;
            gameOverOverlay.SetActive(true);
        }
    }
}
