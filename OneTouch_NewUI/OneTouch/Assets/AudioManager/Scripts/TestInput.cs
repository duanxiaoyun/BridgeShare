﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioManager;

public class TestInput : MonoBehaviour
{
    public int _id;
    public string _name;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            AudioManager.AudioManager.m_instance.PlayMusic(Random.Range(0, 3));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            AudioManager.AudioManager.m_instance.PlaySFX(Random.Range(0, 3));
        }
    }
}