using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunGun : MonoBehaviour {

    public GameObject gun;
    public GameObject _camera;
    public GameObject crosshair;
    public GameObject flash;

    public GameObject bullet;
    public GameObject bulletSpawn;

    public Vector3 restingPosition;
    public Vector3 upPosition;
    public Vector3 upRotation;

    public ParticleSystem muzzleFlash;
    public AudioSource audioMedic;

    public float range = 100f;
    public float fireRate = 15f;

    private bool active;
    private float nextTimeToFire = 0f;

    void Start()
    {
        active = false;
        gun.SetActive(false);
        gun.transform.parent = gameObject.transform;
        gun.transform.localPosition = restingPosition;
        gun.transform.localRotation = Quaternion.identity;
    }

    public void MakeEnable()
    {
        active = true;
        gun.SetActive(true);
    }

    public void Update()
    {
        if (active)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                gun.transform.parent = _camera.transform;
                gun.transform.localPosition = upPosition;
                gun.transform.localRotation = Quaternion.Euler(upRotation);
                crosshair.SetActive(true);
            }
            else if (Input.GetButtonUp("Fire2"))
            {
                gun.transform.parent = gameObject.transform;
                gun.transform.localPosition = restingPosition;
                gun.transform.localRotation = Quaternion.identity;
                crosshair.SetActive(false);
            }
            if (Input.GetButton("Fire2") && Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        muzzleFlash.Play();
        audioMedic.pitch = Mathf.Max(Time.timeScale, .1f);
        audioMedic.Play();

        if (Time.timeScale > .9f)
        {
            RaycastHit hit;
            if(Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);

                GameObject flashGO = Instantiate(flash, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(flashGO, 3f);

                IShootable shootable = hit.transform.GetComponent<IShootable>();
                if(shootable != null)
                {
                    shootable.OnShot();
                }
            }
        }
        else
        {
            GameObject ob = Instantiate(bullet,bulletSpawn.transform.position,bulletSpawn.transform.rotation);
            ob.SetActive(true);
        }
    }

}
