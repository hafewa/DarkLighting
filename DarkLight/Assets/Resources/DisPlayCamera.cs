
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisPlayCamera:MonoBehaviour
{
    public Camera _WindowCamera;
    public RenderTexture _windowTexture;

    private static DisPlayCamera instance;
    public delegate void deleSetText(GameObject go);
    public deleSetText OnSetText;
    public static DisPlayCamera Instance
    {
        get { return instance = instance ?? new DisPlayCamera(); }
    }

    public void InitWindowCamera()
    {
        _windowTexture = Resources.Load<RenderTexture>("Window");
        _WindowCamera = new GameObject("WindowCamera").AddComponent<Camera>();
        _WindowCamera.clearFlags = CameraClearFlags.SolidColor;
        _WindowCamera.orthographic = true;
        _WindowCamera.orthographicSize = 0.2f;
        _WindowCamera.nearClipPlane = 0f;
        _WindowCamera.farClipPlane = 0.8f;
        _WindowCamera.targetTexture = _windowTexture;
    }
    //public void SetWindowCameraPos(GameObject target)
    //{
    //    if (OnSetText != null)
    //    {
    //        OnSetText(target);
    //    }
    //    switch (target.gameObject.tag)
    //    {
    //        case "BP":
    //            _WindowCamera.orthographicSize = 0.08f;
    //            _WindowCamera.gameObject.transform.SetParent(target.transform.GetChild(0));
    //            _WindowCamera.gameObject.transform.localPosition = new Vector3(0, 0.25f, 0f);
    //            _WindowCamera.gameObject.transform.localEulerAngles = new Vector3(90, 0f, 0f);
    //            //_WindowCamera.gameObject.transform.rotation =
    //            //    Quaternion.LookRotation(
    //            //        (target.transform.GetChild(0).transform.position - _WindowCamera.gameObject.transform.position));
    //            break;
    //        case "YWBP":
    //            _WindowCamera.orthographicSize = 0.2f;
    //            _WindowCamera.gameObject.transform.SetParent(target.transform.GetChild(0));
    //            _WindowCamera.gameObject.transform.localPosition = new Vector3(0, -0.5f, 0.8f);
    //            _WindowCamera.gameObject.transform.localEulerAngles = new Vector3(-90f, -90f, -90f);
    //            break;
    //    }
    //}
}
