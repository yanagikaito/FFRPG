using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    [SerializeField] private List<Actor> TurnOrder = new List<Actor>();
    [SerializeField] private int turnNumber = 0;

    private void Update()
    {
        if (TurnOrder[turnNumber].IsTakingTurn)
            return;

        else
        {
            CheckForEnd();
            GoToNextTurn();
        }
    }

    private void CheckForEnd()
    {

    }

    private void GoToNextTurn()
    {
        turnNumber = (turnNumber + 1) % TurnOrder.Count;
        TurnOrder[turnNumber].StartTurn();
    }
}
