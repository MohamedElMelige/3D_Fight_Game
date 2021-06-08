using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerf : MonoBehaviour
{
    private Transform target;

    [SerializeField]
    private Vector3 offsetPosition;
    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag(tags.Player_tag).transform;
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer();
    }

    void followPlayer()
    {
        transform.position = target.TransformPoint(offsetPosition);
        transform.rotation = target.rotation;
    }
}
