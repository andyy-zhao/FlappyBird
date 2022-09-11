using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    // speed variable and update function we move the position of our object
    public float speed = 5f;
    private float leftEdge; // represents left edge of our screen

    private void Start()
    {
        // convert screen space coordinates to world space coordinates
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }
    
    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < leftEdge) {
            Destroy(gameObject);
        }
    }
}
