/**
All material in this application solution and source is, unless otherwise stated, 
the property of Kamau Vassall, Jorge Munoz, Oliver Plunket, Jeremy Bader 
Copyright and other intellectual property laws protect these materials. 
Reproduction or retransmission of the materials, in whole or in part, 
in any manner, without the prior written consent of the copyright holder,
is a violation of copyright law.

Originating Author: Kamau Vassall, Jorge Munoz, Oliver Plunket, Jeremy Bader 

*----------------------------------------------------------------
* GameManager.cs : Tracks the games progress, score, and etc
*----------------------------------------------------------------
*/
using UnityEngine;
using System.Collections.Generic;

public class AudioController : MonoBehaviour
{
	// Singleton
	public static AudioController Instance {
		get {
			return instance;
		}
	}

	private static AudioController instance;

	public AudioSource musicAudioSource;
	public AudioSource musicAudioSource2;
	public AudioSource soundEffectAudioSource;

	protected void Awake ()
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			DestroyObject (gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}

	public static void PlayMusic (AudioClip clip)
	{
		if (instance) {
			if (instance.musicAudioSource.clip.name != clip.name) {
				Debug.Log ("PlayMusic: " + clip.name);
				instance.musicAudioSource.clip = clip;
				instance.musicAudioSource.Play ();
			}
		}
	}

	public static void PlayMusic2 (AudioClip clip)
	{
		if (instance) {
			if (instance.musicAudioSource2.clip.name != clip.name) {
				Debug.Log ("PlayMusic2: " + clip.name);
				instance.musicAudioSource2.clip = clip;
				instance.musicAudioSource2.Play ();
			}
		}
	}

	public static void PlaySoundEffect (AudioClip clip)
	{
		if (instance) {
			Debug.Log ("PlaySoundEffect");
			if (instance.soundEffectAudioSource.clip.name != clip.name) {
				instance.soundEffectAudioSource.clip = clip;
			}

			instance.soundEffectAudioSource.Play ();
		}
	}

	public static void StopAllSounds(){
		if (instance) {
			instance.musicAudioSource.Stop ();
			instance.musicAudioSource2.Stop ();
			instance.soundEffectAudioSource.Stop ();
		}
	}
}
