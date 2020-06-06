using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;

public class ActionCardModel : CardModel, IActionSelectable
{
    [SerializeField]
    private string attackName;
    [SerializeField]
    private Elements element;
    [SerializeField]
    [Range(0,9)]
    private int attack;
    [SerializeField]
    [Range(1,9)]
    private int speed;
    [SerializeField]
    [Range(0,5)]
    private int draw;
    [SerializeField]
    [Range(0, 5)]
    private int discard;
    [SerializeField]
    [Range(0, 5)]
    private int buff;
    [SerializeField]
    [Range(0, 5)]
    private List<int> modifiers;
    [SerializeField]
    private bool statusFlg;
    [SerializeField]
    private bool reactionFlg;
    [SerializeField]
    [Range(0, 10)]
    private int auraDuration;

    private int originalAttack;
    private int originalSpeed;
    
    private bool isBuff = false;

    private List<GameObject> buffsToApply = new List<GameObject>();
    private List<GameObject> discardsToApply = new List<GameObject>();


    public string AttackName { get => attackName; set => attackName = value; }
    public int Attack { get => attack; set => attack = value; }
    public int Speed { get => speed; set => speed = value; }
    public int Draw { get => draw; set => draw = value; }
    public int Discard { get => discard; set => discard = value; }
    public int Buff { get => buff; set => buff = value; }
    public int OriginalAttack { get => originalAttack; set => originalAttack = value; }
    public int OriginalSpeed { get => originalSpeed; set => originalSpeed = value; }
    public bool StatusFlg { get => statusFlg; set => statusFlg = value; }
    public bool ReactionFlg { get => reactionFlg; set => reactionFlg = value; }
    public int AuraDuration { get => auraDuration; set => auraDuration = value; }
    public List<GameObject> BuffsToApply { get => buffsToApply; set => buffsToApply = value; }
    public List<GameObject> DiscardsToApply { get => discardsToApply; set => discardsToApply = value; }
    public bool IsBuff { get => isBuff; set => isBuff = value; }
    public Elements Element { get => element; set => element = value; }

    private void Start()
    {
        originalAttack = attack;
        originalSpeed = speed;
    }

    public bool canApplyBuff()
    {
        return buffsToApply.Count < buff;
    }

    public bool canApplyDiscard()
    {
        return discardsToApply.Count < discard;
    }
    public bool isAttack()
    {
        return !reactionFlg && !statusFlg && auraDuration == 0;
    }
    public int getNumberOfApplied()
    {
        return buffsToApply.Count + discardsToApply.Count;
    }

    public bool isActionSelected()
    {
        return isSelected;
    }

    public void unselectAction()
    {
        isSelected = false;
        if (getNumberOfApplied() == 0) return;
        List<GameObject> appliedCards = new List<GameObject>(buffsToApply);
        appliedCards.AddRange(discardsToApply);
        appliedCards.ForEach(card =>
        {
            card.GetComponentInChildren<BuffCardModel>().State = BuffCardState.movingToHand;
        });
    }


}
