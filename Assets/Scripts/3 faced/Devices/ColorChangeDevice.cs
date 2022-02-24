using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeDevice : DeviceInterface
{
    public override void Start()
    {
    }
    public override void Operate()
    {
        Color random = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        GetComponent<Renderer>().material.color = random;
    }
}
