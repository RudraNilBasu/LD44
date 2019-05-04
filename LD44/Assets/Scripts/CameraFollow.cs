using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    Transform target;

    float multiplier = 10.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(
                Mathf.Lerp(transform.position.x, target.position.x, multiplier * Time.deltaTime),
                Mathf.Lerp(transform.position.y, target.position.y, multiplier * Time.deltaTime), -10);
	}
}
