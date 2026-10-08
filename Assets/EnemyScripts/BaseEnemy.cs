using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    //THIS IS AN EDIT
    
    //This is Herman's Edit
    [Header("Enemy Stat Variables")]
    [SerializeField] private float HP = 100f;
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb; // Holds the object rigidbody.
    private Collider2D col; // Holds the object 2D collider. 
    private Transform tf2classic; // Holds the object Transform.

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        col = gameObject.GetComponent<Collider2D>();
        tf2classic = gameObject.GetComponent<Transform>();
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
