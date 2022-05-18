using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wires : MonoBehaviour
{
    private LineRenderer lR;
    private Transform from;
    private Transform to;
    private void Awake()
    {
        lR = GetComponent<LineRenderer>();
    }
    public void SetUpLine(Transform from , Transform to)
    {
        lR.positionCount = 2;
        this.from = from;
        this.to = to;
    }
    private void Update()
    {
        lR.SetPosition(0, from.position);
        lR.SetPosition(1, to.position);
    }
}
