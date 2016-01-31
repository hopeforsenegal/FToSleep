using UnityEngine;
using System.Collections;

public class BathroomKillzone : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
			BathroomManager.Instance.EndGame ();
        }
    }
}
