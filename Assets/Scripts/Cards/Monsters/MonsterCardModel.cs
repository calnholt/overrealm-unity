using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;

public enum MonsterCardState
{
    active, left, right
}

public class MonsterCardModel : CardModel, IActionSelectable
{
    [SerializeField]
    private string monsterName;
    [SerializeField]
    [Range(1, 20)]
    private int hp;
    [SerializeField]
    private List<Elements> elements;
    [SerializeField]
    private Roles role;
    [SerializeField]
    [Range(1,3)]
    private int complexity;
    [SerializeField]
    private MonsterCardState state;

    // status condition flags
    private bool isLeeched = false;
    private bool isBurned = false;
    private bool isParalyzed = false;
    private bool isFatigued = false;

    private BuffCardModel appliedCard;

    // unique properties from other monsters
    private int wishes = 0;


    public int Hp { get => hp; set => hp = value; }
    public List<Elements> Elements { get => elements; set => elements = value; }
    public Roles Role { get => role; set => role = value; }
    public int Complexity { get => complexity; set => complexity = value; }
    public bool IsLeeched { get => isLeeched; set => isLeeched = value; }
    public bool IsBurned { get => isBurned; set => isBurned = value; }
    public bool IsParalyzed { get => isParalyzed; set => isParalyzed = value; }
    public bool IsFatigued { get => isFatigued; set => isFatigued = value; }
    public int Wishes { get => wishes; set => wishes = value; }
    public string MonsterName { get => monsterName; set => monsterName = value; }
    public BuffCardModel AppliedCard { get => appliedCard; set => appliedCard = value; }
    public MonsterCardState State { get => state; set => state = value; }

    public bool isApplied()
    {
        return appliedCard;
    }

    public bool isActionSelected()
    {
        return appliedCard;
    }

    public void unselectAction()
    {
        if (appliedCard)
        {
            appliedCard.State = BuffCardState.movingToHand;
        }
    }
}
