using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PartyMemberInfo : MonoBehaviour
{
    private PartyMember partyMember;

    [SerializeField] private Image partyMemberImagePortrait;
    [SerializeField] private TextMeshProUGUI memberName;
    [SerializeField] private TextMeshProUGUI memberLevelJob;
    [SerializeField] private TextMeshProUGUI memberHP;
    [SerializeField] private TextMeshProUGUI memberSpecial;
    [SerializeField] private TextMeshProUGUI memberBaseSTR;
    [SerializeField] private TextMeshProUGUI memberBaseARM;
    [SerializeField] private TextMeshProUGUI memberBaseSPD;
    [SerializeField] private TextMeshProUGUI memberEquipSTR;
    [SerializeField] private TextMeshProUGUI memberEquipARM;
    [SerializeField] private TextMeshProUGUI memberEquipSPD;

    void Start()
    {
        partyMember = Party.ActiveMembers[0];
        memberName.text = partyMember.Name;
        partyMemberImagePortrait = partyMember.Portrait;
        GetStats();
    }

    public void GetStats()
    {
        string levelJob = $"Level {partyMember.Status.LEVEL} {partyMember.Job}";
        memberLevelJob.text = levelJob;

        memberHP.text = $"HP {partyMember.Status.HP}";
        memberSpecial.text = "MP 0:0";
        memberBaseSTR.text = partyMember.Status.STR.ToString();
        memberBaseARM.text = partyMember.Status.ARM.ToString();
        memberBaseSPD.text = partyMember.Status.SPD.ToString();
        memberEquipSTR.text = partyMember.Status.STR.ToString();
        memberEquipARM.text = partyMember.Status.ARM.ToString();
        memberEquipSPD.text = partyMember.Status.SPD.ToString();
    }
}
