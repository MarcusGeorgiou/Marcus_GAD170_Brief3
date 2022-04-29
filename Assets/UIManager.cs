using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    int score = 0;
    int lives = 3;

    public Text scoreText;
    public Text livesText;
    public Text gameEnd;

    private void OnEnable()
    {
        EventManager.AddScore += AddPoints;

        EventManager.OnDeath += MinusLives;

        EventManager.ShowScore += GameOver;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameEnd.text = null;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;

        if(lives == 0)
        {
            print("You are Dead");
            EventManager.RunGameEnd();
        }
    }

    void AddPoints()
    {
        score += 10;
        print("Score: " + score);
    }

    void MinusLives()
    {
        lives--;
        print("Lives: " + lives);
    }

    void GameOver()
    {
        gameEnd.text = "GAME OVER";
    }
}
