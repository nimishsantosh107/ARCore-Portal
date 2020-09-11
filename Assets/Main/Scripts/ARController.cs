using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class ARController : MonoBehaviour
{

    private List<DetectedPlane> mDetectedPlanesList = new List<DetectedPlane>();

    public GameObject GridPrefab;
    public GameObject Portal;
    public GameObject ARCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check ARCore Session Status (Quit if not working)
        if(Session.Status != SessionStatus.Tracking){return;}

        // Fill list with newly detected planes 
        // List cleared each frame and re run
        Session.GetTrackables<DetectedPlane>(mDetectedPlanesList, TrackableQueryFilter.New);

        // Instantiate new grid for each new detected plane in a frame
        for (int i = 0; i < mDetectedPlanesList.Count; i++)
        {
            GameObject grid = Instantiate(GridPrefab, Vector3.zero, Quaternion.identity, transform);

            // Sets position of grid and modifies veritices of the mesh
            grid.GetComponent<GridVisualizer>().Initialize(mDetectedPlanesList[i]);
        }

        Touch touch;
        // If not touched go to next frame
        if(Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began) {return;}

        // If touched point is any of the tracked plane
        TrackableHit hit;
        if(Frame.Raycast(touch.position.x, touch.position.y, TrackableHitFlags.PlaneWithinPolygon, out hit)){
            // Lets place the portal on detected plane and enable it
            Portal.SetActive(true);

            // Create anchor
            Anchor anchor = hit.Trackable.CreateAnchor(hit.Pose);

            // Set position of portal the same as the hit position
            Portal.transform.position = hit.Pose.position;
            Portal.transform.rotation = hit.Pose.rotation;

            // We need portal to face the camera
            Vector3 cameraPosition = ARCamera.transform.position;

            // Need to only rotate around y axis
            cameraPosition.y = hit.Pose.position.y;
            Portal.transform.LookAt(cameraPosition, Portal.transform.up);

            // Attach portal to anchor so that when ARCore moves around, the portal is on the anchor
            Portal.transform.parent = anchor.transform;
        }
    }
}
