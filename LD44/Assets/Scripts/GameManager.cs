using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    GameObject go_zombie, go_player;

    [SerializeField]
	Transform startPos;

    int totalLives;
    // Use this for initialization
	void Start () {
		totalLives = 3;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DeathSequence(Transform currentPlayerPosition)
    {
        totalLives--;
        if (totalLives >= 0) {
            Instantiate(go_zombie, currentPlayerPosition.position, Quaternion.identity);
            go_player.transform.position = startPos.position; // TODO: Some more animations and all that
            // TODO: UI: Show that a player died
        } else {
            print("Game Over");
            go_player.SetActive(false);
        }
    }

    public void CollectFood()
    {
        print("Food Collected");
    }
}
