using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText; 
    public TMP_Text Kills;
    private int kills=0;
    private int score = 0;
   public PlayerMovement playerMovement;

    private void Start()
    {
        UpdateScoreText();
        UpdateKillText();
    }

    public void IncrementScore()
    {
        score++;
        UpdateScoreText();
        playerMovement.playerSpeed+=playerMovement.speedIncrease;
    }
    public void IncrementKills()
    {
        kills++;
        UpdateKillText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
        else
        {
            Debug.LogWarning("Score text not assigned.");
        }
    }
    void UpdateKillText()
    {
        if (Kills != null)
        {
            Kills.text = "Kills: " + kills.ToString();
        }
        else
        {
            Debug.LogWarning("Kill text not assigned.");
        }
    }
}
