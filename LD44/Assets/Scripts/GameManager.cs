using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    GameObject go_zombie, go_player;

    [SerializeField]
	Transform startPos;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DeathSequence(Transform currentPlayerPosition)
    {
        Instantiate(go_zombie, currentPlayerPosition.position, Quaternion.identity);
        go_player.transform.position = startPos.position; // TODO: Some more animations and all that
        // TODO: UI: Show that a player died
    }
}
