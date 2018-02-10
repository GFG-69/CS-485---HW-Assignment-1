using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2StayOnGrid : MonoBehaviour {

    private Rigidbody rb;

	void Update () {
        rb = GetComponent<Rigidbody>();
        Vector3 position = new Vector3(rb.position.x, 0, rb.position.z);
        rb.position = position;
	}
}
