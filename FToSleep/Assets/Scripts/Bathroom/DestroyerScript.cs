using UnityEngine;
using System.Collections;

public class DestroyerScript : MonoBehaviour {

    [SerializeField]
    private float m_MaxSpeed = 5f;                    // The fastest the player can travel in the x axis.
   
   
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.

    private void Awake()
    {
       m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        // Move the character
        m_Rigidbody2D.velocity = new Vector2(m_MaxSpeed, m_Rigidbody2D.velocity.y);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
		{
			BathroomManager.Instance.GetSawed ();
			BathroomManager.Instance.EndGame ();
        }
    }
}
