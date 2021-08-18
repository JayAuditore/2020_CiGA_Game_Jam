using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopHitPoint : MonoBehaviour
{

    public void Start()
    {

    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag=="Player"|| collision.tag == "Ground"&& transform.parent.parent.GetComponent<Pig>().anim.GetCurrentAnimatorStateInfo(0).IsName("skill"))
        {
            transform.parent.parent.GetComponent<Pig>().isStop = true;

        }



    }
}
