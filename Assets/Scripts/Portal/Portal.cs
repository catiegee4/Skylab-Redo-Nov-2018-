using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEnums;
using UnityEngine.AI;

public class Portal : MonoBehaviour
{
	[SerializeField]
	PortalControl portalControl;

	[SerializeField]
	PortalColor portalColor;

	[SerializeField]
	public Transform destinationPortal;

	[SerializeField]
	public bool IsActive;

	private void Start()
	{
		UpdatePortal();
	}

	private void Update()
	{
		UpdatePortal();
	}

	/*
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") && IsActive && other.GetComponent<PortalTimer>().IsTeleportable)
		{
			other.GetComponent<PlayerInput>().Teleport(destinationPortal);
			other.GetComponent<PortalTimer>().StartPortalTimer();
		}
	}
	*/

	public void UpdatePortal()
	{
		IsActive = (portalColor == portalControl.GetActivePortal());
	}

	public PortalColor GetPortalColor()
	{
		return portalColor;
	}
}
