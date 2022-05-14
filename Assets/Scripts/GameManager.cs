using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Singleton that is in charge of maintaining the game state. 
///
///  @Author Stephan Guingor
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;
    
    public int penalty = 100;

    public int award = 100;

    public GameObject gameOver;
    
    private int _hits = 0;

    private int _score;

    private bool _run = true;

    public TextMeshProUGUI scoreText;
    
    /// <summary>
    /// Creates the singleton if not exists, else destroy instance
    /// </summary>
    void Start()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
        }
        else
        {
            Destroy(this);
        }
    }
    
    /// <summary>
    /// Update score text
    /// </summary>
    private void UpdateScore()
    {
        scoreText.text = "Score: " + _score;
    }
    
    /// <summary>
    /// Adds score and updates score text
    /// </summary>
    public void AddScore()
    {
        if (!_run) return;
        _score += award;

        UpdateScore();
        
        // Player Wins at 1000 score
        if (_score > 1000)
        {
            gameOver.SetActive(true);
            _run = false;
        }
    }
    
    /// <summary>
    /// Adds penalty and update score text
    /// </summary>
    public void AddScorePenalty()
    {
        if (!_run) return;
        _score -= penalty;
        _hits++;
        UpdateScore();

        // End of games too many hits
        if (_hits > 10)
        {
            gameOver.SetActive(true);
            _run = false; 
        }
    }
}
