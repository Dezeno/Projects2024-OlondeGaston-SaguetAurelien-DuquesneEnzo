using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControllerTests
{
    private PlayerController _playerController;
    private GameObject _player1;

    [SetUp]
    public void SetUp()
    {
        // Create a GameObject and attach PlayerController to it
        GameObject gameObject = new GameObject();
        _playerController = gameObject.AddComponent<PlayerController>();
        _player1 = GameObject.Find("Player1");
        
        // Set the id to 1  
        _playerController.id = 1;
    }

    [Test]
    public void ShouldMoveUp()
    {
        float positionBefore = _player1.transform.position.y;
        _playerController.Move(1f);
        Assert.Greater(_player1.transform.position.y, positionBefore);
    }
}
