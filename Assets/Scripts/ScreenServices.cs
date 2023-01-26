using UnityEngine;

public class ScreenServices
{
    public Vector3 GetTopScreenCenterPoint(Camera camera, float deep) =>
        ScreenToPoint(camera, new Vector3(Screen.width / 2, Screen.height, deep));

    public Vector3 GetDownScreenCenterPoint(Camera camera, float deep) =>
        ScreenToPoint(camera, new Vector3(Screen.width / 2, 0, deep));

    public Vector3 GetRightScreenCenterPoint(Camera camera, float deep) =>
        ScreenToPoint(camera, new Vector3(Screen.width, Screen.height / 2, deep));

    public Vector3 GetLeftScreenCenterPoint(Camera camera, float deep) =>
        ScreenToPoint(camera, new Vector3(0, Screen.height / 2, deep));

    private Vector3 ScreenToPoint(Camera camera, Vector3 vector) => 
        camera.ScreenToWorldPoint(vector);

}
