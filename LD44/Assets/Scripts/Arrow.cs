using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Arrow : MonoBehaviour {

    [SerializeField]
    private float arrowSpeed = 20.0f;

    private float currentArrowSpeed = 0.0f;
    private BoxCollider2D m_collider;

    Rigidbody2D rb;

    bool attached;
	// Use this for initialization
	void Start () {
	    rb = GetComponent<Rigidbody2D>();
        m_collider = GetComponent<BoxCollider2D>();
        currentArrowSpeed = 0.0f;
        attached = false;
        // Physics2D.IgnoreLayerCollision (9, 10, true);
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = Vector2.right * currentArrowSpeed * (transform.localScale.x / Mathf.Abs(transform.localScale.x));
        m_collider.enabled = (Mathf.Abs(currentArrowSpeed) == arrowSpeed);
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy") {
            coll.gameObject.SendMessage("Die");
            Destroy(gameObject);
        }

        if (coll.gameObject.layer == 8) {
            attached = true;
            gameObject.layer = 8;
            // Physics2D.IgnoreLayerCollision (9, 10, false);
            // TODO: Make it collide with player now
        }
        // if (coll.gameObject.tag == "")
    }

    public void Throw()
    {
        currentArrowSpeed = arrowSpeed;
		StartCoroutine(WaitToDie());
        // rb.velocity = Vector2.right * arrowSpeed;
        // TODO: Check if it is not collided / stuck only then destroy
        // Destroy(gameObject, 2.0f);
    }

    IEnumerator WaitToDie()
    {
        yield return new WaitForSeconds(2.0f);
        if (!attached)
            Destroy(gameObject);
    }
}
