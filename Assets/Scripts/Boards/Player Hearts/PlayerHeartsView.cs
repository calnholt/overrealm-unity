using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeartsView : MonoBehaviour
{
    [SerializeField]
    private bool activePlayerFlg;
    private PlayerMonstersModel playerMonstersModel;
    private List<Text> texts;

    private int left = -10;
    private int right = -10;
    private int active = -10;

    private const int LEFT = 0;
    private const int RIGHT = 1;
    private const int ACTIVE = 2;

    void Start()
    {
        string tag = activePlayerFlg ? "Player" : "Opponent";
        playerMonstersModel = GameObject.FindGameObjectWithTag(tag).GetComponentInChildren<PlayerMonstersModel>();
        texts = GameObjectHelper.GetComponentsInChildrenList<Text>(gameObject);
        updateHearts();
    }

    void Update()
    {
        updateHearts();
    }

    private void updateHearts()
    {
        int currentLeft = playerMonstersModel.LeftInactiveMonster.MonsterCardModel.Hp;
        int currentRight = playerMonstersModel.RightInactiveMonster.MonsterCardModel.Hp;
        int currentActive = playerMonstersModel.ActiveMonsterModel.MonsterCardModel.Hp;
        if (currentLeft != left)
        {

            left = normalizeValue(currentLeft);
            texts[LEFT].text = left.ToString();
        }
        if (currentRight != right)
        {

            right = normalizeValue(currentRight);
            texts[RIGHT].text = right.ToString();
        }
        if (currentActive != active)
        {

            active = normalizeValue(currentActive);
            texts[ACTIVE].text = active.ToString();
        }
    }

    private int normalizeValue(int value)
    {
        if (value < 0)
        {
            value = 0;
        }
        return value;
    }
}
