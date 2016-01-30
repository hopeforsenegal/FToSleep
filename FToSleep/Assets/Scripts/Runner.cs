using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(PlayerInput))]
public class Runner : MonoBehaviour
{
	private bool attack;

	protected void Awake ()
	{
	}

	protected void Start ()
	{
	}

	protected void Update ()
	{
		if (!attack) {
		}

		attack = false;
	}

	public void Attack ()
	{
		Debug.Log ("Attack!");
		attack = true;
		Animator anim = GetComponentInParent<Animator> ();
		anim.SetTrigger ("Swipe");
	}
}
