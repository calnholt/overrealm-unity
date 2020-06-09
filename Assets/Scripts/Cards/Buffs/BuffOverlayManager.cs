using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffOverlayManager : MonoBehaviour
{
    [SerializeField]
    private GameObject buffFluctuate;
    [SerializeField]
    private GameObject buff;
    [SerializeField]
    private GameObject discardFluctuate;
    [SerializeField]
    private GameObject discard;
    [SerializeField]
    private GameObject switchLeftFluctuate;
    [SerializeField]
    private GameObject switchLeft;
    [SerializeField]
    private GameObject switchRightFluctuate;
    [SerializeField]
    private GameObject switchRight;
    [SerializeField]
    private GameObject drawThreeFluctuate;
    [SerializeField]
    private GameObject drawThree;
    [SerializeField]
    private GameObject counterFluctuate;
    [SerializeField]
    private GameObject counter;

    public GameObject BuffFluctuate { get => buffFluctuate; set => buffFluctuate = value; }
    public GameObject Buff { get => buff; set => buff = value; }
    public GameObject DiscardFluctuate { get => discardFluctuate; set => discardFluctuate = value; }
    public GameObject Discard { get => discard; set => discard = value; }
    public GameObject SwitchLeftFluctuate { get => switchLeftFluctuate; set => switchLeftFluctuate = value; }
    public GameObject SwitchLeft { get => switchLeft; set => switchLeft = value; }
    public GameObject SwitchRightFluctuate { get => switchRightFluctuate; set => switchRightFluctuate = value; }
    public GameObject SwitchRight { get => switchRight; set => switchRight = value; }
    public GameObject DrawThreeFluctuate { get => drawThreeFluctuate; set => drawThreeFluctuate = value; }
    public GameObject DrawThree { get => drawThree; set => drawThree = value; }
    public GameObject CounterFluctuate { get => counterFluctuate; set => counterFluctuate = value; }
    public GameObject Counter { get => counter; set => counter = value; }

    void Awake()
    {
        buffFluctuate.SetActive(false);
        buff.SetActive(false);
        discardFluctuate.SetActive(false);
        discard.SetActive(false);
        switchLeftFluctuate.SetActive(false);
        switchLeft.SetActive(false);
        switchRightFluctuate.SetActive(false);
        switchRight.SetActive(false);
        drawThreeFluctuate.SetActive(false);
        drawThree.SetActive(false);
        counterFluctuate.SetActive(false);
        counter.SetActive(false);
    }

    public void setVisible(bool boolean)
    {
        gameObject.SetActive(boolean);
    }

    public void setAllActive(bool boolean)
    {
        List<GameObject> list = getAllGameObjects();
        list.ForEach(item => item.SetActive(boolean));
    }

    private List<GameObject> getAllGameObjects()
    {
        List<GameObject> list = new List<GameObject>();
        list.Add(buffFluctuate);
        list.Add(buff);
        list.Add(discardFluctuate);
        list.Add(discard);
        list.Add(switchLeftFluctuate);
        list.Add(switchLeft);
        list.Add(switchRightFluctuate);
        list.Add(switchRight);
        list.Add(drawThreeFluctuate);
        list.Add(drawThree);
        list.Add(counterFluctuate);
        list.Add(counter);
        return list;
    }

    public void setAsBuff()
    {
        buffFluctuate.SetActive(false);
        buff.SetActive(true);
    }

    public void setAsDiscard()
    {
        discardFluctuate.SetActive(false);
        discard.SetActive(true);
    }

    public void setAsSwitchLeft()
    {
        switchLeftFluctuate.SetActive(false);
        switchLeft.SetActive(true);
    }

    public void setAsSwitchRight()
    {
        switchRightFluctuate.SetActive(false);
        switchRight.SetActive(true);
    }

    public void setAsDrawThree()
    {
        drawThreeFluctuate.SetActive(false);
        drawThree.SetActive(true);
        counter.SetActive(false);
        drawThree.GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

    public void setAsCounter()
    {
        counterFluctuate.SetActive(false);
        counter.SetActive(true);
        drawThree.SetActive(false);
        counter.GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

}
