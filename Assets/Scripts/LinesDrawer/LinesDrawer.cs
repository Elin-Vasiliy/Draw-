using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesDrawer : MonoBehaviour
{
    public static LinesDrawer instance;

    public GameObject linePrefab;
    public LayerMask cantDrawOverLayer;
    int cantDrawOverLayerIndex;

    [Space(30f)]
    public Gradient lineColor;
    public float linePointsMinDistance;
    public float lineWidth;

    public bool isGame;
    public GameObject[] Balles;

    Line currentLine;
    Camera cam;

    private float _lineLength;
    public float lineLength
    {
        get
        {
            return _lineLength;
        }
        set
        {
            _lineLength = value;
        }
    }

    [SerializeField] private float _maxLineLength;
    public float maxLineLength
    {
        get
        {
            return _maxLineLength;
        }
    }

    private int _currentPoint;
    public int currentPoint 
    {
        get
        {
            return _currentPoint;
        }
        set
        {
            _currentPoint = currentPoint;
        }
    }

    private void Start()
    {
        instance = this;

        cam = Camera.main;
        cantDrawOverLayerIndex = LayerMask.NameToLayer("CantDrawOver");
    }

    private void Update()
    {
        if (_lineLength < _maxLineLength && !isGame)
        {
            if (Input.GetMouseButtonDown(0))
            {
                BeginDraw();
            }

            if (currentLine != null)
            {
                Draw();
            }

            if (Input.GetMouseButtonUp(0))
            {
                EndDraw();
            }
        }
        else
        {
            EndDraw();
        }
    }

    private void BeginDraw()
    {
        currentLine = Instantiate(linePrefab, this.transform).GetComponent<Line>();

        currentLine.UsePhysics(false);
        currentLine.SetLineColor(lineColor);
        currentLine.SetPointsMinDistance(linePointsMinDistance);
        currentLine.SetLineWidth(lineWidth);

        //_currentPoint = 2;
    }

    private void Draw()
    {
        Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.CircleCast(mousePosition, lineWidth / 3f, Vector2.zero, 1f, cantDrawOverLayer);

        if (hit)
        {
            EndDraw();
        }
        else
        {
            currentLine.AddPoint(mousePosition);
        }

        currentLine.AddPoint(mousePosition);
    }

    private void EndDraw()
    {
        if (currentLine != null)
        {
            if (currentLine.pointsCount < 2)
            {
                //If line has one point
                Destroy(currentLine.gameObject);
            }
            else
            {
                currentLine.gameObject.layer = cantDrawOverLayerIndex;
                currentLine.UsePhysics(true);
                currentLine = null;

                UpMouseClick();
            }            
        }
    }

    private void UpMouseClick()
    {
        for (int i = 0; i < Balles.Length; i++)
        {
            Balles[i].GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }
}
