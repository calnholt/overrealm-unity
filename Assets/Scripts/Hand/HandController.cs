using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HandController : MonoBehaviour
{
    private HandModel handModel;
    private Vector3 leftBounds;
    private Vector3 rightBounds;
    private float duration = 0.5f;
    private int previousNumOfCards = -1;
    private Dictionary<int, BuffCardModel> appliedCardsMap = new Dictionary<int, BuffCardModel>();

    void Start()
    {
        handModel = GameObjectHelper.getScriptFromModel<HandModel>(gameObject);
        leftBounds = gameObject.transform.GetChild(0).position;
        rightBounds = gameObject.transform.GetChild(1).position;
    }

    private void Update()
    {
        if (handModel.getDraggingModel() != null)
        {
            Debug.Log(handModel.getDraggingModel().State);
        }
        int currentNumOfCards = handModel.Cards.Count;
        // find card that is currently being dragged
        // dragging is set in BuffModelController
        handModel.setDraggingCard();
        // removed dragging card from hand
        int draggingCardIndex = handModel.getIndexOfDraggingCard();
        if (draggingCardIndex != -1)
        {
            handModel.Cards.RemoveAt(draggingCardIndex);
        }
        if (handModel.DraggingCard)
        {
            BuffCardModel buff = handModel.getDraggingModel();
            // return card back to hand if not dragging or applied
            if (buff.State == BuffCardState.movingToHand)
            {
                // insert dragging card back into hand list
                handModel.Cards.Insert(handModel.getGameObjectIndex(handModel.DraggingCard.gameObject), buff.transform.parent.gameObject);
                updateHandFanning();
                handModel.DraggingCard = null;
            }
            // clear reference if card is applied
            else if (buff.State != BuffCardState.dragging && !buff.isDraggingOverApplied())
            {
                updateHandFanning();
                appliedCardsMap.Add(buff.GetInstanceID(), buff);
                handModel.DraggingCard = null;
            }
        }
        // update fanning when cards in hand number changes
        else if (previousNumOfCards != currentNumOfCards)
        {
            updateHandFanning();
            previousNumOfCards = currentNumOfCards;
        }
        checkIfAppliedCardsMovingBackToHand();
    }

    // whenever a card is removed from the hand, it has been applied
    // applied cards are added to the dictionary
    // check to see cards in the dictionary have a movingToHand state, and add them back to the player's hand
    // this prevents the need of manually adding buffs to the model, instead just catches and adds via state
    // inserts into nearest index
    void checkIfAppliedCardsMovingBackToHand()
    {
        if (appliedCardsMap.Count > 0)
        {
            Dictionary<int, BuffCardModel> copyMap = new Dictionary<int, BuffCardModel>(appliedCardsMap);
            foreach (KeyValuePair<int, BuffCardModel> entry in copyMap)
            {
                if (entry.Value.State == BuffCardState.movingToHand)
                {
                    appliedCardsMap.Remove(entry.Key);
                    GameObject objToAdd = entry.Value.transform.parent.gameObject;
                    handModel.Cards.Insert(handModel.getGameObjectIndex(objToAdd), objToAdd);
                }
            }
        }
    }

    // moves all buffs, including buffs with state movingToHand, to hand, and adds fanning
    void updateHandFanning()
    {
        List<Vector3> positions = new List<Vector3>();
        float diff = rightBounds.x - leftBounds.x;
        float spacing = diff / (handModel.Cards.Count + 1);
        float increments = spacing;
        handModel.Cards.ForEach(card =>
        {
            BuffCardModel buff = card.transform.GetComponentInChildren<BuffCardModel>();
            // dont set the dragged card's state
            if (buff.State != BuffCardState.movingToHand)
            {
                buff.State = BuffCardState.fanning;
            }
            Vector3 target = new Vector3(leftBounds.x + increments, leftBounds.y, leftBounds.z);
            card.transform.DOLocalMove(target, duration).OnComplete(() => backToHandCallback(buff));
            increments += spacing;
        });
    }

    // callback from tween
    void backToHandCallback(BuffCardModel buff)
    {
        buff.State = BuffCardState.inHand;
    }


}
