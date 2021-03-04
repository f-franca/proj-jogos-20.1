using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectiveController : MonoBehaviour
{
    private int leastCost = 15;

    private PlayerController playerControllerScript;
    private GameFinishController gameFinishScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerControllerScript = other.GetComponent<PlayerController>();
            gameFinishScript = GameObject.Find("Game Finish Controller").GetComponent<GameFinishController>();

            int totalCostFromPlayer = playerControllerScript.GetTotalCost();
            
            if (totalCostFromPlayer == leastCost)
            {
                Debug.Log("Conseguiu fazer caminho mínimo");

                gameFinishScript.SetWinState(true);
                SceneManager.LoadScene("Game Finish");
            }
            else
            {
                Debug.Log($"Não conseguiu fazer caminho mínimo. Mínimo: {leastCost}, feito pelo player: {totalCostFromPlayer}");
                
                gameFinishScript.SetWinState(false);
                SceneManager.LoadScene("Game Finish");
            }
        }
    }

    public void setLeastCost(int i)
    {
        this.leastCost = i;
    }
}
