using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : Actor
{
    public override void StartTurn()
    {
        IsTakingTurn = true;
        StartCoroutine(Co_MoveToCenter());
    }

    private IEnumerator Co_MoveToCenter()
    {
        float elapsedTime = 0;

        while ((Vector2)transform.position != battlePosition)
        {
            transform.position = Vector2.Lerp(startingPosition, battlePosition, elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
