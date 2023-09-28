using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{

	public NavMeshAgent agent;
	public Rigidbody rb;
	public GameObject interactionObject;
	public ObjectInteraction objectInteraction;

	private void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		rb = GetComponent<Rigidbody>();

	}	

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("Clicked");
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				Debug.Log("Raycast hit");

				MoveToPosition(hit.point);
			}
		}

		if (rb.velocity.magnitude > 0.1)
		{
			Debug.Log("Char is moving");
		}
	}


	private void MoveToPosition(Vector3 position)
	{
		// Set the target position and flag to start moving.
		agent.SetDestination(position);
		//isMoving = true;
	}
}
