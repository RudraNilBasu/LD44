using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    GameObject go_zombie, go_player;

    [SerializeField]
	Transform startPos;

    SpriteRenderer player_sprite;
    PlayerMotor player_motor;
    PlayerController player_controller;
    BoxCollider2D player_collider;
    Rigidbody2D player_rb;

    public static bool PlayerDead;

    int totalLives;
    // Use this for initialization
	void Start () {
		totalLives = 3;
        player_controller = go_player.GetComponent<PlayerController>();
        player_motor = go_player.GetComponent<PlayerMotor>();
        player_sprite = go_player.GetComponent<SpriteRenderer>();
        player_collider = go_player.GetComponent<BoxCollider2D>();
        player_rb = go_player.GetComponent<Rigidbody2D>();

        GameManager.PlayerDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DeathSequence(Transform currentPlayerPosition)
    {
        totalLives--;
        if (totalLives >= 0) {
            Instantiate(go_zombie, currentPlayerPosition.position, Quaternion.identity);

            GameManager.PlayerDead = true;

            player_controller.enabled = false;
            player_motor.enabled = false;
            player_sprite.enabled = false;
            player_collider.enabled = false;
            player_rb.isKinematic = true;
            player_rb.velocity = Vector3.zero;

            StartCoroutine(RespawnPlayer());
            // TODO: UI: Show that a player died
        } else {
            print("Game Over");
            go_player.SetActive(false);
        }
    }

    IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(1.0f);
        go_player.transform.position = startPos.position; // TODO: Some more animations and all that
        player_controller.enabled = true;
        player_motor.enabled = true;
        player_sprite.enabled = true;
        player_collider.enabled = true;
        player_rb.isKinematic = false;

        GameManager.PlayerDead = false;

    }

    public void CollectFood()
    {
        print("Food Collected");
    }
}
