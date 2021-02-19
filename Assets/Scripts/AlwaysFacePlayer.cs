using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysFacePlayer : MonoBehaviour
{
    //Camera cameraToLookAt;
    public GameObject GameObjectToFace;

    // Use this for initialization 
    void Start()
    {
        //cameraToLookAt = Camera.main;
    }

    // Update is called once per frame 
    void LateUpdate()
    {
        transform.LookAt(GameObjectToFace.transform);
        //transform.rotation = Quaternion.LookRotation(GameObjectToFace.transform.forward);
    }
}
