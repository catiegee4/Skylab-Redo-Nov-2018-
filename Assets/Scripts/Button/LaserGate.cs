using UnityEngine;
using UnityEngine.AI;

public class LaserGate : MonoBehaviour
{
	[SerializeField]
	NavMeshObstacle navMeshObstacle;

	[SerializeField]
	ButtonState buttonState;

	LaserGateColor laserGateColor;

	private void Start()
	{
		laserGateColor = GetComponent<LaserGateColor>();
	}

	private void Update()
	{
		// This shouldn't be being run every frame, but it's here until a better solution comes along.
		LaserEnable(buttonState.GetState() == laserGateColor.GetLaserColor());
	}

	// Enable or disable the gate. This will toggle the navmeshobstacle, the animation, and the sprite renderer.
	void LaserEnable(bool isEnabled)
	{
		navMeshObstacle.enabled = isEnabled;
		laserGateColor.animator.enabled = isEnabled;
		laserGateColor.spriteRenderer.enabled = isEnabled;
	}
}
