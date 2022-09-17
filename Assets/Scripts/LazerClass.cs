using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerClass : MonoBehaviour
{
    protected float speed = 50;
    public float damage = 3;
    [SerializeField] private float outOfBoundx = 30;
    [SerializeField] private float outOfBoundy = 15;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        checkIfOutOfBound();
    }

    void checkIfOutOfBound()
    {
        //checks out of bounds for x axis
        if(transform.position.x < -outOfBoundx || transform.position.x > outOfBoundx)
        {
            gameObject.SetActive(false);
        }
        // checks out of bounds for y axis
        if(transform.position.y < -outOfBoundy || transform.position.y > outOfBoundy)
        {
            gameObject.SetActive(false);
        }
    }
}
