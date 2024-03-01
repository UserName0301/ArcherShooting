using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class BtnZoomIn_Out : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float SizeNormal;
    public float SizeSmall;

    private void Start()
    {
        transform.localScale = new Vector3(SizeNormal, SizeNormal, SizeNormal);
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        transform.DOScale(new Vector3(SizeNormal, SizeNormal, SizeNormal), 0.1f);
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        transform.DOScale(new Vector3(SizeSmall, SizeSmall, SizeSmall), 0.1f);
    }
}
