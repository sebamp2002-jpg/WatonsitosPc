using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Items : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public enum TipoItem { Bolsa, Agua }
    public TipoItem tipo;
    public RectTransform ZonaSoltable; 

    private RectTransform rect;
    private Vector3 posicionOriginal;
    private Canvas canvas;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        posicionOriginal = rect.localPosition;
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        
        if (RectTransformUtility.RectangleContainsScreenPoint(ZonaSoltable, Input.mousePosition))
        {
            UsarItem();
        }

       
        rect.localPosition = posicionOriginal;
    }

    void UsarItem()
    {
        if (tipo == TipoItem.Bolsa)
        {
            Debug.Log("Usando bolsa");
            FindAnyObjectByType<PerroCaca>()?.Limpiar();
        }
        else if (tipo == TipoItem.Agua)
        {
            Debug.Log("Usando agua");
            FindAnyObjectByType<PerroAgua>()?.DarAgua();
        }
        FindAnyObjectByType<Inventario>().PanelInventario.SetActive(false);
        Time.timeScale = 1f;
    }
}
