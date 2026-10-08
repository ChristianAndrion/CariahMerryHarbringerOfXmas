//using TMPro;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [Header("Enemy Stat Variables")]
    [SerializeField] private float HP = 100f;
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb; // Holds the object rigidbody.
    private Collider2D col; // Holds the object 2D collider. 
    private Transform tf2; // Holds the object Transform.

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        col = gameObject.GetComponent<Collider2D>();
        tf2 = gameObject.GetComponent<Transform>();
    }

    public float GetHealth()
    {
        return HP;
    }

    public void SetHealth(float damage)
    {
        HP -= damage;
        return;
    }

    void FixedUpdate()
    {
        
    }
}
