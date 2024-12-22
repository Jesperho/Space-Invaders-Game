using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText;

    void Start()
    {
        // Initialize score display
        scoreText.text = "Score: " + score;
    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    public int GetScore()
    {
        return score;
    }
}
