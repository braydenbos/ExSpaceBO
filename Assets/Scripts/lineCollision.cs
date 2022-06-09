using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(wires), typeof(PolygonCollider2D))]

public class lineCollision : MonoBehaviour
{
    wires wires;
    PolygonCollider2D collider;

    List<Vector2> colliderPoints = new List<Vector2>();
    void Start()
    {
        wires = GetComponent<wires>();
        collider = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        colliderPoints = calculateColliderPoints();
        collider.SetPath(0, colliderPoints.ConvertAll(p => (Vector2)transform.InverseTransformPoint(p)));

    }

    private List<Vector2> calculateColliderPoints()
    {
        Vector3[] positions = wires.GetPositions();

        float width = wires.GetWidth();

        float m = (positions[1].y - positions[0].y) / (positions[1].x - positions[0].x);
        float deltaX = (width / 2f) * (m / Mathf.Pow(m * m + 1, 0.5f));
        float deltaY = (width / 2f) * (1 / Mathf.Pow(1 + m * m, 0.5f));

        Vector3[] offsets = new Vector3[2];
        offsets[0] = new Vector3(-deltaX , deltaY);
        offsets[1] = new Vector3(deltaX , -deltaY);


        List<Vector2> colliderPositions = new List<Vector2>
        {
            positions[0] + offsets[0],
            positions[1] + offsets[0],
            positions[1] + offsets[1],
            positions[0] + offsets[1]
        };
        int num = 0;
        foreach (Vector3 p in positions)
        {
            num++;
            if (num > 1 && num < positions.Length)
            {
                colliderPositions.Insert(num * 2 - 2, positions[num] + offsets[0]);
                colliderPositions.Insert(num * 2 - 1, positions[num] + offsets[1]);
            }
        }

        return colliderPositions;
    }
}
