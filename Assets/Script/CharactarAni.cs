using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactarAni : MonoBehaviour
{
    private Animator Ani;
    // Start is called before the first frame update
    void Awake()
    {
        Ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Walk(bool walk)
    {
        Ani.SetBool(animationTags.walk_paramter, walk);
    }
    public void Defend(bool defend)
    {
        Ani.SetBool(animationTags.defend_paramter, defend);
    }
    public void Attack1()
    {
        Ani.SetTrigger(animationTags.attack_1_paramter);
    }
    public void Attack2()
    {
        Ani.SetTrigger(animationTags.attack_2_paramter);
    }
    void freezeAnimation()
    {
        Ani.speed = 0f;
    }
    public void UnFreezeanimation()
    {
        Ani.speed = 1f;
    }

}
