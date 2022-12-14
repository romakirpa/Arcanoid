using System.Collections;
using System.Collections.Generic;
using Infrastructure;
using UnityEngine;

public class Boot : MonoBehaviour
{
    void Start()
    {
        var game = new Game();
        DontDestroyOnLoad(gameObject);
    }
}
