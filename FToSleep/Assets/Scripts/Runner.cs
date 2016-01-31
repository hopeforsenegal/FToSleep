using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(PlayerInput))]
public class Runner : MonoBehaviour
{
	public AudioClip soundEffect;

	public void Attack ()
	{
		Animator anim = GetComponentInParent<Animator> ();
		anim.SetTrigger ("Swipe");
		AudioController.PlaySoundEffect (soundEffect);
	}
}
