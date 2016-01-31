using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(PlayerInput))]
public class Runner : MonoBehaviour
{
	public void Attack ()
	{
		Animator anim = GetComponentInParent<Animator> ();
		anim.SetTrigger ("Swipe");
	}
}
