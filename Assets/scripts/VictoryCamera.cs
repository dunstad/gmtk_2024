using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VictoryCamrea : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CharacterController2D player = other.gameObject.GetComponent<CharacterController2D>();
        if (player)
        {
            GetComponent<CinemachineVirtualCamera>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        CharacterController2D player = other.gameObject.GetComponent<CharacterController2D>();
        if (player)
        {
            GetComponent<CinemachineVirtualCamera>().enabled = false;
        }
    }
}
