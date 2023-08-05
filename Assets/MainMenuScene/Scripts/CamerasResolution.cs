using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CamerasResolution : MonoBehaviour
{
    public Camera MainCamera;
    public bool bIsLandScape;

    public Vector2 ReferenceResolution;

    /// <summary>
    /// Zoom factor to fit different aspect ratios
    /// </summary>
    public Vector3 ZoomFactor = Vector3.one;

    /// <summary>
    /// Design time position
    /// </summary>
    [HideInInspector]
    public Vector3 OriginPosition;

    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        OriginPosition = transform.position;

        if (bIsLandScape)
        {
            Screen.orientation = ScreenOrientation.Landscape;
            MainCamera.pixelRect = new Rect(0, 0, 1280, 720);
        }
        else
        {
            Screen.orientation = ScreenOrientation.Portrait;
            MainCamera.pixelRect = new Rect(0, 0, 480, 800);
        }
    }

    /// <summary>
    /// Update per Frame
    /// </summary>
    void Update()
    {

        if (ReferenceResolution.y == 0 || ReferenceResolution.x == 0)
            return;

        var refRatio = ReferenceResolution.x / ReferenceResolution.y;
        var ratio = (float)Screen.width / (float)Screen.height;

        transform.position = OriginPosition + transform.forward * (1f - refRatio / ratio) * ZoomFactor.z
                                            + transform.right * (1f - refRatio / ratio) * ZoomFactor.x
                                            + transform.up * (1f - refRatio / ratio) * ZoomFactor.y;


    }
}



    // Start is called before the first frame update
    //void Start()
    //{
    //    if (bIsLandScape) 
    //    {
    //        MainCamera.pixelRect = new Rect(0,0, 1280, 720);
    //        Screen.orientation = ScreenOrientation.LandscapeRight;
    //    }
    //    else
    //    {
    //        MainCamera.pixelRect = new Rect(0,0, 480, 800);
    //        Screen.orientation = ScreenOrientation.Portrait;
    //    }
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
