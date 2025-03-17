using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //define player transfomr to follow
    [SerializeField] private Transform player;
    //offset is the distance betweenplayer and camera
    [SerializeField] private Vector3 offset;
    // define the smooth speed, so we can make camera follow player
    [SerializeField] private float smoothSpeed = 5.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    //FixedUpdate - update in every 0.02s
    //LateUpdate - update after the update() is called

    void Update()
    {
        
    }
    private void LateUpdate()
    {
        if (player == null)
        {
            return;
        }
        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        
    }

}
