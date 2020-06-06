using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionCardController : MonoBehaviour
{
    private ActionCardModel actionCardModel;
    private int previousApplied;
    private bool previousSelected;
    [SerializeField]
    private GameObject bounds;
    private Vector3 leftBounds;
    private Vector3 rightBounds;
    private BuffCardModel draggingBuff;

    void Start()
    {
        actionCardModel = GameObjectHelper.getScriptFromModel<ActionCardModel>(gameObject);
        leftBounds = bounds.transform.GetChild(0).position;
        rightBounds = bounds.transform.GetChild(1).position;
        previousApplied = actionCardModel.BuffsToApply.Count;
    }

    void Update()
    {
        updateSelected();
        updateAppliedBuffs();
        updateHovering();
        updateAppliedChanged();
        previousSelected = actionCardModel.IsSelected;
    }

    private void updateAppliedBuffs()
    {
        if (isAppliedChanged())
        {
            List<Vector3> positions = new List<Vector3>();
            float diff = rightBounds.x - leftBounds.x;
            float spacing = diff / (actionCardModel.getNumberOfApplied() + 1);
            float increments = spacing;
            List<GameObject> appliedCards = new List<GameObject>(actionCardModel.BuffsToApply);
            appliedCards.AddRange(actionCardModel.DiscardsToApply);
            appliedCards.ForEach(buff =>
            {
                Vector3 target = new Vector3(leftBounds.x + increments, leftBounds.y, leftBounds.z);
                buff.transform.localPosition = target;
                increments += spacing;
            });
            actionCardModel.IsBuff = false;
            draggingBuff = null;
        }
    }

    public bool isAppliedChanged()
    {
        int currentApplied = actionCardModel.getNumberOfApplied();
        bool isAppliedChanged = currentApplied != previousApplied;
        return isAppliedChanged;
    }

    private void updateAppliedChanged()
    {
        if (isAppliedChanged())
        {
            previousApplied = actionCardModel.getNumberOfApplied();
        }
    }

    private void updateSelected()
    {
        bool isNewlyApplied = actionCardModel.getNumberOfApplied() == 1 && previousApplied == 0;
        if (isNewlyApplied)
        {
            actionCardModel.IsSelected = true;
        }
        // move applied cards back to hand
        else if (!actionCardModel.IsSelected)
        {
            actionCardModel.unselectAction();
        }
    }

    private void OnMouseOver()
    {
        if (draggingBuff == null)
        {
            actionCardModel.IsHovering = true;
        }
    }

    private void OnMouseExit()
    {
        if (draggingBuff == null)
        {
            actionCardModel.IsHovering = false;
        }
    }

    private void OnMouseDown()
    {
        actionCardModel.IsSelected = !actionCardModel.IsSelected;
    }

    private void updateHovering()
    {
        if (isAppliedChanged())
        {
            draggingBuff = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BuffCardModel buff = collision.transform.parent.GetComponentInChildren<BuffCardModel>();
        if (buff)
        {
            if (buff.isDragging())
            {
                draggingBuff = buff;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        BuffCardModel buff = collision.transform.parent.GetComponentInChildren<BuffCardModel>();
        if (buff && draggingBuff != null)
        {
            draggingBuff = null;
        }
    }

}
