using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BuffCardController : MonoBehaviour
{
    [SerializeField]
    private float scale;
    [SerializeField]
    private float height;
    private BuffCardModel buffCardModel;
    private GameObject card;
    private Vector3 originalPosition; // 
    private Sequence sequence;
    private Draggable draggable;

    void Start()
    {
        buffCardModel = GameObjectHelper.getScriptFromModel<BuffCardModel>(gameObject);
        card = buffCardModel.transform.parent.gameObject;
        sequence = DOTween.Sequence();
        draggable = GetComponent<Draggable>();
    }

    private void Update()
    {
        updateDraggable();
    }

    // when transitioning to states where dragging shouldn't be active, set draggable dragging to false
    private void updateDraggable()
    {
        if (buffCardModel.State == BuffCardState.movingToHand || buffCardModel.State == BuffCardState.fanning)
        {
            draggable.Dragging = false;
        }
    }

    private void OnMouseDown()
    {
        sequence.Kill();
        // return applied card to owner's hand
        if (buffCardModel.isApplied())
        {
            buffCardModel.State = BuffCardState.movingToHand;
        }
        else if (buffCardModel.isDraggable())
        {
            buffCardModel.State = BuffCardState.dragging;
        }
    }

    // controls the destination of the buff depending on current state
    private void OnMouseUp()
    {
        sequence.Kill();
        if (buffCardModel.State == BuffCardState.draggingOverDiscardApply)
        {
            buffCardModel.State = BuffCardState.appliedAsDiscard;
        }
        else if (buffCardModel.State == BuffCardState.draggingOverBuffApply)
        {
            buffCardModel.State = BuffCardState.appliedAsBuff;
        }
        else if (buffCardModel.State == BuffCardState.draggingOverDrawThreeApply)
        {
            buffCardModel.State = BuffCardState.appliedAsDrawThree;
        }
        else if (buffCardModel.State == BuffCardState.draggingOverSwitchLeftApply)
        {
            buffCardModel.State = BuffCardState.appliedAsSwitchLeft;
        }
        else if (buffCardModel.State == BuffCardState.draggingOverSwitchRightApply)
        {
            buffCardModel.State = BuffCardState.appliedAsSwitchRight;
        }
        else
        {
            buffCardModel.State = BuffCardState.movingToHand;
        }
    }

    private void OnMouseEnter()
    {
        // moved from onmouseover, so if issues move back
        if (buffCardModel.State == BuffCardState.inHand || buffCardModel.State == BuffCardState.hoveringInHandMovingDown)
        {
            if (buffCardModel.State == BuffCardState.inHand)
            {
                originalPosition = transform.position;
            }
            buffCardModel.State = BuffCardState.hoveringInHandMovingUp;
            sequence.Kill();
            sequence = DOTween.Sequence();
            sequence.Append(card.transform.DOLocalMove(getTargetPosition(), 1f)).SetEase(Ease.OutQuint);
            sequence.AppendCallback(finishHoveringEndCallback);
        }
        if (buffCardModel.isApplied())
        {
            buffCardModel.HoveringOverApplied = true;
        }
    }

    private void OnMouseExit()
    {
        if (buffCardModel.State == BuffCardState.hoveringInHandFullyUp || buffCardModel.State == BuffCardState.hoveringInHandMovingUp)
        {
            buffCardModel.State = BuffCardState.hoveringInHandMovingDown;
            sequence.Kill();
            sequence = DOTween.Sequence();
            sequence.Append(card.transform.DOLocalMove(originalPosition, 1f).SetEase(Ease.OutQuint));
            sequence.AppendCallback(finishHoveringStartCallback);
        }
        if (buffCardModel.HoveringOverApplied)
        {
            buffCardModel.HoveringOverApplied = false;
        }
    }


    private Vector3 getTargetPosition()
    {
        float heightDiff = (originalPosition.y + height) - transform.position.y;
        return new Vector3(transform.position.x, transform.position.y + heightDiff, transform.position.z);
    }

    private void finishHoveringEndCallback()
    {
        buffCardModel.State = BuffCardState.hoveringInHandFullyUp;
    }

    private void finishHoveringStartCallback()
    {
        buffCardModel.State = BuffCardState.inHand;
        originalPosition = transform.position;
    }


}
