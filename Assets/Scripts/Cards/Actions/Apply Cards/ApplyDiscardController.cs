using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyDiscardController : MonoBehaviour
{
    //TODO: do this dynamically
    [SerializeField]
    private GameObject handModelObj;
    private HandModel handModel;
    private ActionCardModel actionCardModel;
    private GameObject discardToApply;
    private BuffCardModel buffCardModel;

    void Start()
    {
        actionCardModel = GameObjectHelper.getScriptFromModel<ActionCardModel>(gameObject.transform.parent.gameObject);
        handModel = handModelObj.GetComponent<HandModel>();
    }

    // Update is called once per frame
    void Update()
    {
        checkIfBuffBecomesUnapplied();
        if (!discardToApply) return;
        if (buffCardModel.State == BuffCardState.appliedAsDiscard)
        {
            this.actionCardModel.DiscardsToApply.Add(discardToApply);
            discardToApply = null;
        }
    }

    private void checkIfBuffBecomesUnapplied()
    {
        int index = actionCardModel.DiscardsToApply.FindIndex(buff => buff.transform.GetComponentInChildren<BuffCardModel>().State == BuffCardState.movingToHand);
        if (index >= 0)
        {
            handModel.Cards.Add(actionCardModel.DiscardsToApply[index]);
            actionCardModel.DiscardsToApply.RemoveAt(index);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        buffCardModel = GameObjectHelper.getScriptFromModel<BuffCardModel>(collision.gameObject);
        if (buffCardModel && buffCardModel.State == BuffCardState.dragging && actionCardModel.canApplyBuff())
        {
            discardToApply = collision.transform.parent.gameObject;
            buffCardModel.State = BuffCardState.draggingOverDiscardApply;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        buffCardModel = GameObjectHelper.getScriptFromModel<BuffCardModel>(collision.gameObject);
        if (buffCardModel && buffCardModel.State == BuffCardState.draggingOverDiscardApply)
        {
            discardToApply = null;
            buffCardModel.State = BuffCardState.dragging;
        }
    }
}
