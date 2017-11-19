using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpScript : MonoBehaviour
{
    public Text triggeredText;
    public GameObject[] randomEmojis;
    private GameObject selectedEmoji;

    // Audio triggers.
    public AudioClip powerUpSound;
    private AudioSource source;

    private void Awake()
    {
        // Get audio clip.
        source = GetComponent<AudioSource>();
    }

    public void Start()
    {
        selectedEmoji = randomEmojis[UnityEngine.Random.Range(0, 6)];
    }


    // If Player collides with PowerUp, then text will be triggered.
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            triggeredText.gameObject.SetActive(true);
            selectedEmoji.gameObject.SetActive(true);

            // Add audio when player collects coin.
            source.PlayOneShot(powerUpSound);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            triggeredText.gameObject.SetActive(true);
            selectedEmoji.gameObject.SetActive(true);

            //// If Player presses "x", it will load the Game Over scene.
            //if (Input.GetKeyDown(KeyCode.X))
            //{
            //    // Bring up webcam here.
            //}
        }
    }

    // If Player moves away from Object, then text will disappear.
    void OnTriggerExit2D(Collider2D collision)
    {
        triggeredText.gameObject.SetActive(false);
        selectedEmoji.gameObject.SetActive(false);
    }
}
