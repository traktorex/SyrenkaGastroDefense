using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public Transform start;
    public Transform[] path;

    private void Awake()
    {
        main = this;
    }
}
