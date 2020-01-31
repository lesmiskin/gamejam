using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMotion : MonoBehaviour
{
    // User-modifiable
    public float speed = 0.03f;
    public float radius = 50f;
    public bool antiClockwise = false;
    public bool lockX = false;
    public bool lockY = false;

    float movementIncX = 0;
    float movementIncY = 0;

    public float originX = 0;
    public float originY = 0;

    public float speedRange = 0;
    public float radiusRange = 0;

    // float initialX = 0;
    // float initialY = 0;

    void FixedUpdate()
    {
        float newx, newy;
        bool completedX = false;
        bool completedY = false;

        // Compute step
        if(antiClockwise) {
            newx = MqCommon.cosInc(transform.position.y, ref movementIncY, speed, radius, out completedX);
            newy = MqCommon.sineInc(transform.position.x, ref movementIncX, speed, radius, out completedY);
        }else{
            newx = MqCommon.sineInc(transform.position.x, ref movementIncX, speed, radius, out completedX);
            newy = MqCommon.cosInc(transform.position.y, ref movementIncY, speed, radius, out completedY);
        }

        if(completedY) {
            speed = (float)MqCommon.randomMq(2, 6) / 100;
        }

        // Apply reverse direction
        if(antiClockwise) {
            newx = -newx;
            newy = -newy;
        }

        // originX = cam.WorldToScreenPoint(

        Vector3 movement = new Vector3(
            lockX ? originX : originX + newx, 
            lockY ? originY : originY + newy,
            transform.position.z
        );
        movement *= Time.deltaTime;

        Vector3 movement2 = new Vector3(
            transform.position.x, 
            movement.y,                         // only apply adjustment to Y axis.
            transform.position.z
        );

        // Absolute position
        transform.position = movement2;
    }
}