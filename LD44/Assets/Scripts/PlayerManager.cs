using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(PlayerMotor))]
public class PlayerManager : MonoBehaviour {

    [SerializeField]
    GameObject GM;

    PlayerController m_controller;
    PlayerMotor m_motor;

    Rigidbody2D rb;

    int foodCollected;

    bool lookingRight;

	// Use this for initialization
	void Start () {
		lookingRight = true;
        foodCollected = 0;

        rb = gameObject.GetComponent<Rigidbody2D>();

        m_controller = GetComponent<PlayerController>();
        m_motor = GetComponent<PlayerMotor>();

        m_motor.enabled = true;
        m_controller.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw("Horizontal") == 1) {
            // player should look right
            transform.localScale = new Vector3(
                    Mathf.Abs(transform.localScale.x),
                    transform.localScale.y,
                    transform.localScale.z
                    );
        }
		if (Input.GetAxisRaw("Horizontal") == -1) {
            // player should look left
            transform.localScale = new Vector3(
                    Mathf.Abs(transform.localScale.x) * -1,
                    transform.localScale.y,
                    transform.localScale.z
                    );
        }
	}

    void OnTriggerStay2D(Collider2D coll)
    {
        print("Here: " + coll.gameObject.name);
        if (coll.gameObject.name == "HEAD") {
            transform.parent = coll.transform;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.collider.gameObject.name == "HEAD") {
            transform.parent = null;
            rb.bodyType = RigidbodyType2D.Dynamic;
            // rb.simulated = true;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy" && coll.collider.gameObject.name != "HEAD") {
            GM.SendMessage("DeathSequence", transform);
            // gameObject.SetActive(false);
        }

        if (coll.gameObject.tag == "Spikes") {
            GM.SendMessage("DeathSequence", transform);
        }

        if (coll.collider.gameObject.name == "HEAD") {
            transform.parent = coll.collider.transform;
            // rb.simulated = false;
            rb.bodyType = RigidbodyType2D.Kinematic; // TODO: unset this on button press
        }

        if (coll.gameObject.tag == "Collectable") {
            Destroy(coll.gameObject);
            foodCollected++;
        }
    }
}
