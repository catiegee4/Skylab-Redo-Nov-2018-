using UnityEngine;
using GameEnums;

public class ButtonSpriteControl : MonoBehaviour
{
	[SerializeField]
	Sprite YellowSprite;

	[SerializeField]
	Sprite BlueSprite;

	[SerializeField]
	ButtonState buttonState;

	SpriteRenderer spriteRenderer;

	void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		UpdateSprite();
	}

	public void UpdateSprite()
	{
		switch (buttonState.GetState())
		{
			case LaserColor.blue:
				spriteRenderer.sprite = BlueSprite;
				break;
			case LaserColor.yellow:
				spriteRenderer.sprite = YellowSprite;
				break;
			default:
				break;
		}
	}
}
