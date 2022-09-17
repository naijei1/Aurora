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
    protected AudioSource lazerFire;
    private float xMovement;
    private float yMovement;
    private float xMovementCap;
    private float yMovementCap;
    private Vector2 directionToMove;
    [SerializeField] protected GameObject lazer;
    private void Start()
    {
        pRigidbody = GetComponent<Rigidbody2D>();
        lazerFire = gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
        Movement();
        SpeedCap();
        faceMouse();
        fire();
        
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

    protected virtual void fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ObjectPooler.Instance.spawnFromPool("Plazer", transform.position, transform.rotation);
            lazerFire.Play();
        }
    }

    void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
            );

        transform.right = direction;
    }
}
