using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameItems;

public class MetalDoorSensor : MonoBehaviour
{
	[SerializeField]
	MetalDoor metalDoor;

	//[SerializeField]
	//string ItemToCheck = "Key";

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

			//if (playerInventory.CheckForItem(ItemToCheck))
			if(playerInventory.IsKeyInInventory)
			{
				metalDoor.OpenDoor();
			}
		}
	}
}
