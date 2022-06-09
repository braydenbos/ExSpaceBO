using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wires : MonoBehaviour
{
    LineRenderer lR;
    [SerializeField] List<Transform> nodes;


    private void Awake()
    {
        lR = GetComponent<LineRenderer>();
        lR.positionCount = nodes.Count;

    }
    private void Update()
    {
        lR.SetPositions(nodes.ConvertAll(n => n.position - new Vector3(0, 0, 5)).ToArray());
    }
    public Vector3[] GetPositions()
    {
        Vector3[] positions = new Vector3[lR.positionCount];
        lR.GetPositions(positions);
        return positions;
    }
    public float GetWidth()
    {
        return lR.startWidth;
    }
}
