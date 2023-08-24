using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class Bezier
{
    public static Vector3 GetPoint(Vector3 point1,  Vector3 point2, Vector3 point3, Vector3 point4, float time)
    {
        Vector3 point1_2 = Vector3.Lerp(point1, point2, time); // положение точки на отрезке между двумя точками
        Vector3 point2_3 = Vector3.Lerp(point2, point3, time); 
        Vector3 point3_4 = Vector3.Lerp(point3, point4, time);
        
        Vector3 point1_2_point_2_3 = Vector3.Lerp(point1_2, point2_3, time); // положение точки на отрезке между двумя парами точек
        Vector3 point2_3_point3_4 = Vector3.Lerp(point2_3, point3_4, time);

        Vector3 endPoint = Vector3.Lerp(point1_2_point_2_3, point2_3_point3_4, time); // положение точки на отерезке между двумя парами пар точек :)

        return endPoint;
    }
}
