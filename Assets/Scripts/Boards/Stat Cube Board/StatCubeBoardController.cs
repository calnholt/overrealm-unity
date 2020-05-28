using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatCubeBoardController : MonoBehaviour
{
    [SerializeField]
    private bool activePlayerFlg;
    private StatCubeBoardModel model;
    private const int MIN = -4;
    private const int MAX = 4;

    public bool ActivePlayerFlg { get => activePlayerFlg; set => activePlayerFlg = value; }

    void Awake()
    {
        model = this.transform.GetComponent<StatCubeBoardModel>();
    }

    public void GainAttackCubes(int num)
    {
        model.Attack = GetValue(model.Attack + num);
    }

    public void GainSpeedCubes(int num)
    {
        model.Speed = GetValue(model.Attack + num);
    }

    public void GainDefenseCubes(int num)
    {
        model.Defense = GetValue(model.Attack + num);
    }

    public void ClearBoard()
    {
        model.Defense = 0;
        model.Attack = 0;
        model.Speed = 0;
    }

    private int GetValue(int value)
    {
        if (value < MIN)
        {
            value = MIN;
        }
        else if (value > MAX)
        {
            value = MAX;
        }
        return value;
    }

    public StatCubeBoardModel getStatCubeBoardModel()
    {
        Debug.Log(model);
        return model;
    }

}
