using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class RoadWeightController : MonoBehaviour
{
    public GameObject weightText;

    private TMP_Text m_TextComponent;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        m_TextComponent = weightText.GetComponent<TMP_Text>();
        //m_TextComponent.text = "Some new line of text.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerControllerScript = other.GetComponent<PlayerController>();
            //Debug.Log("Consumir combustível:" + m_TextComponent.text);

            try
            {
                playerControllerScript.ConsumeFuel(Int32.Parse(m_TextComponent.text));
            }
            catch (FormatException)
            {
                Debug.LogError($"Unable to parse '{m_TextComponent.text}'");
            }
            
        }
    }
}
