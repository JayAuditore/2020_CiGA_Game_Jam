using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Enter : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    public CinemachineVirtualCamera Cinemachine;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        player.transform.position = this.transform.position;
        
        Cinemachine.Follow = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
