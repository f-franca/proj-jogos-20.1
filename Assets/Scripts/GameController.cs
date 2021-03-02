using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public PlayerController player; 
    bool gameover = false;
    public float restartdelay = 1f;
    public Text timerText;
    public Text fuelText;
    public float timeRemaining = 60;
    private GameFinishController gameFinishScript;
    //public GameObject completeLevelUI;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("Quit");
            Application.Quit();
        }

        if (timeRemaining > 0)
        {
            updateTimerText();
        }
        else
        {
            EndGame();
        }

        if (player.GetFuel() > 0)
        {
            updateFuelText();
        }
        else
        {
            EndGame();
        }

    }

    public void EndGame()
    {
        if (gameover == false)
        {
            gameover = true;
            Debug.Log("GAME OVER");
            gameFinishScript = GameObject.Find("Game Finish Controller").GetComponent<GameFinishController>();
            gameFinishScript.SetWinState(false);
            SceneManager.LoadScene("Game Finish");
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void updateTimerText()
    {
        timeRemaining -= UnityEngine.Time.deltaTime;
        timerText.text = ("Timer: " + (int)timeRemaining);
    }

    void updateFuelText()
    {
        fuelText.text = ("Fuel: " + player.GetFuel());
    }

    /*
        void Restart()
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    */
    /*
        public void CompleteLevel()
        {
            gameover = true;
            completeLevelUI.SetActive(true);
        }*/
}
