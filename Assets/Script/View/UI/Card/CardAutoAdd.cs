using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAutoAdd : MonoBehaviour
{
    [SerializeField] int AddRepeatingTime;
    private void Start()
    {
        InvokeRepeating("AutoAdd", AddRepeatingTime, AddRepeatingTime);
    }
    void AutoAdd()
    {
        CardControll.instance.GiveToPlayerCard();
    }
}
