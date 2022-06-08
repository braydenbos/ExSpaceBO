using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wires : MonoBehaviour
{
    private LineRenderer lR;
    [SerializeField] public Transform gen;
    [SerializeField] public Transform connect;

    private void Awake()
    {
        lR = GetComponent<LineRenderer>();
    }
    private void Update()
    {
        lR.SetPosition(0, gen.position);
        lR.SetPosition(1, connect.position);
    }
}
