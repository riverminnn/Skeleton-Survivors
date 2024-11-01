using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    private void Update()
    {
        
    }

    private void Start()
    {
    }
    private void Awake()
    {
        if (GM != null)
        {
            Destroy(gameObject);
            return;
        }

        GM = this;
        DontDestroyOnLoad(GM);
    }
}
