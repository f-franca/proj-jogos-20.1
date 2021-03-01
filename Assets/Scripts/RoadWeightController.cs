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

    public GameObject GameObjectToFace;
    public GameObject pesoGameObject;
    float initialFontSize;
    // Start is called before the first frame update
    void Start()
    {
        m_TextComponent = weightText.GetComponent<TMP_Text>();
        pesoGameObject = this.gameObject.transform.Find("Peso").gameObject;
        initialFontSize = pesoGameObject.GetComponent<TextMeshPro>().fontSize;
        //m_TextComponent.text = "Some new line of text.";
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObjectToFace.transform.position.y > 280f)
        {

            Vector3 rotation = Quaternion.LookRotation(GameObjectToFace.transform.forward).eulerAngles;
            rotation.y = transform.rotation.y;
            rotation.z = transform.rotation.z;
            pesoGameObject.transform.rotation = Quaternion.Euler(rotation);
            //pesoGameObject.transform.position = new Vector3(pesoGameObject.transform.position.x, 100f, pesoGameObject.transform.position.z);
            pesoGameObject.GetComponent<TextMeshPro>().fontSize = 100;
        }
        else
        {
            pesoGameObject.GetComponent<TextMeshPro>().fontSize = initialFontSize;
            Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Vector3 rotation = Quaternion.LookRotation(GameObjectToFace.transform.forward).eulerAngles;
            rotation.x = transform.rotation.x;
            rotation.z = transform.rotation.z;
            pesoGameObject.transform.rotation = Quaternion.Euler(rotation);
            pesoGameObject.transform.position = targetPosition;
        }
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
