using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D m_rd2d;
    public float m_id; 
    public float m_moveSpeed = 5f;

    private void Update()
    {
        float v_movement = ProcessInput();
        Move(v_movement);
    }

    /// <summary>
    /// R�cup�re le mouvement du joueur en fonction de son ID
    /// </summary>
    /// <returns>float contenant la valeur du mouvement du joueur</returns>
    private float ProcessInput()
    {
        float v_movement = 0f;
        switch (m_id)
        {
            case 1:
                v_movement = Input.GetAxis("MovePlayer1");
                break;
            case 2:
                v_movement = Input.GetAxis("MovePlayer2");
                break;
        }
        return v_movement;
    }

    /// <summary>
    /// D�place le joueur en fonction de la valeur de mouvement
    /// </summary>
    /// <param name="p_movement">valeur de mouvement</param>
    private void Move(float p_movement)
    {
        Vector2 v_velocity = m_rd2d.velocity;
        v_velocity.y = m_moveSpeed * p_movement;
        m_rd2d.velocity = v_velocity;
    }
}
