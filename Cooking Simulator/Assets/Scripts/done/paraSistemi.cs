using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class paraSistemi : MonoBehaviour
{
    public int para = 20;

    public int[] maliyet;
    public int[] kar;

    public Text paraGosterici;

    public void Update()
    {
        paraGosterici.text = para + "tl";

        if(Input.GetKeyDown(KeyCode.K))
        {
            para = para + 50;
        }
    }
}
