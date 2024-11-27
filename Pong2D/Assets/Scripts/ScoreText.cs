using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void SetScore(int score)
    {
        text.text = score.ToString();
    }
}
