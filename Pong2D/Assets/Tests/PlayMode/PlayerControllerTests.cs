using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayerControllerTests
{
    private PlayerController _playerController;
    private GameObject _player1;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        SceneManager.LoadScene("Game");
        yield return null; // Wait for the scene to load
        
        // Create a GameObject and get the PlayerController component attached to it
        _player1 = GameObject.Find("Player1");
        _playerController = _player1.GetComponent(typeof(PlayerController)) as PlayerController;
    }

    [UnityTest]
    public IEnumerator ShouldMoveUp()
    {
        float positionBefore = _playerController.m_rd2d.position.y;
        _playerController.Move(5f);
        
        yield return new WaitForSeconds(2);
        
        Debug.Log("before : " + positionBefore);
        Debug.Log("player : " + _playerController.m_rd2d.position.y);
        Assert.Greater(_playerController.m_rd2d.position.y, positionBefore);
    }
}