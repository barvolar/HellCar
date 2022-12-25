using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundHandler : MonoBehaviour
{
    [SerializeField] private Turret _turret;
    [SerializeField] private AudioClip _shootClip;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _turret.Fired += OnFired;
    }

    private void OnDisable()
    {
        _turret.Fired -= OnFired;
    }
    private void OnFired()
    {
        _audioSource.PlayOneShot(_shootClip);
    }
}
