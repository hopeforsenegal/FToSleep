using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(PlayerInput))]
public class Runner : MonoBehaviour
{
	public Animator anim;

	public void Attack ()
	{
		anim.SetTrigger ("Swipe");
	}
}
