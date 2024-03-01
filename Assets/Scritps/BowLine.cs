using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowLine : MonoBehaviour
{
    public Transform StartPos;
    public Transform EndPos;
    public Transform ArrowPos;
    public Material Material;
    public Color Color;

    LineRenderer _line1;
    LineRenderer _line2;
    GameObject _obj1;
    GameObject _obj2;

    private void Start()
    {
        _obj1 = new GameObject();
        _obj1.AddComponent<LineRenderer>();
        _line1 = _obj1.GetComponent<LineRenderer>();
        _line1.startWidth = 0.02f;
        _line1.endWidth = 0.02f;
        _line1.material = Material;
        _line1.startColor = Color;
        _line1.endColor = Color;
        _obj1.name = "Line_01";

        _obj2 = new GameObject();
        _obj2.AddComponent<LineRenderer>();
        _line2 = _obj2.GetComponent<LineRenderer>();
        _line2.startWidth = 0.02f;
        _line2.endWidth = 0.02f;
        _line2.material = Material;
        _line2.startColor = Color;
        _line2.endColor = Color;
        _obj2.name = "Line_02";
    }

    private void Update()
    {
        _line1.SetPosition(0,StartPos.position);
        _line1.SetPosition(1,ArrowPos.position);
        _line2.SetPosition(0,ArrowPos.position);
        _line2.SetPosition(1,EndPos.position);
    }
}
