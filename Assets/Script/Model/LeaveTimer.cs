using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class LeaveTimer : SingletonMonoBehavior<LeaveTimer>
{
    public DateTime LeaveGameDateTime = new DateTime();
    DateTime EnterGameDateTime = new DateTime();
    TimeSpan TimePassed = new TimeSpan();

    // Start is called before the first frame update
    void Start()
    {
        EnterGameDateTime = DateTime.UtcNow;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TimePassed = EnterGameDateTime - LeaveGameDateTime;
            print(TimePassed.ToString("hh':'mm':'ss"));
        }
    }

    public int GetTimePassed()
    {
        TimeSpan TimePassed = EnterGameDateTime - LeaveGameDateTime;
        return (int)TimePassed.TotalSeconds;
    }

}
