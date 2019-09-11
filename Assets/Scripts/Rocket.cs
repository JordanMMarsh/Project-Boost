using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    [SerializeField] float shipSpeed = 100f;
    Rigidbody myRigidbody;
    AudioSource audioSource;
    private const string HAZARD_TAG_NAME = "Hazard";
    private const string FRIENDLY_TAG_NAME = "Friendly";

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        ProcessInput();
	}

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            myRigidbody.AddRelativeForce(Vector3.up * shipSpeed * Time.deltaTime);

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }            
        }
        else
        {
            audioSource.Stop();
        }

        myRigidbody.freezeRotation = true;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * shipSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * shipSpeed * Time.deltaTime);
        }
        myRigidbody.freezeRotation = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == HAZARD_TAG_NAME)
        {
            Debug.Log("Hazard");
        }
        else if (collision.gameObject.tag == FRIENDLY_TAG_NAME)
        {
            Debug.Log("Friendly");
        }
    }
}
