using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour
{
    protected float speed = 5;
    [SerializeField] protected float speedcap = 10;
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
        xMovementCap = Mathf.Min(Mathf.Abs(pRigidbody.velocity.x), speedcap) * Mathf.Sign(pRigidbody.velocity.x);
        yMovementCap = Mathf.Min(Mathf.Abs(pRigidbody.velocity.y), speedcap) * Mathf.Sign(pRigidbody.velocity.y);

        pRigidbody.velocity = new Vector3(xMovementCap, yMovementCap);
        Debug.Log(pRigidbody.velocity);
    }
}
