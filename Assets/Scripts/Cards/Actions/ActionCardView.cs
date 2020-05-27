using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionCardView : MonoBehaviour
{
    public Text speedText;
    public Text attackText;

    private int prevAttack = -10;
    private int prevSpeed = -10;

    private ActionCardModel actionModel;
    private StatCubeBoardModel statCubeBoardModel;

    void Start()
    {
        statCubeBoardModel = GameObjectHelper.getUIController().getPlayerStatCubeBoardModel(true);
        actionModel = GameObjectHelper.getScriptFromModel<ActionCardModel>(this.gameObject);
        speedText.text = actionModel.Speed.ToString() ;
        attackText.text = actionModel.Attack.ToString();
    }

    void Update()
    {
        updateAction();
    }

    private void updateAction()
    {
        int currentAttack = actionModel.Attack + statCubeBoardModel.Attack;
        int currentSpeed = actionModel.Speed + statCubeBoardModel.Speed;
        if (isAttack())
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

    private void setStat(Text text, int value, int originalValue)
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
            text.color = Color.green;
        } else
        {
            text.color = Color.red;
        }
    }

    private bool isAttack()
    {
        return !actionModel.ReactionFlg && !actionModel.StatusFlg && actionModel.AuraDuration == 0;
    }

    
}
