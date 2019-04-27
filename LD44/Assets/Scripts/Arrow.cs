using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Arrow : MonoBehaviour {

    [SerializeField]
    private float arrowSpeed = 20.0f;

    private float currentArrowSpeed = 0.0f;

    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
	    rb = GetComponent<Rigidbody2D>();
        currentArrowSpeed = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = Vector2.right * currentArrowSpeed;
	}

    public void Throw()
    {
        currentArrowSpeed = arrowSpeed;
        // rb.velocity = Vector2.right * arrowSpeed;
        Destroy(gameObject, 2.0f);
    }
}
