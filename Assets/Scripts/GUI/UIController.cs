using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private StatCubeBoardController userStatBoardController;
    private StatCubeBoardController opponentStatBoardController;

    void Start()
    {
        List<StatCubeBoardController> statCubeBoardControllers = GameObjectHelper.GetComponentsInChildrenList<StatCubeBoardController>(gameObject);
        userStatBoardController = statCubeBoardControllers.Find(m => m.ActivePlayerFlg);
        opponentStatBoardController = statCubeBoardControllers.Find(m => !m.ActivePlayerFlg);
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
