﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class GameSession : MonoBehaviour
{
    // config params 
    [Range(0.1f,10f)][SerializeField] private float gameSpeed = 1f;

    [SerializeField] private int pointsPerBlockDestroyed = 83;
    // state variables
    [SerializeField] private int currentScore = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private bool autoPlayEnabled;
    
    // Update is called once per frame
    private void Awake()
    {
        int gameStateCount = FindObjectsOfType<GameSession>().Length;
        if (gameStateCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void IncreaseScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGameScore()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled() {
        return autoPlayEnabled;
    }
}
