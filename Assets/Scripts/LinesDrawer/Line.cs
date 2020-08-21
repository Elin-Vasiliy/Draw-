using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    public Rigidbody2D rigidbody;

    [HideInInspector] public List<Vector2> points = new List<Vector2>();
    [HideInInspector] public int pointsCount = 0;

    private float pointsMinDistance = 0.1f;
    private float circleColliderRadius;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.sortingOrder = 2;
    }

    public void AddPoint(Vector2 newPoint)
    {
        if (pointsCount >= 1 && Vector2.Distance(newPoint, GetLastPoint()) < pointsMinDistance)
            return;

        points.Add(newPoint);
        pointsCount++;

        //Add Circle Collider to the Point
        CircleCollider2D circleCollider = this.gameObject.AddComponent<CircleCollider2D>();
        circleCollider.offset = newPoint;
        circleCollider.radius = circleColliderRadius;


        //Line Renderer
        lineRenderer.positionCount = pointsCount;
        lineRenderer.SetPosition(pointsCount - 1, newPoint);

        //Edge Collider
        if (pointsCount > 1)
        {
            edgeCollider.points = points.ToArray();
        }

        if (pointsCount > 1)
        {
            if (Vector2.Distance(points[pointsCount - 1], points[pointsCount - 2]) != 0)
            {
                LinesDrawer.instance.lineLength += Vector2.Distance(points[pointsCount - 1], points[pointsCount - 2]);
            }
        }
    }

    public Vector2 GetLastPoint()
    {
        return (Vector2)lineRenderer.GetPosition(pointsCount - 1);
    }

    public void UsePhysics(bool usePhysics)
    {
        rigidbody.isKinematic = !usePhysics;
    }

    public void SetLineColor(Gradient colorGradient)
    {
        lineRenderer.colorGradient = colorGradient;
    }

    public void SetPointsMinDistance(float distance)
    {
        pointsMinDistance = distance;
    }

    public void SetLineWidth(float width)
    {
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;

        circleColliderRadius = width / 2f;
        edgeCollider.edgeRadius = circleColliderRadius;
    }
}
