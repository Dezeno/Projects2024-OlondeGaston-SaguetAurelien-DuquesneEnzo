using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class GameManagerTests
{
    private GameManager _gameManager;
    
    [UnitySetUp]
    public IEnumerator SetUp()
    {
        SceneManager.LoadScene("Game");
        yield return null; // Wait for the scene to load
        
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    [UnityTest]
    public IEnumerator OnScoreZoneReached_IncrementsPlayersScore()
    {
        // Act
        _gameManager.OnScoreZoneReached(1);
        _gameManager.OnScoreZoneReached(2);
        
        yield return null;

        // Assert
        Assert.AreEqual(1, _gameManager.m_scorePlayer1);
        Assert.AreEqual(1, _gameManager.m_scorePlayer1);
    }

    [UnityTest]
    public IEnumerator Player1Wins()
    {
        _gameManager.m_scorePlayer1 = _gameManager.m_maxScore;
        _gameManager.CheckWin();

        yield return null;
        
        Assert.IsTrue(_gameManager.m_winnerScreen.activeSelf);
        Assert.IsFalse(_gameManager.m_background.activeSelf);
        Assert.IsFalse(_gameManager.m_entities.activeSelf);
        Assert.IsFalse(_gameManager.m_score.activeSelf);
    }
}
