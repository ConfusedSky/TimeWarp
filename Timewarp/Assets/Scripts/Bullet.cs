using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {

    public float lifetime = 5f;
    public float speed = 200f;

    private float ttd;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        ttd = Time.time + lifetime;
        rb = GetComponent<Rigidbody>();
        rb.velocity = speed * transform.forward;
    }
	
	// Update is called once per frame
	void Update () {
		if(Time.time > ttd)
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other);
        IShootable shootable = other.gameObject.GetComponent<IShootable>();
        if(shootable != null)
        {
            shootable.OnShot();
        }
        Destroy(gameObject);
    }
}
