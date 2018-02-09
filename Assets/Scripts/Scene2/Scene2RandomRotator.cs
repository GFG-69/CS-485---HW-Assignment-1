using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2RandomRotator : MonoBehaviour {

    public float tumble;

    private Rigidbody rb;

	void Start ()
    {
        rb = GetComponent<Rigidbody> ();
        rb.angularVelocity = Random.insideUnitSphere * tumble;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
