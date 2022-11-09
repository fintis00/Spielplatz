using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerTransform;
    private Transform _transform;
    private Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        dir = (playerTransform.position - transform.position).normalized;
        transform.Translate(dir * Time.deltaTime);
    }
}
