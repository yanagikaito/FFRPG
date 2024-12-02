using System.Collections;
using UnityEngine;

public class Enemy : Actor
{
    public override void StartTurn()
    {
        IsTakingTurn = true;
        StartCoroutine(MoveToCenter());
    }

    private IEnumerator MoveToCenter()
    {
        yield return MoveToPosition(battlePosition);
        StartCoroutine(ChooseAction());
    }

    private IEnumerator ChooseAction()
    {
        while (!Input.GetKeyDown(KeyCode.C))
        {
            yield return null;
        }

        Debug.Log("Command accepted!");
        StartCoroutine(EndTurn());
    }

    private IEnumerator EndTurn()
    {
        yield return MoveToPosition(startingPosition);
        IsTakingTurn = false;
    }

    private IEnumerator MoveToPosition(Vector2 targetPosition)
    {
        float elapsedTime = 0;
        Vector2 startPosition = transform.position;

        while ((Vector2)transform.position != targetPosition)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
