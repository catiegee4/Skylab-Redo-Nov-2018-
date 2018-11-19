using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.AI;

public class PortalTeleport : NetworkBehaviour
{
	bool IsTeleportable = true;

	NavMeshAgent agent;
	//NetworkTransform networkTransform;

	private void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		//networkTransform = GetComponent<NetworkTransform>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Portal"))
		{
			Portal portal = other.GetComponent<Portal>();

			if (IsTeleportable && portal.IsActive)
			{
				Teleport(portal.destinationPortal);
				StartPortalTimer();
			}
		}
	}

	public void Teleport(Transform destination)
	{
		// Teleport code here
		/*
		agent.enabled = false;
		networkTransform.transform.position = destination.position;
		agent.enabled = true;
		*/
		//agent.updatePosition = false;
		agent.Warp(destination.position);
	}

	public void StartPortalTimer()
	{
		if (IsTeleportable)
		{
			IsTeleportable = false;
			StartCoroutine(RunTimer());
		}
	}

	public IEnumerator RunTimer()
	{
		yield return new WaitForSeconds(1);
		IsTeleportable = true;
	}
}
