using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTOL : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
