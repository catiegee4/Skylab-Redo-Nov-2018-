using UnityEngine;
using GameEnums;

public class ButtonState : MonoBehaviour
{
	[SerializeField]
	LaserColor State;

	public LaserColor GetState()
	{
		return State;
	}

	public void SetState(LaserColor color)
	{
		State = color;
	}
}
