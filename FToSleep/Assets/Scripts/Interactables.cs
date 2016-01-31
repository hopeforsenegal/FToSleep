using UnityEngine;
using System.Collections;

public class Interactables : MonoBehaviour {
    
    private string m_id;

    [SerializeField]
    private string m_SceneToLoad;

    public string MiniGameName {
        get
        {
            return m_SceneToLoad;
        }
    }


    void Awake() {
        m_id = m_SceneToLoad;
    }

}
