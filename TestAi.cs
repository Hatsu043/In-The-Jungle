using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAi : MonoBehaviour
{
    Animator anmin;
    public Transform Player;
    [SerializeField] float longDistance, distanceToPlayer, closeDistance;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        anmin = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
    }

    void DetectPlayer()
    {
        distanceToPlayer = Vector3.Distance(Player.position, transform.position);
        if(distanceToPlayer <= longDistance)
        {
            anmin.SetInteger("PandaState", 1);
            FollowPlayer();
        }
        else
        {
            anmin.SetInteger("PandaState", 0);
        }
    }

    void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, longDistance);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, closeDistance);
    }
}
