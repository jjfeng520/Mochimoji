﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour {
    private int coinCount;
    private string[] Lines;

    public Text scoreText;

    // Audio triggers.
    public AudioClip coinSound;
    private AudioSource source;


    private void Awake()
    {
        // Get audio clip.
        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        coinCount = 0;
        SetScoreText();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            collision.gameObject.SetActive(false);
            coinCount += 5;
            SetScoreText();

            // Add audio when player collects coin.
            source.PlayOneShot(coinSound);
        }
    }

    void SetScoreText()
    {
        scoreText.text = "SCORE: " + coinCount.ToString();

        // Save score to player preferences.
        PlayerPrefs.SetInt("Player Score", coinCount);

        // Save score to user's account file.
        string loggedUsername = PlayerPrefs.GetString("LoggedUser");
        Lines = System.IO.File.ReadAllLines(@"C:/Users/Jennifer/Documents/CodingDojo/UnityTestDbFolder_Mochimoji/" + loggedUsername + ".txt");

        // Save highest score to player preferences.
        if (PlayerPrefs.HasKey("Highest Score"))
        {
            int highestScore = PlayerPrefs.GetInt("Highest Score");
            if (highestScore < coinCount)
            {
                PlayerPrefs.SetInt("Highest Score", coinCount);
            }
        }
        else
        {
            PlayerPrefs.SetInt("Highest Score", coinCount);
        }
    }
}
