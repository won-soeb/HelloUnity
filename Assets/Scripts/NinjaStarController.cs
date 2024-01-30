using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStarController : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 10;
    void Update()
    {
        transform.Translate(Vector3.up * 1 * Time.deltaTime, Space.World);
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
}
