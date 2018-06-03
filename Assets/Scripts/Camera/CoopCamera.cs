using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CoopCamera : MonoBehaviour
{
    [Header("Positions")]
    public List<Transform> targets;
    public Vector3 offset;
    public float smoothing = 0.5f;

    [Header("Zoom")]
    public float minZoom = 40.0f;
    public float maxZoom = 10.0f;
    public float zoomLimit = 50.0f;

    private Camera cam;
    private Vector3 velocity;

    void Start()
    {
        // Gets the camera attached to the object.
        cam = GetComponent<Camera>();

        // Finds the fire guy and adds it as a target.
        Transform fire = GameObject.FindObjectOfType<FireMotor>().transform;
        AddTarget(fire);

        // Finds the ice guy and adds it as a target.
        Transform ice = GameObject.FindObjectOfType<IceMotor>().transform;
        AddTarget(ice);
    }


    void LateUpdate()
    {
        // There's no need to carry on this function if there are no targets.
        if (targets.Count <= 0)
        {
            return;
        }

        MoveToNewPos();
        ZoomToFit();
    }


    void MoveToNewPos()
    {
        // Gets the centre point between all targets.
        Vector3 centre = GetCentre();

        // Creates a new position with the offset implemented.
        Vector3 newPos = centre + offset;

        // Smooth damps the position of the camera based on the new position.
        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, smoothing);
    }


    void ZoomToFit()
    {
        // Gets the new zoom float depending on the furthest distance between the targets (Also adds a zoom limiter).
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetFurthestDistance() / zoomLimit);

        // Sets the cameras field of view to this new zoom.
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }


    Vector3 GetCentre()
    {
        // If there's only one target, use that as the centre position.
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        // Creates a new bounding box and sets it as the first targets position with no offset.
        Bounds bounds = new Bounds(targets[0].position, Vector3.zero);

        foreach (Transform t in targets)
        {
            // Adds each target to the bounding box, making the box larger.
            bounds.Encapsulate(t.position);
        }

        // Returns the centre of the bounding box.
        return bounds.center;
    }


    float GetFurthestDistance()
    {
        // Creates a new bounding box with the first targets position and no offset.
        Bounds bounds = new Bounds(targets[0].position, Vector3.zero);
        foreach (Transform t in targets)
        {
            // Fits all targets within the bounding box.
            bounds.Encapsulate(t.position);
        }

        // If the x size is larger than y size.
        if (bounds.size.x > bounds.size.y)
        {
            // Return the largest dimension.
            return bounds.size.x;
        }
        else
        {
            // Return the largest dimension.
            return bounds.size.y;
        }
    }

    // This is for adding enemies and things to the cameras targets.
    void AddTarget(Transform trans)
    {
        targets.Add(trans);
    }
}
