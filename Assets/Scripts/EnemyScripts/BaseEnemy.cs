//using TMPro;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [Header("Enemy Stat Variables")]
    [SerializeField] protected float HP = 100f;
    [SerializeField] protected float moveSpeed = 5f;
    protected Rigidbody2D rb; // Holds the object rigidbody.
    protected Collider2D col; // Holds the object 2D collider. 
    protected Transform tf2; // Holds the object Transform.

    protected virtual void Awake()
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
