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
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				if(hit.collider.gameObject != null)
				{
					Debug.Log($"collider?: {hit.collider.gameObject.name}");
					MoveToPosition(hit.point);
				}
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
