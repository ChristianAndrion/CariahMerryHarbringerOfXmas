using Unity.VisualScripting;
using UnityEngine;

public class EnemyArcher : EnemyChase
{
    public float range = 3f; 
    public bool inRange = false;
    protected override void Awake()
    {
        base.Awake();
        Lol();
    }

    protected override void Lol()
    {
        Debug.Log("shit archer");
    }

    protected void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log("distance = " + distance);
        if (distance < range) 
        {
            inRange = true;
        } else
        {
            inRange = false;
        }
    }

    protected override void FixedUpdate()
    {
        if (!inRange)
        {
            base.FixedUpdate();
        }
    }
}
