using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Closed" || other.tag == "SpawnPoint")
        {
            Destroy(other.gameObject);
        }
    }
}
