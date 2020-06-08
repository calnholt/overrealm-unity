using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;
using DG.Tweening;

public abstract class CardView : MonoBehaviour
{
    [SerializeField]
    protected GameObject cardSpriteObject;
    protected SpriteRenderer cardSprite;
    [SerializeField]
    protected GameObject glowSpriteObject;
    protected SpriteRenderer glowSprite;
    [SerializeField]
    protected GameObject manueverObject;
    private CardModel model;
    void Awake()
    {
        model = GameObjectHelper.getScriptFromModel<CardModel>(this.gameObject);
        cardSprite = cardSpriteObject.GetComponent<SpriteRenderer>();
        glowSprite = glowSpriteObject.GetComponent<SpriteRenderer>();
    }

    private void updateScale()
    {
        if (!model.IsHovering && !model.IsHoveringApplied && !transform.IsTransformScaleDefault())
        {
            transform.DOScale(1, 0.5f).SetEase(Ease.OutQuint);
        }
    }

    private void updateHover()
    {
        if (model.IsHovering)
        {
            setSortingOrder(SortingOrders.ACTION_HOVER);
            transform.DOScale(1.5f, 0.5f).SetEase(Ease.OutQuint);
        }
        else
        {
            setSortingOrder(SortingOrders.ACTION_DEFAULT);
            transform.DOScale(1, 0.5f).SetEase(Ease.OutQuint);
        }
    }

    private void updateManuever()
    {
        if (model.IsManeuver && !manueverObject.activeSelf)
        {
            manueverObject.SetActive(true);
        }
        else if (!model.IsManeuver && manueverObject.activeSelf)
        {
            manueverObject.SetActive(false);
        }
    }

    protected void allCardUpdates()
    {
        updateScale();
        updateHover();
        updateManuever();
    }

    protected abstract void setSortingOrder(int order);
}
