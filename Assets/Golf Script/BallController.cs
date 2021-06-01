using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float Power;
    public Rigidbody Ball;

    public Vector2 MinimumPower;
    public Vector2 MaximumPower;
    public LineRenderer Line;
    Camera _camera;
    Vector3 _ballForce;
    Vector3 _startPoint;
    Vector3 _endPoint;
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startPoint = _camera.ScreenToWorldPoint(Input.mousePosition);            
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 _currentPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            DrawLine(_startPoint, _currentPosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            _endPoint = _camera.ScreenToWorldPoint(Input.mousePosition);

            //_ballForce = new Vector2(Mathf.Clamp(_startPoint.x - _endPoint.x, MinimumPower.x, MaximumPower.x));
            //Ball.AddForce(_ballForce * ballpower, ForceMode2D.Impulse);
        }
    }

    void DrawLine(Vector3 startPoint, Vector3 endPoint)
    {
        Line.positionCount = 2;
        Vector3[] allPoint = new Vector3[2];
        allPoint[0] = startPoint;
        allPoint[1] = endPoint;
        Line.SetPositions(allPoint);
    }
}
