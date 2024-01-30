using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{
    [SerializeField] private Transform child;
    private void Start()
    {
        Debug.LogFormat("child position : {0}", child.position);//world
        Debug.LogFormat("child localPosition : {0}", child.localPosition);//local
    }
}
