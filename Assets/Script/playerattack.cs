using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerattack : MonoBehaviour
{
    private CharactarAni playerani;
    // Start is called before the first frame update
    void Awake()
    {
        playerani = GetComponent<CharactarAni>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            playerani.Defend(true);
        }
        if (Input.GetKeyUp(KeyCode.N ))
        {
            playerani.UnFreezeanimation();
            playerani.Defend(true);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (Random.Range(0, 2) > 0)
            {
                playerani.Attack1();
            }
            else
            {
                playerani.Attack2();
            }
        }
    }
    
}
