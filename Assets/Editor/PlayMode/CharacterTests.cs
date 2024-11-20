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
        Vector2Int current = sut.CurrentCell;
        sut.Move.TryMove(Direction.Left);
        yield return new WaitForSeconds(.5f);
        Assert.AreEqual(current + Direction.Left, sut.CurrentCell);

        // Moving Right
        current = sut.CurrentCell;
        sut.Move.TryMove(Direction.Right);
        yield return new WaitForSeconds(.5f);
        Assert.AreEqual(current + Direction.Right, sut.CurrentCell);

        // Moving Down
        current = sut.CurrentCell;
        sut.Move.TryMove(Direction.Down);
        yield return new WaitForSeconds(.5f);
        Assert.AreEqual(current + Direction.Down, sut.CurrentCell);

        // Moving Up
        current = sut.CurrentCell;
        sut.Move.TryMove(Direction.Up);
        yield return new WaitForSeconds(.5f);
        Assert.AreEqual(current + Direction.Up, sut.CurrentCell);
    }

    [UnityTest]
    public IEnumerator Character_facing_updates_correctly()
    {
        while (!isReady) yield return null;

        sut.Turn.Turn(Direction.Down);
        Assert.AreEqual(Direction.Down, sut.Facing);
        yield return new WaitForSeconds(.5f);

        sut.Turn.Turn(Direction.Left);
        Assert.AreEqual(Direction.Left, sut.Facing);
        yield return new WaitForSeconds(.5f);

        sut.Turn.Turn(Direction.Right);
        Assert.AreEqual(Direction.Right, sut.Facing);
        yield return new WaitForSeconds(.5f);

        sut.Turn.Turn(Direction.Up);
        Assert.AreEqual(Direction.Up, sut.Facing);
    }

    [UnityTest]
    public IEnumerator Updates_cell_map_dictionary()
    {
        while (!isReady) yield return null;

        Vector2Int originalCell = sut.CurrentCell;

        Assert.IsTrue(Game.Map.OccupiedCells.ContainsKey(originalCell));
        Assert.AreEqual(sut, Game.Map.OccupiedCells[originalCell]);

        sut.Move.TryMove(Direction.Left);
        yield return new WaitForSeconds(.5f);

        Assert.IsTrue(Game.Map.OccupiedCells.ContainsKey(sut.CurrentCell));
        Assert.IsFalse(Game.Map.OccupiedCells.ContainsKey(originalCell));
        Assert.AreEqual(sut, Game.Map.OccupiedCells[sut.CurrentCell]);
    }
}
