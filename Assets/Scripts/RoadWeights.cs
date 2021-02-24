using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoadWeights : MonoBehaviour
{
    
    public Text fuelTextHud; // Para atualizar o Fuel no HUD
    public ObjectiveController objectiveController;  // Pegar o script do objetivo e passa o valor do menor caminho

    public int minWeight = 1;
    public int maxWeight = 20;

    private List<int> weightList = new List<int>();


    // Start is called before the first frame update
    void Start()
    {
        int childCount = gameObject.transform.childCount;

        for (int i = 0 ; i < childCount ; i++)
        {
            int rand_num = Random.Range(minWeight, maxWeight);
            
            GameObject child = this.gameObject.transform.GetChild(i).gameObject;
            GameObject pesoGameObject = child.transform.Find("Peso").gameObject;


            TextMeshPro childGameObject = pesoGameObject.GetComponent<TextMeshPro>();
            
            childGameObject.SetText(rand_num.ToString());
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
