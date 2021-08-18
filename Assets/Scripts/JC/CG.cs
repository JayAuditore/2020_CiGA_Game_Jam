using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CG : BaseSingletonWithMono<CG>
{
    Animator anim;
    AnimatorStateInfo info;

    bool Play;

    public GameObject YouDie;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Cg();
    }

    private void Cg()
    {
        info = anim.GetCurrentAnimatorStateInfo(0);

        if (Play)
        {
            anim.SetBool("Cg", true);
        }

        if ((info.normalizedTime > 1.0f) && (info.IsName("Dead")))
        {
            Debug.Log("2");
            if (Input.anyKeyDown)
            {
                CG.Instance.YouDie.SetActive(false);
                Debug.Log("1");
                anim.SetBool("Cg", false);
                Play = false;
                SceneControl.Instance.LoadScene(1);
            }
        }
    }

    public void CgBool()
    {
        Play = true;
        YouDie.SetActive(true);
    }
}
