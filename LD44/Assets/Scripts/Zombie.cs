using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Zombie : MonoBehaviour {

    [SerializeField]
    LayerMask layers;

    [SerializeField]
    Transform strollCheckLeft, strollCheckRight;

    [SerializeField]
    GameObject go_food;
    
    Rigidbody2D rb;
    SpriteRenderer m_renderer;
    int multiplier = -1;

    float m_Speed = 1.0f;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
        m_renderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		// rb.velocity = transform.right * m_Speed * multiplier;
		rb.velocity = new Vector3(0.0f, rb.velocity.y, 0.0f) + (transform.right * m_Speed * multiplier);
        RaycastHit2D hitLeft = Physics2D.Raycast(strollCheckLeft.position, -Vector2.up, 500, layers);
        RaycastHit2D hitRight = Physics2D.Raycast(strollCheckRight.position, -Vector2.up, 500, layers);

        if (hitLeft.collider == null || hitLeft.distance > 0.9f || hitLeft.distance == 0.0f) {
            multiplier = 1;
            m_renderer.flipX = true;
        }
        if (hitRight.collider == null || hitRight.distance > 0.9f || hitRight.distance == 0.0f) {
            multiplier = -1;
            m_renderer.flipX = false;
        }
	}

    public void Die()
    {
        Instantiate(go_food, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
