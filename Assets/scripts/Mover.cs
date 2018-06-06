using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    private Rigidbody2D bolt;
    private Collider2D boltToDestroy;
    public float speed = 3;

    private float timeToDestroyd;
    private float startTime;
    public float continuityTime = 0.5f;

	// Use this for initialization
	void Start () {
        bolt = GetComponent<Rigidbody2D>();
        boltToDestroy = GetComponent<Collider2D>();

        bolt.velocity = transform.up * speed;
        startTime = Time.time;
        timeToDestroyd = startTime + continuityTime;
	}

    void Update()
    {
        if (Time.time > timeToDestroyd)
        {
            Destroy(boltToDestroy);
        }
    }

}
