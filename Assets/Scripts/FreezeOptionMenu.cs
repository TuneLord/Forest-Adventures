using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeOptionMenu : MonoBehaviour
{

    public void setTimeScale(float timeScale)   //  funkcja zamrażania gry
    {
        Time.timeScale = timeScale;   // timescale = 0 to gra zatrzymana, timescale = 1 to gra odfreezowana
    }

    void Start()
    {

    }


    void Update()
    {

    }
}
