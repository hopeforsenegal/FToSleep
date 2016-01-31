using UnityEngine;
using System.Collections;

public class Interactables : MonoBehaviour {

	[SerializeField]
	private int m_id;

    [SerializeField]
    private string m_SceneToLoad;

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


    void Awake() {

    }

}
