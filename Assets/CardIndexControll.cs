using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardIndexControll : MonoBehaviour
{
    static List<int> IndexList;

    private void Start()
    {
        IndexList = new List<int>();
        IndexList.Add(1);
        IndexList.Add(2);
        IndexList.Add(3);
        IndexList.Add(4);
        IndexList.Add(5);
        IndexList.Add(6);
        IndexList.Add(7);
    }

    public static void AddIndex(int NewIndex)
    {
        IndexList.Add(NewIndex);
    }

    public static int GetCardIndex()
    {
        int CardIndex = IndexList[0];
        IndexList.RemoveAt(0);
        return CardIndex;
    }
}
