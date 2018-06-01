using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS IS GONNA BE REPLACED WITH A BETTER ONE.
public class FollowCam : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float followSpeed;	

	void LateUpdate ()
    {
        transform.position = new Vector3
            (
            Mathf.Lerp(transform.position.x, (target.position.x + offset.x), followSpeed * Time.deltaTime),
            target.position.y + offset.y,
            Mathf.Lerp(transform.position.z, (target.position.z + offset.z), followSpeed * Time.deltaTime)
            );
	}
}
