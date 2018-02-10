using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2DestroyByTime : MonoBehaviour {

    public float lifeTime;

	void Start ()
    {
        Destroy(gameObject, lifeTime);	
	}
}
