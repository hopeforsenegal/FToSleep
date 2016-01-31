using UnityEngine;
using System.Collections;

public class BathroomKillzone : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
		{
			MetagameController.SetWonGame (MetagameController.Instance.lastPlayedGame);
			BathroomManager.Instance.EndGame ();
        }
    }
}
