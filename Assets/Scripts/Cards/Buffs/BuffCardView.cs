using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BuffCardView : MonoBehaviour
{
    private BuffCardModel model;
    private SpriteRenderer spriteRenderer;
    private BuffOverlayManager buffOverlayManager;
    [SerializeField]
    private float hoveringInHandMovingUpScale = 1f;
    [SerializeField]
    private float hoveringInHandMovingDownScale = 0.75f;
    [SerializeField]
    private float draggingScale = 0.5f;
    [SerializeField]
    private float appliedScale = 0.20f;
    private Sequence seq;
    private float duration = 0.5f;
    private bool disableInteractionsFlg = false;
    private BuffCardState previousState;
    void Start()
    {
        model = GameObjectHelper.getScriptFromModel<BuffCardModel>(gameObject);
        buffOverlayManager = GetComponentInChildren<BuffOverlayManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        seq = DOTween.Sequence();
    }

    void Update()
    {
        //if (previousState == model.State) return;
        if (model.State == BuffCardState.dragging || model.isHandHovering())
        {
            spriteRenderer.sortingOrder = 10;
        }
        if (model.State == BuffCardState.dragging)
        {
            model.transform.parent.DOScale(draggingScale, duration).SetEase(Ease.OutQuint);
        }
        if (model.State == BuffCardState.movingToHand)
        {
            buffOverlayManager.setVisible(true);
            buffOverlayManager.setAllActive(false);
            model.transform.parent.DOScale(hoveringInHandMovingDownScale, duration).SetEase(Ease.OutQuint);
        }
        if (model.State == BuffCardState.inHand || model.isApplied())
        {
            spriteRenderer.sortingOrder = 0;
        }
        if (model.State == BuffCardState.draggingOverBuffApply)
        {
            buffOverlayManager.BuffFluctuate.SetActive(true);
        }
        if (model.State == BuffCardState.draggingOverDiscardApply)
        {
            buffOverlayManager.DiscardFluctuate.SetActive(true);
        }
        if (model.State == BuffCardState.draggingOverDrawThreeApply)
        {
            buffOverlayManager.DrawThreeFluctuate.SetActive(true);
        }
        if (model.State != BuffCardState.draggingOverBuffApply && buffOverlayManager.BuffFluctuate.activeSelf)
        {
            buffOverlayManager.BuffFluctuate.SetActive(false);
        }
        if (model.State != BuffCardState.draggingOverDiscardApply && buffOverlayManager.DiscardFluctuate.activeSelf)
        {
            buffOverlayManager.DiscardFluctuate.SetActive(false);
        }
        if (model.State != BuffCardState.draggingOverDrawThreeApply && buffOverlayManager.DrawThreeFluctuate.activeSelf)
        {
            buffOverlayManager.DrawThreeFluctuate.SetActive(false);
        }
        if (model.HoveringOverApplied)
        {
            spriteRenderer.sortingOrder = 20;
            buffOverlayManager.setVisible(false);
            model.transform.parent.DOScale(draggingScale, duration).SetEase(Ease.OutQuint);
        }
        else if (model.isApplied())
        {
            spriteRenderer.sortingOrder = 0;
            buffOverlayManager.setVisible(true);
            tweenWithDisable(appliedScale);
            if (model.State == BuffCardState.appliedAsBuff)
            {
                buffOverlayManager.setAsBuff();
            }
            if (model.State == BuffCardState.appliedAsDiscard)
            {
                buffOverlayManager.setAsDiscard();
            }
            if (model.State == BuffCardState.appliedAsDrawThree)
            {
                buffOverlayManager.setAsDrawThree();
            }
        }
        // increase card size when hovering
        if (model.State == BuffCardState.hoveringInHandMovingUp)
        {
            model.transform.parent.DOScale(hoveringInHandMovingUpScale, duration).SetEase(Ease.OutQuint);
        }
        // decrease card size when stop hovering
        else if (model.State == BuffCardState.hoveringInHandMovingDown)
        {
            model.transform.parent.DOScale(hoveringInHandMovingDownScale, duration).SetEase(Ease.OutQuint);
        }
        previousState = model.State;
    }

    private void tweenWithDisable(float scale)
    {
        if (!disableInteractionsFlg)
        {
            disableInteractionsFlg = true;
        }
        seq.Kill();
        seq.Append(model.transform.parent.DOScale(scale, duration).SetEase(Ease.OutQuint));
        seq.AppendCallback(tweenCallback);
    }

    private void tweenCallback()
    {
        disableInteractionsFlg = false;
    }

}
