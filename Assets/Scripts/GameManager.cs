using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI statusText;
    public float timeLimit = 60f;

    private float _timeRemaining;
    private bool _gameOver = false;

    void Awake()
    {
        if (Instance) Destroy(gameObject);
        Instance = this;
    }

    void Start()
    {
        _timeRemaining = timeLimit;
        StartCoroutine(ShowInstructions());
    }

    IEnumerator ShowInstructions()
    {
        statusText.text = "Finally. I'm back. I always said I would be. There's something on that table. Let me read it before I go in.";
        yield return new WaitForSeconds(5f);
        statusText.text = "";
    }

    void Update()
    {
        if (_gameOver) return;

        _timeRemaining -= Time.deltaTime;
        if (timerText != null)
            timerText.text = "Time: " + Mathf.CeilToInt(_timeRemaining);

        if (_timeRemaining <= 0)
            LoseGame();
    }

    public void WinGame()
    {
        _gameOver = true;
        if (statusText != null)
            statusText.text = "YOU ESCAPED!";
    }

    void LoseGame()
    {
        _gameOver = true;
        if (statusText != null)
            statusText.text = "TIME'S UP!";
    }
}