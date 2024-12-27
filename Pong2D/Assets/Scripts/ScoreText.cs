using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI m_text;

    /// <summary>
    /// Met à jour le score affiché.
    /// </summary>
    /// <param name="p_score">valeur du score</param>
    public void SetScore(int p_score)
    {
        m_text.text = p_score.ToString();
    }
}