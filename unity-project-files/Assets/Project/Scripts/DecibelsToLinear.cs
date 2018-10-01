using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecibelsToLinear
{
    public float DBToLinear(float dB)
    {
        float linear = Mathf.Pow(10.0f, dB / 20.0f);

        return linear;
    }

}
