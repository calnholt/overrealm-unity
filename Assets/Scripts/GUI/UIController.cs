using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Transform userStatBoard;
    [SerializeField]
    private Transform opponentStatBoard;
    private StatCubeBoardController userStatBoardController;
    private StatCubeBoardController opponentStatBoardController;

    void Start()
    {
        userStatBoardController = userStatBoard.GetComponent<StatCubeBoardController>();
        opponentStatBoardController = opponentStatBoard.GetComponent<StatCubeBoardController>();
    }

    public StatCubeBoardModel getPlayerStatCubeBoardModel(bool isUser)
    {
        if (isUser)
        {
            return userStatBoardController.getStatCubeBoardModel();
        }
        return opponentStatBoardController.getStatCubeBoardModel();
    }
}
