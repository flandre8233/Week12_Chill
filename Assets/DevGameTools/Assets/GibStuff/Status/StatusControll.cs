using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusControll : SingletonMonoBehavior<StatusControll>
{
    IStatus NowStatus;

    private void Start()
    {
        CanvasControll.instance.Start();
        ToNewStatus(new ReadyStatus());
    }

    public static void ToNewStatus(IStatus NewStatus)
    {
        if (instance.NowStatus != NewStatus && instance.NowStatus != null)
        {
            instance.NowStatus.ExitStatus();
        }
        instance.NowStatus = NewStatus;
        instance.NowStatus.Start();
        CanvasControll.instance.SwitchCanvas(instance.NowStatus);
    }

    private void Update()
    {
        if (NowStatus != null)
        {
            NowStatus.Update();
        }
    }

    public static void ClearStatus()
    {
        instance.NowStatus = null;
    }

    IStatus GetCur()
    {
        return NowStatus;
    }

    public bool IsStatusEqual(System.Type SomeStatus)
    {
        return GetCur().GetType() == SomeStatus;
    }
}
