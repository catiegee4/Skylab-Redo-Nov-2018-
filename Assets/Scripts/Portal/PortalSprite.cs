using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEnums;

public class PortalSprite : MonoBehaviour
{
	[SerializeField]
	Sprite BlueSprite;

	[SerializeField]
	Sprite PurpleSprite;

	[SerializeField]
	Portal portal;

	SpriteRenderer spriteRenderer;

	private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();

		PortalColor color = portal.GetPortalColor();

		UpdateSprite(color);
	}

	public void UpdateSprite(PortalColor _color)
	{
		switch (_color)
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
