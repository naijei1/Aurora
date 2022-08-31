using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    [SerializeField] GameObject lazer;
    [SerializeField] protected float speed = 30;
    [SerializeField] protected float rotationspeed = 300;
    private GameObject player;
    private Rigidbody2D eRigidBody;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        eRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement();
    }

    protected virtual void movement()
    {
        Vector2 movementDirection = player.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, rotationspeed * Time.deltaTime);
        eRigidBody.AddForce((movementDirection).normalized * speed);
    }
}
