using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatCubeBoardView : MonoBehaviour
{
    private StatCubeBoardModel statCubeBoardModel;

    public Text attackText;
    public Text speedText;
    public Text defenseText;

    public Image attackPanel;
    public Image speedPanel;
    public Image defensePanel;

    public Color positiveColor;
    public Color negativeColor;
    public Color neutralColor;

    private int prevAttack = -10;
    private int prevSpeed = -10;
    private int prevDefense = -10;

    void Start()
    {
        statCubeBoardModel = this.transform.GetComponent<StatCubeBoardModel>();
        updateBoard();
    }

    void Update()
    {
        updateBoard();
    }

    private void updateBoard()
    {
        int currentAttack = statCubeBoardModel.Attack;
        int currentSpeed = statCubeBoardModel.Speed;
        int currentDefense = statCubeBoardModel.Defense;
        if (!currentAttack.Equals(prevAttack))
        {
            setSection(attackText, attackPanel, statCubeBoardModel.Attack, prevAttack);
        }
        if (!currentSpeed.Equals(prevSpeed))
        {
            setSection(speedText, speedPanel, statCubeBoardModel.Speed, prevSpeed);
        }
        if (!currentDefense.Equals(prevDefense))
        {
            setSection(defenseText, defensePanel, statCubeBoardModel.Defense, prevDefense);
        }
    }

    private void setSection(Text text, Image image, int value, int prevValue)
    {
        setColor(image, value);
        setText(text, value);
        prevValue = value;
    }

    private void setColor(Image image, int value)
    {
        if (value > 0)
        {
            image.color = new Color(positiveColor.r, positiveColor.g, positiveColor.b);
        } else if (value < 0)
        {
            image.color = new Color(negativeColor.r, negativeColor.g, negativeColor.b);
        } else
        {
            image.color = new Color(neutralColor.r, neutralColor.g, neutralColor.b);

        }

    }

    private void setText(Text text, int value)
    {
        if (value > 0)
        {
            text.text = "+" + value;
        } else
        {
            text.text = value.ToString();
        }
    }
}
