using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2DestroByBoundary : MonoBehaviour {

    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
