using UnityEngine;

public class DisableSprite : MonoBehaviour
{
	SpriteRenderer spriteRenderer;

	private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.enabled = false;
	}
}
