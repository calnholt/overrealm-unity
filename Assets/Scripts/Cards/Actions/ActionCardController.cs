using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionCardController : MonoBehaviour
{
    List<BuffCardModel> appliedBuffs = new List<BuffCardModel>();
    List<BuffCardModel> appliedDiscards = new List<BuffCardModel>();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Draggable draggable = collision.gameObject.GetComponent<Draggable>();
        if (!draggable) return;
        BuffCardModel buff = collision.gameObject.GetComponentInChildren<BuffCardModel>();
        if (buff)
        {

        }
    }
}
