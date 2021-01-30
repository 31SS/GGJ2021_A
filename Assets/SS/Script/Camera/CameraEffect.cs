using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UniRx;
using System.Collections;

public class CameraEffect : MonoBehaviour {
    
    [SerializeField] private PostProcessVolume m_processManager;
    [SerializeField] private PostProcessProfile lowViewableFieldProfile;
    [SerializeField] private PostProcessProfile viewableFieldProfile;
    [SerializeField] private PostProcessProfile highViewableFieldProfile;

    [SerializeField] private PlayerController wholeBody;

    private void Awake()
    {
        wholeBody = GameObject.FindWithTag("Body").GetComponent<PlayerController>();
    }
    private void Start()
    {
        // m_processManager.profile = lowViewableFieldProfile;
    }
}