using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Constants;

public class MonsterCardView : CardView
{
    [SerializeField]
    private GameObject hpTextObject;
    private TextMesh hpText;
    private MonsterCardModel monsterModel;
    private MeshRenderer hpTextMesh;
    void Start()
    {
        monsterModel = GameObjectHelper.getScriptFromModel<MonsterCardModel>(this.gameObject);
        hpText = hpTextObject.GetComponent<TextMesh>();
        hpTextMesh = hpTextObject.GetComponent<MeshRenderer>();
        hpText.text = monsterModel.Hp.ToString();
    }

    void Update()
    {
        updateMonsterGlow();
        allCardUpdates();
    }

    private void updateMonsterGlow()
    {
        if (monsterModel.isApplied() && !glowSprite.enabled)
        {
            glowSprite.enabled = true;
        }
        else if (!monsterModel.isApplied())
        {
            glowSprite.enabled = false;
        }
    }

    protected override void setSortingOrder(int order)
    {
        cardSprite.sortingOrder = order;
        hpTextMesh.sortingOrder = order + 1;
        glowSprite.sortingOrder = order - 1;
    }
}
