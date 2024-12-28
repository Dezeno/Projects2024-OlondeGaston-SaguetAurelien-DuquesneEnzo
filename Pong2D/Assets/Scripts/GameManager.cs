using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public int m_scorePlayer1, m_scorePlayer2;
    [SerializeField] private ScoreText m_scoreTextLeft;
    [SerializeField] private ScoreText m_scoreTextRight;
    [SerializeField] private TextMeshProUGUI m_playerWin;
    [SerializeField] private TextMeshProUGUI m_points;
    public GameObject m_winnerScreen;
    public GameObject m_background;
    public GameObject m_entities;
    public GameObject m_score;
    public int m_maxScore = 10;

    /// <summary>
    /// Appelé lorsqu'une zone de score est atteinte, met à jour les scores
    /// selon l'id du joueur et vérifie si un joueur a gagné.
    /// </summary>
    /// <param name="id"></param>
    public void OnScoreZoneReached(int p_id)
    {
        if (p_id == 1)
        {
            m_scorePlayer1++;
        }
        else if (p_id == 2)
        {
            m_scorePlayer2++;
        }
        UpdateScores();
        CheckWin();
    }

    /// <summary>
    /// Met à jour les scores des joueurs.
    /// </summary>
    private void UpdateScores()
    {
        if (m_scoreTextLeft != null)
        {
            m_scoreTextLeft.SetScore(m_scorePlayer1);
        }
        else
        {
            Debug.LogError("ScoreTextLeft is not assigned in the GameManager.");
        }

        if (m_scoreTextRight != null)
        {
            m_scoreTextRight.SetScore(m_scorePlayer2);
        }
        else
        {
            Debug.LogError("ScoreTextRight is not assigned in the GameManager.");
        }
    }

    /// <summary>
    /// Vérifie si un joueur a gagné. Si c'est le cas,
    /// affiche l'écran de victoire.
    /// </summary>
    private void CheckWin()
    {
        // Vérifie si un des joueurs a atteint le score maximum
        int winnerId = m_scorePlayer1 == m_maxScore ? 1 : 
            m_scorePlayer2 == m_maxScore ? 2 : 0;

        // Si c'est le cas, c'est-à-dire si winnerId est différent de 0,
        // alors on affiche l'écran de victoire
        if (winnerId != 0)
        {
            m_playerWin.text = "Player " + winnerId + " wins!";
            m_points.text = "Score : " + m_scorePlayer1 + " - " 
                + m_scorePlayer2;

            m_winnerScreen.SetActive(true);
            m_background.SetActive(false);
            m_entities.SetActive(false);
            m_score.SetActive(false);

            Debug.Log("Player " + winnerId + " wins!");
        }
    }
}