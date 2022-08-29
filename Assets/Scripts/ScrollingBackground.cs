using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    private Vector2 startPos;
    private float endPos;
    private BoxCollider size;
    private float speed = 10;
    void Start()
    {
        startPos = transform.position;
        size = GetComponent<BoxCollider>();
        endPos = size.size.x * 11;
        Debug.Log(endPos);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x < startPos.x - endPos)
        {
            transform.position = startPos;
        }
    }
}
