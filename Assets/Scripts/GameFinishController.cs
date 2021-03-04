using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFinishController : MonoBehaviour
{
    public string failHeader = "NOT THIS TIME";
    public string winHeader = "CONGRATULATIONS!";
    public string failExplanation = "You didn't finish the stage finding the shortest path";
    public string winExplanation = "You have finished the game finding all the shortest paths to the objective";

    private GameObject menuGameObject;
    private bool winState = false;
    private Text headerText;
    private Text explanationText;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(GameObject.Find("Game Finish Controller"));
        //DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (!menuGameObject)
        {
            //Debug.Log("N�o estou achando menu GO");
            menuGameObject = GameObject.Find("Menu");
        }
        else
        {
            //Debug.Log("Achei menu GO");
            headerText = menuGameObject.transform.Find("Header").GetComponent<Text>();
            explanationText = menuGameObject.transform.Find("Explanation").GetComponent<Text>();

            UpdateMenuText(headerText, explanationText);

        }
    }

    private void UpdateMenuText(Text header, Text explanation)
    {
        if (winState)
        {
            header.text = winHeader;
            explanation.text = winExplanation;
        } else
        {
            header.text = failHeader;
            explanation.text = failExplanation;
        }
    }

    public void SetWinState(bool value)
    {
        this.winState = value;
    }

    public bool GetWinState()
    {
        return this.winState;
    }
}
