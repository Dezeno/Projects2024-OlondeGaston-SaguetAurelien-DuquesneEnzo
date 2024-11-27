using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int scorePlayer1, scorePlayer2;
    [SerializeField] private ScoreText ScoreTextLeft;
    [SerializeField] private ScoreText ScoreTextRight;
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
        if (ScoreTextLeft != null)
        {
            ScoreTextLeft.SetScore(scorePlayer1);
        }
        else
        {
            Debug.LogError("ScoreTextLeft is not assigned in the GameManager.");
        }

        if (ScoreTextRight != null)
        {
            ScoreTextRight.SetScore(scorePlayer2);
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
            Debug.Log("Player " + winnerId + " wins!");
            SceneManager.LoadScene("WinnerScreen");
        }
    }

}
