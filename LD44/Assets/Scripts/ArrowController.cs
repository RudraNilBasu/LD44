using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour {

    [SerializeField]
    GameObject go_arrow;

    [SerializeField]
    Transform arrow_inst_position;

    bool isArrowLoaded;
    Arrow currentArrow;

	// Use this for initialization
	void Start () {
		isArrowLoaded = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isArrowLoaded && currentArrow != null) {
            currentArrow.gameObject.transform.position = arrow_inst_position.position;
        }

		if (Input.GetKeyDown(KeyCode.Z)) {
            if (isArrowLoaded) {
                currentArrow.Throw();
                isArrowLoaded = false;
                currentArrow.transform.parent = null;
            } else {
                currentArrow = Instantiate(
                        go_arrow, arrow_inst_position.position, transform.rotation
                        ).GetComponent<Arrow>();
                currentArrow.gameObject.transform.parent = gameObject.transform;
                isArrowLoaded = true;

                if (transform.localScale.x < 0.0f) {
                    currentArrow.gameObject.transform.localScale =
                        Vector3.Scale(currentArrow.gameObject.transform.localScale, new Vector3(-1, 1, 1));
                }
            }
        }
	}
}
