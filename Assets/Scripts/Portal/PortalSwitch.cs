using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEnums;

public class PortalSwitch : MonoBehaviour
{
	[SerializeField]
	PortalControl portalControl;

	[SerializeField]
	PortalSwitchSprite portalSwitchSprite;

	PortalColor buttonState;

	private void Start()
	{
		UpdateSwitchColor();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			portalControl.SwitchActivePortal();
			UpdateSwitchColor();
		}
	}

	void UpdateSwitchColor()
	{
		buttonState = portalControl.GetActivePortal();
		portalSwitchSprite.SetSprite(buttonState);
	}
}
