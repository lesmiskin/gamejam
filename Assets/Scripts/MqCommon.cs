using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MqCommon
{
    public const double RADIAN_CIRCLE = 6.28;
    static System.Random _random = new System.Random();

    public static int randomMq(int min, int max) {
        return _random.Next(min, max);
    }

    public static float cosInc(float offset, ref float cosInc, float speed, float magnitude, out bool completed) {
        completed = false;
        if(cosInc >= RADIAN_CIRCLE) completed = true;

        cosInc = cosInc >= RADIAN_CIRCLE ? 0 : cosInc + speed;

        float cosOffset = (Mathf.Cos(cosInc) * magnitude);
        return offset - cosOffset;
    }

    public static float sineInc(float offset, ref float sineInc, float speed, float magnitude, out bool completed) {
        completed = false;
        if(sineInc >= RADIAN_CIRCLE) completed = true;

        sineInc = sineInc >= RADIAN_CIRCLE ? 0 : sineInc + speed;

        float sineOffset = (Mathf.Sin(sineInc) * magnitude);
        return offset - sineOffset;
    }
}
