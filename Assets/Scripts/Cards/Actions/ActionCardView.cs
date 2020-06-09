using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Constants;

public class ActionCardView : CardView
{
    [SerializeField]
    private GameObject speedTextObject;
    private TextMesh speedText;
    private MeshRenderer speedTextMesh;
    [SerializeField]
    private GameObject attackTextObject;
    private TextMesh attackText;
    private MeshRenderer attackTextMesh;

    private int prevAttack = -10;
    private int prevSpeed = -10;

    private ActionCardModel actionModel;
    private StatCubeBoardModel statCubeBoardModel;
    private ConstantsSingleton constantsSingleton;

    void Start()
    {
        statCubeBoardModel = GameObjectHelper.getUIController().getPlayerStatCubeBoardModel(true);
        actionModel = GameObjectHelper.getScriptFromModel<ActionCardModel>(this.gameObject);
        constantsSingleton = GameObjectHelper.getConstantsSingleton();

        speedText = speedTextObject.GetComponent<TextMesh>();
        speedTextMesh = speedTextObject.GetComponent<MeshRenderer>();

        attackText = attackTextObject.GetComponent<TextMesh>();
        attackTextMesh = attackTextObject.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        updateActionStats();
        updateActionGlow();
        allCardUpdates();
    }

    private void updateActionGlow()
    {
        if (actionModel.IsSelected && !glowSprite.enabled)
        {
            glowSprite.enabled = true;
            glowSprite.color = constantsSingleton.getColor(actionModel.Element);
        }
        else if (!actionModel.IsSelected)
        {
            glowSprite.enabled = false;
        }
    }

    private void updateActionStats()
    {
        int currentAttack = actionModel.Attack + statCubeBoardModel.Attack;
        int currentSpeed = actionModel.Speed + statCubeBoardModel.Speed;
        if (actionModel.isAttack())
        {
            if (!currentAttack.Equals(prevAttack) && !actionModel.StatusFlg && !actionModel.ReactionFlg)
            {
                setStat(attackText, currentAttack, actionModel.OriginalAttack);
                prevAttack = currentAttack;
            }
        }
        else
        {
            attackText.text = "";
        }
        if (!currentSpeed.Equals(prevSpeed))
        {
            setStat(speedText, currentSpeed, actionModel.OriginalSpeed);
            prevSpeed = currentSpeed;
        }
    }

    private void setStat(TextMesh text, int value, int originalValue)
    {
        if (value > 9)
        {
            value = 9;
        }
        if (value < 0)
        {
            value = 0;
        }
        text.text = value.ToString();
        if (value.Equals(originalValue))
        {
            text.color = Color.black;
        } else if (value > originalValue)
        {
            text.color = constantsSingleton.PositiveStat;
        } else
        {
            text.color = constantsSingleton.NegativeStat;
        }
    }

    protected override void setSortingOrder(int order)
    {
        cardSprite.sortingOrder = order;
        speedTextMesh.sortingOrder = order;
        attackTextMesh.sortingOrder = order + 1;
        glowSprite.sortingOrder = order - 1;
    }
}
