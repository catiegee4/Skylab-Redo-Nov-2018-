using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEnums;

public class PortalSwitchSprite : MonoBehaviour
{
	[SerializeField]
	Sprite BlueSprite;

	[SerializeField]
	Sprite PurpleSprite;

	SpriteRenderer spriteRenderer;

	private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void SetSprite(PortalColor color)
	{
		if (spriteRenderer != null)
		{
			switch (color)
			{
				case PortalColor.blue:
					spriteRenderer.sprite = BlueSprite;
					break;
				case PortalColor.purple:
					spriteRenderer.sprite = PurpleSprite;
					break;
				default:
					break;
			}
		}
	}
}
