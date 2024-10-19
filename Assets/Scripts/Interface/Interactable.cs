using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Interactable
{
    Interaction Interaction { get; }
    void Interact();
}
