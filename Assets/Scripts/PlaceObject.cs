using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

[RequireComponent(requiredComponent: typeof(ARRaycastManager),
requiredComponent2: typeof(ARPlaneManager))]
public class PlaceObject : MonoBehaviour
{

    [SerializeField] private GameObject prefab;
    private ARRaycastManager aRRaycastManager;
    private ARPlaneManager aRPlaneManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        Debug.Log("AWAKE");

        aRRaycastManager = GetComponent<ARRaycastManager>();
        aRPlaneManager = GetComponent<ARPlaneManager>();
        onEnable();
    }

    private void onEnable()
    {
        Debug.Log("onEnable");

        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();
        EnhancedTouch.Touch.onFingerDown += FingerDown;
    }

    private void onDisable()
    {
        Debug.Log("onDisable");

        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.EnhancedTouchSupport.Disable();
        EnhancedTouch.Touch.onFingerDown -= FingerDown;
    }

    private void FingerDown(EnhancedTouch.Finger finger)
    {
        if (finger.index != 0) return; //disable multitouch

        if (aRRaycastManager.Raycast(finger.currentTouch.screenPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            foreach (ARRaycastHit hit in hits)
            {

                Pose pose = hit.pose;
                GameObject obj = Instantiate(prefab, pose.position, pose.rotation);

                if (aRPlaneManager.GetPlane(trackableId: hit.trackableId).alignment == PlaneAlignment.HorizontalUp)
                {
                    UnityEngine.Vector3 position = obj.transform.position;
                    position.y = 0f;
                    UnityEngine.Vector3 cameraPosition = Camera.main.transform.position;
                    cameraPosition.y = 0f;

                    UnityEngine.Vector3 direction = cameraPosition - position;
                    UnityEngine.Quaternion targetRotation = UnityEngine.Quaternion.LookRotation(direction);
                    obj.transform.rotation = targetRotation;
                }


            }
        }
    }
}
