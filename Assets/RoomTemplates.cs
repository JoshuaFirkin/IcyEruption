using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoomTemplates : MonoBehaviour {

    public NavMeshSurface navMeshSurface;

    private bool loadedLevel = false;

    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom;

    public List<GameObject> rooms;

    public float waitTime = 2f;

    private void Update()
    {
        if (loadedLevel)
        {
            navMeshSurface.BuildNavMesh();
        }

        if (waitTime <= 0 && loadedLevel == false)
        {
            loadedLevel = true;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
