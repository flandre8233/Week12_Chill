using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CanvasControll : SingletonMonoBehavior<CanvasControll>
{
    GameObject[] Canvass;
    Dictionary<Type, int> IndexDict;

    public void Start()
    {
        Canvass = GetAllChild();
        BindingCanvas();
    }

    GameObject[] GetAllChild()
    {
        List<GameObject> AllChild = new List<GameObject>();
        foreach (Transform item in transform)
        {
            AllChild.Add(item.gameObject);
        }
        return AllChild.ToArray();
    }

    void BindingCanvas()
    {
        IndexDict = new Dictionary<Type, int>();
        IndexDict.Add(new ReadyStatus().GetType(), 0);
        IndexDict.Add(new GameStatus().GetType(), 1);
    }

    public void SwitchCanvas(IStatus CurrentStatus)
    {
        int WantedIndex = IndexDict[CurrentStatus.GetType()];
        for (int i = 0; i < Canvass.Length; i++)
        {
            Canvass[i].SetActive(i == WantedIndex);
        }
    }

}
