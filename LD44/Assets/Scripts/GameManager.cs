﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    Fading fading;

    [SerializeField]
    GameObject playerLeftUI, playerLeftText, foodUI, foodText, background;

    Text player_text, food_text;

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

        fading = GetComponent<Fading>();

        GameManager.PlayerDead = false;

        // Set all UI false
        playerLeftUI.SetActive(false);
        playerLeftText.SetActive(false);
        foodUI.SetActive(false);
        foodText.SetActive(false);
        background.SetActive(false);

        player_text = playerLeftText.GetComponent<Text>();
        food_text = foodText.GetComponent<Text>();
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
            fading.BeginFade(1);
            player_controller.enabled = false;
            player_motor.enabled = false;
            player_sprite.enabled = false;
            player_collider.enabled = false;
            player_rb.isKinematic = true;
            player_rb.velocity = Vector3.zero;
            // go_player.SetActive(false);
            
            StartCoroutine(ShowUI());
        }
    }

    IEnumerator ShowUI()
    {
        yield return new WaitForSeconds(0.5f);
        food_text.text = " x " + go_player.GetComponent<PlayerManager>().GetFoodCount().ToString();
        // Set all UI true
        playerLeftUI.SetActive(true);
        playerLeftText.SetActive(true);
        foodUI.SetActive(true);
        foodText.SetActive(true);
        background.SetActive(true);
        fading.BeginFade(-1);
    }

    IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(1.0f);

        fading.BeginFade(1);

        yield return new WaitForSeconds(1.0f);

        go_player.transform.position = startPos.position; // TODO: Some more animations and all that
        player_controller.enabled = true;
        player_motor.enabled = true;
        player_sprite.enabled = true;
        player_collider.enabled = true;
        player_rb.isKinematic = false;

        GameManager.PlayerDead = false;

        yield return new WaitForSeconds(0.2f);
        fading.BeginFade(-1);
    }

    public void CollectFood()
    {
        print("Food Collected");
    }
}
