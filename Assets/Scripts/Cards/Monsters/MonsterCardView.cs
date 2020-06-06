using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Constants;

public class MonsterCardView : MonoBehaviour
{
    [SerializeField]
    private Canvas hpCanvas;
    [SerializeField]
    private Text hpText;
    private MonsterCardModel monsterModel;
    [SerializeField]
    private Image glowImage;
    [SerializeField]
    private Canvas glowCanvas;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        monsterModel = GameObjectHelper.getScriptFromModel<MonsterCardModel>(this.gameObject);
        hpText.text = monsterModel.Hp.ToString();
    }

    void Update()
    {
        updateMonsterHover();
        updateMonsterGlow();
    }

    private void updateMonsterHover()
    {
        if (monsterModel.IsHovering)
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

    private void updateMonsterGlow()
    {
        if (monsterModel.isApplied() && !glowImage.enabled)
        {
            glowImage.enabled = true;
        }
        else if (!monsterModel.isApplied())
        {
            glowImage.enabled = false;
        }
    }

    private void setSortingOrder(int order)
    {
        spriteRenderer.sortingOrder = order;
        hpCanvas.sortingOrder = order + 1;
        glowCanvas.sortingOrder = order - 1;
    }
}
