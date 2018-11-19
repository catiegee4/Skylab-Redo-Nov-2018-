using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class PlayerAnimation : NetworkBehaviour
{
	[SerializeField]
	Animator animator;

	NavMeshAgent agent;
	NetworkTransform networkTransform;

	Vector2 smoothDeltaPosition = Vector2.zero;
	Vector2 velocity = Vector2.zero;

	public float AnimStopDistance;

	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		// Don’t update position automatically
		agent.updatePosition = false;

		networkTransform = GetComponent<NetworkTransform>();
	}

	void Update()
	{
		if (!isLocalPlayer)
		{
			return;
		}

		Vector3 worldDeltaPosition = agent.nextPosition - transform.position;

		// Map 'worldDeltaPosition' to local space
		float dx = Vector3.Dot(transform.right, worldDeltaPosition);
		float dy = Vector3.Dot(transform.forward, worldDeltaPosition);
		Vector2 deltaPosition = new Vector2(dx, dy);

		// Low-pass filter the deltaMove
		float smooth = Mathf.Min(1.0f, Time.deltaTime / 0.15f);
		smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, deltaPosition, smooth);

		// Update velocity if time advances
		if (Time.deltaTime > 1e-5f)
			velocity = smoothDeltaPosition / Time.deltaTime;

		bool shouldMove = velocity.magnitude > AnimStopDistance; //&& agent.remainingDistance > agent.radius;

		if (shouldMove)
		{
			UpdatePosition();
		}

		// Update animation parameters
		animator.SetBool("move", shouldMove);
		animator.SetFloat("velx", velocity.x);
		animator.SetFloat("vely", velocity.y);
	}

	void UpdatePosition()
	{
		// Update position to agent position
		transform.position = agent.nextPosition;
		networkTransform.transform.position = transform.position;
	}
}