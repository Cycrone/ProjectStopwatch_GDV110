using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowmoTime : MonoBehaviour
{
    public Slider slowMo;
    public TimeController t;
    public void UpdateSlowmoTimer()
    {
        slowMo.value = t.slowMoTime;
        slowMo.maxValue = t.slowMoTimer;
    }
    
}
