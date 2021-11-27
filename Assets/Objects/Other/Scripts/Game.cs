using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [Space]
    [Header("Objects")]
    [SerializeField] private Bird _bird;
    [SerializeField] private PipesSpawner _pipesSpawner;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private void OnEnable()
    {
        _startScreen.StartButtonClick += OnStartButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _bird.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.StartButtonClick -= OnStartButtonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _bird.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;

        _startScreen.Open();
        _gameOverScreen.Close();
    }

    private void OnStartButtonClick()
    {
        _startScreen.Close();

        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _gameOverScreen.Close();
        _pipesSpawner.Reset();

        StartGame();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;

        _gameOverScreen.Open();
    }

    private void StartGame()
    {
        Time.timeScale = 1;

        _bird.Reset();
    }
}
