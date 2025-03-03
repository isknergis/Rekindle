
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public float height = 10f;
    public float distance = 10f;

    void LateUpdate()
    {
        if (player1 == null || player2 == null) return;

        // İki oyuncunun ortasına kamera yerleştir
        Vector3 middlePoint = (player1.position + player2.position) / 2f;
        transform.position = middlePoint + new Vector3(0, height, -distance);
        transform.LookAt(middlePoint);
    }
}


