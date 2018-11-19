using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameItems;

public class Kiosk : MonoBehaviour
{
	public PlayerItems Key;
	public bool isKeyPickable;

	private void Start()
	{
		Key = new PlayerItems("Key");
	}

	// Code bellow was moved to the player object.
	/*
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

			if (isKeyPickable && !playerInventory.CheckForItem(Key.ItemName))
			{
				playerInventory.AddItem(Key);
				isKeyPickable = false;
			}
			else
			{
				// Player already picked up the key
			}
		}
	}*/
}
