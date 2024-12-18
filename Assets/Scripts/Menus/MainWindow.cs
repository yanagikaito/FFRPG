using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWindow : MonoBehaviour
{
    [SerializeField] private GameObject partyMemberInfoPrefab;
    void Start()
    {
        //GeneratePartyMemberInfo();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("test");
            Instantiate(partyMemberInfoPrefab, this.gameObject.transform);
        }
    }

    private void GeneratePartyMemberInfo()
    {

    }
}
