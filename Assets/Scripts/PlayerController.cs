using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public CharacterController characterController;
    public float turnSpeed = 6f;
    public float speed = 6f;

    private bool canPlayerMove = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        /*
        Vector3 move = transform.forward * verticalMove + transform.right * horizontalMove;
        characterController.Move(speed * Time.deltaTime * move);
        */

        if (canPlayerMove)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalMove);
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalMove);
        }
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalMove);
    }
}
