using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Constants;

public class ActionCardView : MonoBehaviour
{
    [SerializeField]
    private Text speedText;
    [SerializeField]
    private Text attackText;
    [SerializeField]
    private Image glowImage;
    [SerializeField]
    private float hoverScale;
    [SerializeField]
    private Canvas statCanvas;
    [SerializeField]
    private Canvas glowCanvas;

    private int prevAttack = -10;
    private int prevSpeed = -10;

    private ActionCardModel actionModel;
    private StatCubeBoardModel statCubeBoardModel;
    private SpriteRenderer spriteRenderer;

    private ConstantsSingleton constantsSingleton;

    void Start()
    {
        statCubeBoardModel = GameObjectHelper.getUIController().getPlayerStatCubeBoardModel(true);
        actionModel = GameObjectHelper.getScriptFromModel<ActionCardModel>(this.gameObject);
        constantsSingleton = GameObjectHelper.getScriptFromTag<ConstantsSingleton>(Tags.Singleton);
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        speedText.text = actionModel.Speed.ToString() ;
        attackText.text = actionModel.Attack.ToString();
    }

    void Update()
    {
        updateActionStats();
        updateActionGlow();
        updateActionHover();
    }

    private void updateActionGlow()
    {
        if (actionModel.IsSelected && !glowImage.enabled)
        {
            glowImage.enabled = true;
            glowImage.color = constantsSingleton.getColor(actionModel.Element);
        }
        else if (!actionModel.IsSelected)
        {
            glowImage.enabled = false;
        }
    }

    private void updateActionHover()
    {
        if (actionModel.IsHovering)
        {
            setSortingOrder(SortingOrders.ACTION_HOVER);
            actionModel.transform.parent.GetChild(1).DOScale(hoverScale, 0.5f).SetEase(Ease.OutQuint);
        }
        else
        {
            setSortingOrder(SortingOrders.ACTION_DEFAULT);
            actionModel.transform.parent.GetChild(1).DOScale(1, 0.5f).SetEase(Ease.OutQuint);
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
            text.color = constantsSingleton.PositiveStat;
        } else
        {
            text.color = constantsSingleton.NegativeStat;
        }
    }

    private void setSortingOrder(int order)
    {
        spriteRenderer.sortingOrder = order;
        statCanvas.sortingOrder = order;
        glowCanvas.sortingOrder = order - 1;
    }

        

    
}
