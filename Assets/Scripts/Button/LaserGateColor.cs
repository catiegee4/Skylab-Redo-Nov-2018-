using UnityEngine;
using GameEnums;

public class LaserGateColor : MonoBehaviour
{
	[SerializeField]
	public Animator animator;

	[SerializeField]
	public SpriteRenderer spriteRenderer;

	[SerializeField]
	LaserColor laserColor;

	private void Start()
	{
		switch (laserColor)
		{
			case LaserColor.blue:
				animator.SetBool("isBlue", true);
				break;
			case LaserColor.yellow:
				animator.SetBool("isBlue", false);
				break;
			default:
				break;
		}
	}

	public LaserColor GetLaserColor()
	{
		return laserColor;
	}
}
