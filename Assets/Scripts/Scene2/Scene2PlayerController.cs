using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class Scene2PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource audioSource;
    private float nextFire;
    private bool fireTwice;

    public float speed;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    public Camera mainCamera;
    public ParticleSystem flare;
    public ParticleSystem core;
    private float anglePlayer;

    private void Update()
    {
        RotatePlayer();
        if (Input.GetButtonDown("Fire1") || fireTwice == true)
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawn.position, Quaternion.Euler(0.0f, anglePlayer, 0.0f));
                audioSource.Play();
                fireTwice = false;
            }
            else
            {
                fireTwice = true;
            }

        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        fireTwice = false;
        anglePlayer = 0;
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(-moveVertical, 0.0f, moveHorizontal);
        rb.velocity = movement * speed;

        rb.position = new Vector3
            (
                Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
                0,
                Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );
        rb.rotation = Quaternion.Euler(0.0f, anglePlayer, 0.0f);
        var flareMain = flare.main;
        flareMain.startRotation = (anglePlayer + 90) / 180 * Mathf.PI;
        var coreMain = core.main;
        coreMain.startRotation = (anglePlayer + 90) / 180 * Mathf.PI;
    }

    void RotatePlayer ()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = 10;
        anglePlayer = 180 / Mathf.PI * Mathf.Atan2(rb.position.x - mainCamera.ScreenToWorldPoint(pos).x, rb.position.z - mainCamera.ScreenToWorldPoint(pos).z);
        if (anglePlayer >= 0)
            anglePlayer = anglePlayer - 180;
        else
            anglePlayer = anglePlayer + 180;
    }
}
