using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandModel : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> cards = new List<GameObject>();
    private GameObject draggingCard;

    public List<GameObject> Cards { get => cards; set => cards = value; }
    public GameObject DraggingCard { get => draggingCard; set => draggingCard = value; }

    // when returning back to hand, get nearest index
    public int getGameObjectIndex(GameObject obj)
    {
        float x = obj.transform.position.x;
        int index = 0;
        cards.ForEach(card =>
        {
            if (card.transform.position.x > x)
            {
                return;
            }
            index++;
        });
        return index;
    }

    public BuffCardModel getDraggingModel()
    {
        if (!draggingCard)
        {
            return null;
        }
        return draggingCard.GetComponentInChildren<BuffCardModel>();
    }

    public void setDraggingCard()
    {
        cards.ForEach(card =>
        {
            BuffCardModel buff = card.GetComponentInChildren<BuffCardModel>();
            if (buff.State == BuffCardState.dragging)
            {
                draggingCard = card;
            }
        });
    }

    public int getIndexOfDraggingCard()
    {
        int index = -1;
        int i = 0;
        cards.ForEach(card =>
        {
            BuffCardModel buff = card.GetComponentInChildren<BuffCardModel>();
            if (buff.State == BuffCardState.dragging)
            {
                index = i;
                return;
            }
            i++;
        });
        return index;
    }

}
