using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maples : MonoBehaviour
{
    private Animator anim;
    private Transform transform;
    private bool willBeDeathSoon = false;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -3f && !willBeDeathSoon)
        {
            anim.SetBool("YouCanKillMeNow", true);
            willBeDeathSoon = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BotCollider") && !willBeDeathSoon)
        {
            anim.SetBool("YouCanKillMeNow", true);
            willBeDeathSoon = true;
        }
    }

    public void KillMe()
    {
        Destroy(gameObject);
    }
}
