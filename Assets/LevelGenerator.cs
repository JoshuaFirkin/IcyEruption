using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelGenerator : MonoBehaviour {

    public int openingDirection;
    // 1 --> bottom Door
    // 2 --> top Door
    // 3 --> left Door
    // 4 --> right Door

    private RoomTemplates templates;
    private int randomInd;

    public bool spawned = false;

    public float waitTime = 4f;

	// Use this for initialization
	void Start () {

        Destroy(gameObject, waitTime);

        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();

        Invoke("GenerateRooms", 0.1f);
	}

    private void Update()
    {
        //GenerateRooms();
    }

    // Update is called once per frame
    void GenerateRooms() {

        if (!spawned)
        {
            if (openingDirection == 1)
            {
                //NEED: to spawn a room with a BOTTOM door

                randomInd = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[randomInd], transform.position, templates.bottomRooms[randomInd].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                //NEED: to spawn a room with a TOP door

                randomInd = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[randomInd], transform.position, templates.topRooms[randomInd].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                //NEED: to spawn a room with a LEFT door

                randomInd = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[randomInd], transform.position, templates.leftRooms[randomInd].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                //NEED: to spawn a room with a RIGHT door

                randomInd = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[randomInd], transform.position, templates.rightRooms[randomInd].transform.rotation);
            }

            spawned = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != null && this.gameObject != null)
        {
            if (other.CompareTag("SpawnPoint"))
            {
                if (other.gameObject.GetComponent<LevelGenerator>().spawned == false && spawned == false)
                {
                    Vector3 offset = new Vector3(0, 0.5f, 0);

                    Instantiate(templates.closedRoom, transform.position + offset, Quaternion.identity);

                    Destroy(gameObject);
                }

                spawned = true;
            }
        }
    }
}

