using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(BoxCollider2D))]
public class BathroomEnemy : MonoBehaviour
{
	private Knight2D mainPlayer;
	protected void Awake(){
		GameObject tempObject;
		tempObject = GameObject.Find ("Canvas");
		if (tempObject != null) {
			mainPlayer = tempObject.GetComponent<Knight2D> ();
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log ("Did you swing at me?");
		if (coll.gameObject.name == "Knight") {
			Debug.Log ("Et tu, Brute?");
			if (mainPlayer) {
				mainPlayer.GotTouched ();
			}
		}
	}

    void OnTriggerEnter2D(Collider2D otherObject)
    {
        Debug.Log("Got hit by sword?");
        if(otherObject.name == "AttackTrigger")
        {
            Debug.Log("Attack Trigger");
            gameObject.SetActive(false);
        }
    }
}
