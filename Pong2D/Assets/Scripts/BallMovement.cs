using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public GameManager m_gameManager;

    // true si la balle va vers la gauche, false si elle va vers la droite
    private bool m_leftDirection = false;

    private float m_speed = 10.0f;
    private float m_randomY;

    private Rigidbody2D m_ballRb;

    void Start()
    {
        m_ballRb = GetComponent<Rigidbody2D>();
        m_randomY = Random.Range(-10.0f, 10.0f);
    }

    void FixedUpdate()
    {
        Vector2 v_leftMovement = new Vector2(-m_speed, m_randomY);
        Vector2 v_rightMovement = new Vector2(m_speed, m_randomY);

        // Si la balle va vers la gauche, on lui donne une vitesse négative
        // sinon, on lui donne une vitesse positive
        if (m_leftDirection)
        {
            m_ballRb.velocity = v_leftMovement;
        }
        else
        {
            m_ballRb.velocity = v_rightMovement;
        }
    }

    /// <summary>
    /// Remet la balle au centre et change sa direction
    /// vers le joueur qui a marqué un point.
    /// </summary>
    private void ResetBall()
    {
        m_randomY = Random.Range(-10.0f, 10.0f);
        m_leftDirection = !m_leftDirection;
        m_ballRb.velocity = new Vector2(0, m_randomY);
        transform.position = new Vector2(0, 0);
    }

    /// <summary>
    /// Change la direction de la balle lorsqu'elle entre en collision
    /// soit avec un joueur, soit avec un mur.
    /// </summary>
    private void OnCollisionEnter2D(Collision2D p_collision)
    {
        // Si c'est un joueur qui a touché la balle, on change sa direction
        if (p_collision.gameObject.tag == "Player")
        {
            m_leftDirection = !m_leftDirection;
            m_randomY = Random.Range(-10.0f, 10.0f);
            m_ballRb.velocity = new Vector2(m_ballRb.velocity.x, m_randomY);
        }

        // Si c'est un mur qui a touché la balle, on ne change pas sa direction,
        // Seuelemnt son angle de rebond
        if (p_collision.gameObject.tag == "SimpleBorder")
        {
            m_randomY = -m_randomY;
            m_ballRb.velocity = new Vector2(m_ballRb.velocity.x, m_randomY);
        }
    }

    /// <summary>
    /// Lorsque la balle entre en collision avec une zone de score,
    /// On appelle la fonction OnScoreZoneReached du GameManager,
    /// permettant d'ajouter un point au joueur correspondant.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D p_collision)
    {
        ScoreZone v_scoreZone = p_collision.GetComponent<ScoreZone>(); 
        if(v_scoreZone)
        {
            m_gameManager.OnScoreZoneReached(v_scoreZone.m_id);
            ResetBall();
        }
    }
}
