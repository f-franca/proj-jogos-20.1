using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public CharacterController characterController;
    public float turnSpeed = 6f;
    public float speed = 6f;
    

    private bool canPlayerMove = true;
    private int fuel = 50;
    private int totalFuelConsumed = 0;

    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        if (verticalMove < 0)
            horizontalMove = horizontalMove * (-1);

        // Calculate the Direction to Move based on the tranform of the Player
        Vector3 moveDirectionForward = transform.forward * verticalMove;
        //Vector3 moveDirectionSide = transform.right * horizontalMove;
        Vector3 moveDirectionSide = Vector3.zero;

        //find the direction
        Vector3 direction = (moveDirectionForward + moveDirectionSide).normalized;
        //find the distance
        Vector3 distance = direction * speed * Time.deltaTime;

        // Apply Movement to Player

        if (canPlayerMove)
        {
            distance.y = -10;
            characterController.Move(distance);
            

            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalMove);
            
            /* WORKING MOVEMENT
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalMove);
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalMove);
            * END OF WORKING MOVEMENTE
            */
        }

        if (transform.position.y < -1.0)
        {
            FindObjectOfType<GameController>().EndGame();
        }
    }

    public void ConsumeFuel(int amount)
    {
        this.fuel -= amount;
        this.totalFuelConsumed += amount;
        //Debug.Log($"Fuel consumed: {amount}, total fuel left: {this.fuel}");
    }

    public int GetFuel()
    {
        return this.fuel;
    }

    public int GetTotalCost()
    {
        return this.totalFuelConsumed;
    }
}
