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
    private Vector3 originalPosition;
    private Sequence sequence;


    void Start()
    {
        buffCardModel = GameObjectHelper.getScriptFromModel<BuffCardModel>(gameObject);
        card = buffCardModel.transform.parent.gameObject;
    }

    private void OnMouseDown()
    {
        killSequence();
        buffCardModel.State = BuffCardState.dragging;
        Debug.Log("buff model dragging");
    }

    private void OnMouseUp()
    {
        killSequence();
        if (buffCardModel.State == BuffCardState.draggingOverApply)
        {
            //killSequence();
            buffCardModel.State = BuffCardState.draggingOverApply;
        }
        else
        {
            //killSequence();
            buffCardModel.State = BuffCardState.movingToHand;
        }
    }

    private void OnMouseOver()
    {
        if (buffCardModel.State == BuffCardState.inHand || buffCardModel.State == BuffCardState.hoveringInHandMovingDown)
        {
            if (buffCardModel.State == BuffCardState.inHand)
            {
                originalPosition = transform.position;
            }
            buffCardModel.State = BuffCardState.hoveringInHandMovingUp;
            killSequence();
            sequence = DOTween.Sequence();
            sequence.Append(card.transform.DOLocalMove(getTargetPosition(), 1f).SetEase(Ease.OutQuint));
            sequence.AppendCallback(finishHoveringEndCallback);
        }
    }

    private void OnMouseExit()
    {
        if (buffCardModel.State == BuffCardState.hoveringInHandFullyUp || buffCardModel.State == BuffCardState.hoveringInHandMovingUp)
        {
            buffCardModel.State = BuffCardState.hoveringInHandMovingDown;
            killSequence();
            sequence = DOTween.Sequence();
            sequence.Append(card.transform.DOLocalMove(originalPosition, 1f).SetEase(Ease.OutQuint));
            sequence.AppendCallback(finishHoveringStartCallback);
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

    private void killSequence()
    {
        if (sequence != null)
        {
            sequence.Kill();
        }
    }
}
