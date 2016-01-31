using UnityEngine;
using System.Collections;

public class Interactables : MonoBehaviour {

	[SerializeField]
	private int m_id;

    [SerializeField]
    private string m_SceneToLoad;
    [SerializeField]
    private string m_PromptMessage;


    public string MiniGameName {
        get
        {
            return m_SceneToLoad;
        }
    }

	public int MiniGameId {
		get
		{
			return m_id;
		}
	}

    public string PromptMessage
    {
        get
        {
            return m_PromptMessage;
        }
    }


    void Awake() {

    }

}
