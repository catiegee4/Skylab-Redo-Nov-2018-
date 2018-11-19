using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MetalDoor : MonoBehaviour
{
	[SerializeField]
	NavMeshObstacle navMeshObstacle;

	[SerializeField]
	SpriteRenderer spriteRenderer;

	public bool isOpen;

	public void OpenDoor()
	{
		navMeshObstacle.enabled = false;
		spriteRenderer.enabled = false;
		isOpen = true;
	}
}
