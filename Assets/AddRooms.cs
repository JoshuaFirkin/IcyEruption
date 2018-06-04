using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRooms : MonoBehaviour {

    private RoomTemplates templates;

	// Use this for initialization
	void Start () {

        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();

        templates.rooms.Add(this.gameObject);
	}
}
