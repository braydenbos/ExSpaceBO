using System.Collections.Generic;
using UnityEngine;

public class wires : MonoBehaviour
{
    public Transform to;
    public Transform to2;
    public Transform from;
    private LineRenderer rope;
    public LayerMask collMask;
    public List<Vector3> ropePositions { get; set; } = new List<Vector3>();
    private void Awake() => AddPosToRope(Vector2.zero);
    private void Start()
    {
        rope = GetComponent<LineRenderer>();
    }
    private void Update()
    {
        UpdateRopePositions();
        LastSegmentGoToPlayerPos();
        rope.SetPosition(0, from.position);
        DetectCollisionEnter();
        if (ropePositions.Count > 2) DetectCollisionExits();
    }
    private void DetectCollisionEnter()
    {
        RaycastHit hit;
        if (Physics.Linecast(to2.position, rope.GetPosition(ropePositions.Count - 2) , out hit, collMask) && Physics.Linecast(to.position, rope.GetPosition(ropePositions.Count - 2), out hit, collMask))
        {
            if (rope.GetPosition(ropePositions.Count - 2) != hit.point)
            {
                ropePositions.RemoveAt(ropePositions.Count - 1);
                AddPosToRope(hit.point);
            }
        }
    }
    private void DetectCollisionExits()
    {
        RaycastHit hit;
        if (!Physics.Linecast(to.position, rope.GetPosition(ropePositions.Count - 3), out hit, collMask))
        {
            ropePositions.RemoveAt(ropePositions.Count - 2);
        }
    }
    private void AddPosToRope(Vector2 _pos)
    {
        ropePositions.Add(_pos);
        ropePositions.Add(to2.position);
    }
    private void UpdateRopePositions()
    {
        rope.positionCount = ropePositions.Count;
        rope.SetPositions(ropePositions.ToArray());
    }
    private void LastSegmentGoToPlayerPos() => rope.SetPosition(rope.positionCount - 1, to.position);
}