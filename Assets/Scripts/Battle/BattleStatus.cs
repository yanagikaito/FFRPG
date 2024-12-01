using System;
using UnityEngine;

[System.Serializable]
public class BattleStatus
{
    private const int MAXIMUNM_POSSIBLE_HP = 999;
    private const int MAXIMUNM_POSSIBLE_STR = 99;
    private const int MAXIMUNM_POSSIBLE_ARM = 99;
    private const int MAXIMUNM_POSSIBLE_SPD = 99;

    [SerializeField] private int hp;
    [SerializeField] private int maxHp;
    [SerializeField] private int str;
    [SerializeField] private int arm;
    [SerializeField] private int spd;

    public BattleStatus(int hp, int maxhp, int str, int arm, int spd)
    {
        this.hp = hp;
        this.maxHp = maxhp;
        this.str = str;
        this.arm = arm;
        this.spd = spd;
    }

    public int Initiative => Spd + UnityEngine.Random.Range(-1, 2);

    public int Hp
    {
        get => hp;
        set => hp = Mathf.Clamp(value, 0, MAXIMUNM_POSSIBLE_HP);
    }

    public int Str
    {
        get => str;
        set => str = Mathf.Clamp(value, 0, MAXIMUNM_POSSIBLE_STR);
    }

    public int Arm
    {
        get => arm;
        set => arm = Mathf.Clamp(value, 0, MAXIMUNM_POSSIBLE_ARM);
    }

    public int Spd
    {
        get => spd;
        set => spd = Mathf.Clamp(value, 0, MAXIMUNM_POSSIBLE_SPD);
    }
}
