using UnityEngine;
using System.Collections;

public class Interactables : MonoBehaviour
{

	[SerializeField]
	private int m_id;
	[SerializeField]
	private string m_SceneToLoad;
	[SerializeField]
	private string m_PromptMessage;
	[SerializeField]
	private AudioClip m_PromptSound;
	[SerializeField]
	private Sprite m_SplashBackground;

	public string MiniGameName {
		get {
			return m_SceneToLoad;
		}
	}

	public int MiniGameId {
		get {
			return m_id;
		}
	}

	public string PromptMessage {
		get {
			return m_PromptMessage;
		}
	}

	public AudioClip PromptSound {
		get {
			return m_PromptSound;
		}
	}

	public Sprite SplashBackground {
		get {
			return m_SplashBackground;
		}
	}
}
