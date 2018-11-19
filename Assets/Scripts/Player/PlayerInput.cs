using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.AI;

public class PlayerInput : NetworkBehaviour
{
	[SerializeField] SpriteRenderer spriteRenderer;
	NavMeshAgent agent;
	NetworkTransform networkTransform;

	RaycastHit hitInfo = new RaycastHit();
	
	private void Start()
	{
		networkTransform = GetComponent<NetworkTransform>();

		agent = GetComponent<NavMeshAgent>();
		agent.enabled = false;
		transform.position = networkTransform.transform.position;
		agent.enabled = true;

		//agent.updatePosition = false;
	}

	void Update()
	{
		if (!isLocalPlayer)
		{
			return;
		}
		/*
		// Mouse Movement
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;

			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
			{
				agent.destination = hit.point;
			}
		}
		//transform.position = agent.nextPosition;
		*/

		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
			{
				agent.destination = hitInfo.point;
			}
		}
	}

	public override void OnStartLocalPlayer()
	{
		spriteRenderer.color = Color.yellow;
		GetComponent<NetworkAnimator>().SetParameterAutoSend(0, true);
	}

	public override void PreStartClient()
	{
		base.PreStartClient();
		GetComponent<NetworkAnimator>().SetParameterAutoSend(0, true);
	}
}
