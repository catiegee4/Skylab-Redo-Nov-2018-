using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEnums;

public class PortalControl : MonoBehaviour
{
	[SerializeField]
	PortalColor ActivePortal;

	public PortalColor GetActivePortal()
	{
		return ActivePortal;
	}

	private void SetActivePortal(PortalColor color)
	{
		ActivePortal = color;
	}

	public void SwitchActivePortal()
	{
		PortalColor activePortal = GetActivePortal();

		switch (activePortal)
		{
			case PortalColor.blue:
				SetActivePortal(PortalColor.purple);
				break;
			case PortalColor.purple:
				SetActivePortal(PortalColor.blue);
				break;
			default:
				break;
		}
	}
}
