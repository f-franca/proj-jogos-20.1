using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectiveController : MonoBehaviour
{
    public int leastCost = 15;

    private PlayerController playerControllerScript;
    private bool missionAccomplished = false;

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
            
            int totalCostFromPlayer = playerControllerScript.GetTotalCost();
            
            if (totalCostFromPlayer == leastCost)
            {
                Debug.Log("Conseguiu fazer caminho mínimo");
                missionAccomplished = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                Debug.Log($"Não conseguiu fazer caminho mínimo. Mínimo: {leastCost}, feito pelo player: {totalCostFromPlayer}");

            }
        }
    }
}
