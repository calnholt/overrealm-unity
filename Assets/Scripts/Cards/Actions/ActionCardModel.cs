using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCardModel : CardModel 
{
    [SerializeField]
    private string attackName;
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

    private void Start()
    {
        originalAttack = attack;
        originalSpeed = speed;
    }

    
}
