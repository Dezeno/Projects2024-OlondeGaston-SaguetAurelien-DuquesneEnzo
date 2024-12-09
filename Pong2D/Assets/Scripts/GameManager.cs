using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public int scorePlayer1, scorePlayer2;
    [SerializeField] private ScoreText scoreTextLeft;
    [SerializeField] private ScoreText scoreTextRight;
    [SerializeField] private TextMeshProUGUI playerWin;
    [SerializeField] private TextMeshProUGUI points;
    public GameObject winnerScreen;
    public GameObject background;
    public GameObject entities;
    public GameObject score;
    public int maxScore = 10;

    public void OnScoreZoneReached(int id)
    {
        if (id == 1)
        {
            scorePlayer1++;
        }
        else if (id == 2)
        {
            scorePlayer2++;
        }
        UpdateScores();
        CheckWin();
    }

    private void UpdateScores()
    {
        if (scoreTextLeft != null)
        {
            scoreTextLeft.SetScore(scorePlayer1);
        }
        else
        {
            Debug.LogError("ScoreTextLeft is not assigned in the GameManager.");
        }

        if (scoreTextRight != null)
        {
            scoreTextRight.SetScore(scorePlayer2);
        }
        else
        {
            Debug.LogError("ScoreTextRight is not assigned in the GameManager.");
        }
    }

    private void CheckWin()
    {
        int winnerId = scorePlayer1 == maxScore ? 1 : scorePlayer2 == maxScore ? 2 : 0;

        if (winnerId != 0)
        {
            playerWin.text = "Player " + winnerId + " wins!";
            points.text = "Score : " + scorePlayer1 + " - " + scorePlayer2;

            winnerScreen.SetActive(true);
            background.SetActive(false);
            entities.SetActive(false);
            score.SetActive(false);

            Debug.Log("Player " + winnerId + " wins!");
        }
    }
}