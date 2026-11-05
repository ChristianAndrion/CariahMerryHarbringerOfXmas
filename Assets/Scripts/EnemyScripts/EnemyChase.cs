using UnityEditor.PackageManager;
using UnityEngine;

public class EnemyChase : BaseEnemy
{
    public GameObject player;
    public float speed;

    protected float distance;

    protected virtual void Lol()
    {
        Debug.Log("regular chase enemy");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        Lol();
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction= player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
