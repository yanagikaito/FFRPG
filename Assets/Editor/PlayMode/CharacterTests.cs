using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class CharacterTests
{
    private bool isReady = false;
    private PlayerController sut;

    [OneTimeSetUp]
    public void LoadTestScene()
    {
        SceneManager.LoadScene(0);
        SceneManager.sceneLoaded += SceneReady;
    }

    public void SceneReady(Scene scene, LoadSceneMode mode)
    {
        sut = GameObject.FindObjectOfType<PlayerController>();
        isReady = true;
    }
    [UnityTest]
    public IEnumerator Moves_to_the_correct_cell()
    {
        while (!isReady) yield return null;

        // Moving Left
        // Arrange
        Vector2Int current = sut.CurrentCell;

        // Act
        sut.Move.TryMove(Direction.Left);
        yield return new WaitForSeconds(2);

        // Assert
        Assert.AreEqual(current + Direction.Left, sut.CurrentCell);

        // Moving Right
        // Arrange
        current = sut.CurrentCell;

        // Act
        sut.Move.TryMove(Direction.Right);
        yield return new WaitForSeconds(2);

        // Assert
        Assert.AreEqual(current + Direction.Right, sut.CurrentCell);

        // Moving Down
        // Arrange
        current = sut.CurrentCell;

        // Act
        sut.Move.TryMove(Direction.Down);
        yield return new WaitForSeconds(2);

        // Assert
        Assert.AreEqual(current + Direction.Down, sut.CurrentCell);

        // Moving Up
        // Arrange
        current = sut.CurrentCell;

        // Act
        sut.Move.TryMove(Direction.Up);
        yield return new WaitForSeconds(2);

        // Assert
        Assert.AreEqual(current + Direction.Up, sut.CurrentCell);
    }
}
