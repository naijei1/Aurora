using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    [SerializeField] GameObject lazer;
    [SerializeField] ParticleSystem explosionEffect;
    [SerializeField] protected float speed = 30;
    [SerializeField] protected float rotationspeed = 300;
    protected float hp = 5;
    private GameObject player;
    private Rigidbody2D eRigidBody;
    private Renderer render;
    private BoxCollider2D boxcollider;
    private AudioSource explosionAudio;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        render = gameObject.GetComponent<Renderer>();
        boxcollider = gameObject.GetComponent<BoxCollider2D>();
        render.enabled = true;
        boxcollider.enabled = true;
        eRigidBody = gameObject.GetComponent<Rigidbody2D>();
        explosionAudio = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        movement();
    }

    protected virtual void movement()
    {
        Vector2 movementDirection = player.transform.position - transform.position;
        float angle = (Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg);
        Quaternion turn = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, turn, Time.deltaTime * rotationspeed);
        eRigidBody.AddForce((movementDirection).normalized * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PLazer"))
        {
            float dmg = collision.GetComponent<LazerClass>().damage;
            hp -= dmg;
            collision.gameObject.SetActive(false);
            if(hp <= 0)
            {
                destoryself();
            }
        }
    }

    void destoryself()
    {
        Debug.Log("dead");
        render.enabled = false;
        boxcollider.enabled = false;
        explosionAudio.Play();
        Instantiate(explosionEffect, transform.position, explosionEffect.transform.rotation);
        Destroy(gameObject, explosionAudio.clip.length);
    }
}
