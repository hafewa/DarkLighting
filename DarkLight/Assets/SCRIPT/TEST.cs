using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TEST : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private GameObject IM;
    public void OnBeginDrag(PointerEventData eventData)
    {

        IM = new GameObject("clone");
        IM.AddComponent<Image>().sprite = GetComponent<Image>().sprite; ;
        IM.transform.SetParent(transform.root);
        IM.transform.SetAsLastSibling();
        RectTransform s = IM.GetComponent<RectTransform>();
        s.position = transform.GetComponent<RectTransform>().position;
        IM.transform.position = transform.position;
        IM.GetComponent<Image>().raycastTarget = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerPressRaycast.gameObject.GetComponent<Image>().sprite != null)
        {
            SetDraggedPosition(eventData);
            // IM.transform.position = Input.mousePosition;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerPressRaycast);
        Debug.Log(eventData.pointerCurrentRaycast);
        IM.transform.SetParent(eventData.pointerEnter.gameObject.transform);
        IM.transform.SetAsLastSibling();
        if (eventData.pointerEnter != null && eventData.pointerEnter.tag != "wai" && eventData.pointerPressRaycast.gameObject.GetComponent<Image>().sprite != null)
        #region //{
        //    if (eventData.pointerEnter.gameObject.name=="武器")
        //    {
        //        if (IM.GetComponent<Image>().sprite.name=="武器")
        //        {
        //            Sprite s = eventData.pointerEnter.gameObject.GetComponent<Image>().sprite;
        //            eventData.pointerEnter.gameObject.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
        //            GetComponent<Image>().sprite = s;
        //        }

        //    }
        //    if (eventData.pointerEnter.gameObject.name == "上衣")
        //    {
        //        if (IM.GetComponent<Image>().sprite.name == "上衣")
        //        {
        //            Sprite s = eventData.pointerEnter.gameObject.GetComponent<Image>().sprite;
        //            eventData.pointerEnter.gameObject.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
        //            GetComponent<Image>().sprite = s;
        //        }

        //    }
        //    if (eventData.pointerEnter.gameObject.name == "下装")
        //    {
        //        if (IM.GetComponent<Image>().sprite.name == "下装")
        //        {
        //            Sprite s = eventData.pointerEnter.gameObject.GetComponent<Image>().sprite;
        //            eventData.pointerEnter.gameObject.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
        //            GetComponent<Image>().sprite = s;
        //        }

        //    }
        //    if (eventData.pointerEnter.gameObject.name == "腰带")
        //    {
        //        if (IM.GetComponent<Image>().sprite.name == "腰带")
        //        {
        //            Sprite s = eventData.pointerEnter.gameObject.GetComponent<Image>().sprite;
        //            eventData.pointerEnter.gameObject.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
        //            GetComponent<Image>().sprite = s;
        //        }

        //    }
        //    if (eventData.pointerEnter.gameObject.name == "头肩")
        //    {
        //        if (IM.GetComponent<Image>().sprite.name == "头肩")
        //        {
        //            Sprite s = eventData.pointerEnter.gameObject.GetComponent<Image>().sprite;
        //            eventData.pointerEnter.gameObject.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
        //            GetComponent<Image>().sprite = s;
        //        }

        //    }
        //    if (eventData.pointerEnter.gameObject.name == "鞋子")
        //    {
        //        if (IM.GetComponent<Image>().sprite.name == "鞋子")
        //        {
        //            Sprite s = eventData.pointerEnter.gameObject.GetComponent<Image>().sprite;
        //            eventData.pointerEnter.gameObject.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
        //            GetComponent<Image>().sprite = s;
        //        }

        //    }

        //}
        //else
        //{
        // if ((eventData.pointerEnter != null))
        #endregion     // {
        {
            if (eventData.pointerEnter.gameObject.GetComponent<Image>().sprite != null)
            {
                Sprite s = eventData.pointerEnter.gameObject.GetComponent<Image>().sprite;
                eventData.pointerEnter.gameObject.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
                GetComponent<Image>().sprite = s;
            }
            else
            {
                eventData.pointerPressRaycast.gameObject.transform.position = eventData.pointerEnter.gameObject.transform.position;
                // GetComponent<Image>().sprite = null;
                transform.SetParent(eventData.pointerEnter.transform);
                transform.position = eventData.pointerEnter.gameObject.transform.position;
                eventData.pointerEnter.gameObject.transform.SetAsFirstSibling();
            }
        }
        Destroy(IM);
    }
    private void SetDraggedPosition(PointerEventData eventData)
    {
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(IM.GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out globalMousePos))
        {
            IM.transform.position = globalMousePos;
        }
    }
}
