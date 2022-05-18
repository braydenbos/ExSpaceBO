using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] public Transform gen;
    [SerializeField] public Transform connect;
    [SerializeField] private wires line;

    private void Start()
    {
        line.SetUpLine(gen,connect);
    }
}
