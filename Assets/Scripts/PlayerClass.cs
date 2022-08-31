using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour
{
    protected float xOuTOfBound;
    protected float yOutOfBound;
    protected float speed = 5;
    protected float speedcap = 10;
    private Rigidbody2D pRigidbody;
    private float xMovement;
    private float yMovement;
    private float xMovementCap;
    private float yMovementCap;
    private Vector2 directionToMove;
    private void Start()
    {
        pRigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Movement();
        SpeedCap();
    }

    void Movement()
    {
        xMovement = Input.GetAxis("Horizontal");
        yMovement = Input.GetAxis("Vertical");
        directionToMove = new Vector2(xMovement, yMovement);
        pRigidbody.AddForce(directionToMove * speed);
    }

    void SpeedCap()
    {
        xMovementCap = Mathf.Clamp(pRigidbody.velocity.x, -speedcap, speedcap);
        yMovementCap = Mathf.Clamp(pRigidbody.velocity.y, -speedcap, speedcap);    

        pRigidbody.velocity = new Vector3(xMovementCap, yMovementCap);
        //Check velocity if needed Debug.Log(pRigidbody.velocity);
    }
}
