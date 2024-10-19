using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// StationaryNPCクラス：Characterクラスを継承し、Interactableインターフェースを実装
public class StationaryNPC : Character, Interactable
{
    // interactionフィールドをSerializeField属性で公開
    [SerializeField] private Interaction interaction;

    // interactionプロパティ：interactionフィールドを公開
    public Interaction Interaction => interaction;

    // Interactメソッド：InteractionのStartInteractionメソッドを呼び出す
    public void Interact()
    {
        Interaction.StartInteraction();
    }
}