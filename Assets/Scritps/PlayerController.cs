using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ArrowController ArrPrefab;
    public float DragCtr;
    public float FireForce;
    public Transform ArrowPoint;
    public Transform ArrowSpawnPoint;
    public Transform ArrowDirection;

    public float _minLimited;
    public float _maxLimited;
    Vector2 _dragForce1;
    Vector2 _dragForce2;
    float _dragDistance;
    bool _isDragging;
    ArrowController _arrowClone;

    private void Start()
    {
        SpanwArrow();
    }

    private void Update()
    {
        if (GameManage.Ins.State != GameManage.GameState.Playing) return;

        if (Input.GetButtonDown("Fire1"))
        {
            _isDragging = true;
            _dragForce1 = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            _isDragging = false;
            ArrowPoint.localPosition = new Vector3 (_maxLimited,0f,0f);
            ArrowDirection.localScale = new Vector3(0, 0, 0);
            if(_dragDistance > 0.1f) {
                Fire();
            }
        }

        if(_isDragging)
        {
            _dragForce2 = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            _dragDistance = Vector2.Distance(_dragForce1,_dragForce2)*DragCtr;
            if (_dragDistance < 0.05f) return;

            var dragDir = new Vector2(_dragForce1.x - _dragForce2.x,_dragForce1.y - _dragForce2.y);
            float alpha = Mathf.Atan2(dragDir.y, dragDir.x)*Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0,0,alpha);

            float dragX = _maxLimited - _dragDistance;
            dragX = Mathf.Clamp(dragX,_minLimited,_maxLimited);
            ArrowPoint.localPosition = new Vector3(dragX,0,0);

            float dirPointScaleX = Mathf.Clamp(_dragDistance, 0, 0.5f) * 2;
            ArrowDirection.localScale = new Vector3 (dirPointScaleX,1,1);
        }


    }

    void SpanwArrow()
    {
        if(ArrPrefab == null)  return; 

        _arrowClone = Instantiate(ArrPrefab);
        _arrowClone.transform.SetParent(ArrowSpawnPoint,false);
        _arrowClone.transform.localScale = Vector3.one;
        _arrowClone.transform.localPosition = Vector3.zero;
    }

    IEnumerator SpawnNextArrow(float time)
    {
        yield return new WaitForSeconds(time);
        SpanwArrow();
    }

    public void Fire()
    {
        if (_arrowClone == null) return;

        float currentForce = Mathf.Clamp(_dragDistance,0,0.5f) * FireForce;
        _arrowClone.Fire(currentForce);
        StartCoroutine(SpawnNextArrow(0.2f));
    }
}
