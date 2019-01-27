using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayAreaController playAreaCtrl;
    public GameObject gameOverOverlay;
    public GameObject playerOne;
    public GameObject playerTwo;

    // Start is called before the first frame update
    void Start()
    {
        print("[Game-Control] Starting game");
        playAreaCtrl.isShrinking = true;
    }

    // Update is called once per frame
    void Update()
    {
        
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

    private void EndGame()
    {
        Time.timeScale = 0f;
        gameOverOverlay.SetActive(true);
    }
}
