using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMapPositionStarter : MonoBehaviour
{
    [SerializeField]
    MouseMapPosition positionView;
    // Start is called before the first frame update
    void Start()
    {
        positionView.enabled = false;
        Invoke("Show", 5f);
    }

    void Show()
    {
        positionView.enabled = true;
    }
}
