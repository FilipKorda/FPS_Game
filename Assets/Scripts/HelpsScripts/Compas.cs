using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compas : MonoBehaviour
{
    public RectTransform compasBarTransform;

    public RectTransform Marker;
    public RectTransform NorthMarker;
    public RectTransform SouthMarker;

    public Transform cameraObjectTransform;
    public Transform objectiveObjectTransform;


    void Update() 
    {
        SetMarkerPosition(Marker, objectiveObjectTransform.position);
        SetMarkerPosition(NorthMarker, Vector3.forward * 1000);
        SetMarkerPosition(SouthMarker, Vector3.back * 1000);
    }

    private void SetMarkerPosition(RectTransform markerTransform, Vector3 worldPosition)
    {
        Vector3 directionToTarget = worldPosition - cameraObjectTransform.position;
        float angle = Vector2.SignedAngle(new Vector2(directionToTarget.x, directionToTarget.z), new Vector2(cameraObjectTransform.transform.forward.x, cameraObjectTransform.transform.forward.z));
        float compasPositionX = Mathf.Clamp(2* angle/ Camera.main.fieldOfView, -1, 1);
        markerTransform.anchoredPosition = new Vector2(compasBarTransform.rect.width / 2 * compasPositionX, 0);
    }
}