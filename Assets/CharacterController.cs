using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Vector3 playerVelocity;
    private float playerSpeed = 2.0f;
    public GameObject character;

    void Update()
    {
		if (Input.GetKey(KeyCode.D))
		{
			transform.position += Vector3.right * playerSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.A))
		{
			transform.position += Vector3.left * playerSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.W))
		{
			transform.position += Vector3.forward * playerSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.S))
		{
			transform.position += Vector3.back * playerSpeed * Time.deltaTime;
		}
	}
}
