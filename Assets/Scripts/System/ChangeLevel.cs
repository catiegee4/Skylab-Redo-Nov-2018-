using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class ChangeLevel : NetworkBehaviour
{
	[SerializeField]
	string NextLevel;

	[SerializeField]
	int PlayersRequired;

	int PlayerCount = 0;

	bool isReadyToWarp = false;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			PlayerCount++;
            Debug.Log("OnTriggerEnter : Player count increased");
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			PlayerCount--;
            Debug.Log("OnTriggerEnter : Player count decreased");
        }
    }

	private void Update()
	{
		if (PlayerCount >= PlayersRequired)
		{
			isReadyToWarp = true;
		}

		if (isReadyToWarp)
		{
			WarpRoom();
		}

		// For debug only:
		if (Input.GetKeyUp(KeyCode.Space))
		{
			WarpRoom();
		}
	}

	void WarpRoom()
	{
		if (!isServer)
		{
			return;
		}

		if (NextLevel != "")
		{
			//SceneManager.LoadScene(NextLevel);
			NetworkManager.singleton.ServerChangeScene(NextLevel);
		}
	}
}
