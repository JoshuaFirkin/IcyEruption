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
        cam = GetComponent<Camera>();

        Transform fire = GameObject.FindObjectOfType<FireMotor>().transform;
        AddTarget(fire);

        Transform ice = GameObject.FindObjectOfType<IceMotor>().transform;
        AddTarget(ice);
    }

    void LateUpdate()
    {
        if (targets.Count <= 0)
        {
            return;
        }

        MoveToNewPos();
        ZoomToFit();
    }

    void MoveToNewPos()
    {
        Vector3 centre = GetCentre();
        Vector3 newPos = centre + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, smoothing);
    }

    void ZoomToFit()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetFurthestDistance() / zoomLimit);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    Vector3 GetCentre()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        Bounds bounds = new Bounds(targets[0].position, Vector3.zero);
        foreach (Transform t in targets)
        {
            bounds.Encapsulate(t.position);
        }

        return bounds.center;
    }

    float GetFurthestDistance()
    {
        Bounds bounds = new Bounds(targets[0].position, Vector3.zero);
        foreach (Transform t in targets)
        {
            bounds.Encapsulate(t.position);
        }

        if (bounds.size.x > bounds.size.y)
        {
            return bounds.size.x;
        }
        else
        {
            return bounds.size.y;
        }
    }

    void AddTarget(Transform trans)
    {
        targets.Add(trans);
    }
}
