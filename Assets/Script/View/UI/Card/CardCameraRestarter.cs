using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCameraRestarter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Camera>().enabled = false;
        Invoke("Restart", 0.1f);
    }

    void Restart()
    {
        GetComponent<Camera>().enabled = true;
    }
}
