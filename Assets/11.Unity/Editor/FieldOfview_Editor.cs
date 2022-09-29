using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(FieldOfView))]
public class FieldOfview_Editor : Editor
{

    void OnSceneGUI()
    {
        FieldOfView fov = (FieldOfView)target;

        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov._eyeRadius);

        //float rightAngleX = Mathf.Sin((fov.eyeAngle/2) *Mathf.Deg2Rad) *fov.eyeRadius;
        //float angleZ = Mathf.Cos((fov.eyeAngle/2) *Mathf.Deg2Rad) *fov.eyeRadius;
        //Vector3 vecRight = new Vector3(rightAngleX, 0, angleZ);

        //float leftAngleX = Mathf.Sin((-fov.eyeAngle / 2) * Mathf.Deg2Rad) * fov.eyeRadius;
        //Vector3 vecLeft = new Vector3(leftAngleX, 0, angleZ);

        Vector3 viewAngleA = fov.GetVecByAngle(-fov._eyeAngle / 2, false);
        Vector3 viewAngleB = fov.GetVecByAngle(fov._eyeAngle / 2, false);

        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleA * fov._eyeRadius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleB * fov._eyeRadius);

        Handles.color = Color.red;

        foreach (Transform visibleTarget in fov.TargetLists) //��� Ÿ���� ������ �����
        {
            if (fov.FirstTarget != visibleTarget) //ù��° Ÿ�ٸ�
            {
                Handles.DrawLine(fov.transform.position, visibleTarget.position);
            }

        }

        Handles.color = Color.green;
        if (fov.FirstTarget)
        {
            Handles.DrawLine(fov.transform.position, fov.FirstTarget.position);
        }
    }

}