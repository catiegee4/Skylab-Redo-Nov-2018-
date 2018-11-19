using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using GameItems;

public class PlayerInventory : NetworkBehaviour
{
	//public List<PlayerItems> Inventory;
	public bool IsKeyInInventory;

	private void Start()
	{
		if (!isLocalPlayer)
		{
			return;
		}

		//Inventory = new List<PlayerItems>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Kiosk"))
		{
			Kiosk kiosk = other.GetComponent<Kiosk>();

			//if (kiosk.isKeyPickable && !CheckForItem(kiosk.Key.ItemName))
			if (kiosk.isKeyPickable && !IsKeyInInventory)
			{
				//AddItem(kiosk.Key);
				IsKeyInInventory = true;

				Debug.Log(this.gameObject + " got the key.");

				kiosk.isKeyPickable = false;
			}
		}
	}

	/*
	public bool CheckForItem(string itemName)
	{
		if (itemName != null)
		{
			foreach (PlayerItems item in Inventory)
			{
				if (item.ItemName == itemName)
				{
					return true;
				}
			}
		}
		return false;
	}

	public void AddItem(PlayerItems item)
	{
		Inventory.Add(item);
	}
	*/
}
