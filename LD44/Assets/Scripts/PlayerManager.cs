using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    [SerializeField]
    GameObject GM;

    bool lookingRight;
	// Use this for initialization
	void Start () {
		lookingRight = true;
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

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy") {
            GM.SendMessage("DeathSequence", transform);
            // gameObject.SetActive(false);
        }
    }
}
