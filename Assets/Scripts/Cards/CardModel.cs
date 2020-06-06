using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardModel : MonoBehaviour
{
    private int id;

    public int Id { get => id; set => id = value; }

    private void Start()
    {
        Id = IDFactory.GetUniqueID();
    }

}
