using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UniRx;
using UniRx.Triggers;
using System.Collections;
using BodyNumber;

public class CameraEffect : MonoBehaviour {
    
    [SerializeField] private PostProcessVolume m_processManager;
    [SerializeField] private PostProcessProfile lowViewableFieldProfile;
    [SerializeField] private PostProcessProfile viewableFieldProfile;
    [SerializeField] private PostProcessProfile highViewableFieldProfile;

    [SerializeField] private PlayerController wholeBody;

    private void Awake()
    {
        
    }
    private void Start()
    {
        wholeBody = GameObject.FindWithTag("Body").GetComponent<PlayerController>();
        m_processManager.profile = lowViewableFieldProfile;
        
        this.UpdateAsObservable()
            .Where(_ => (wholeBody.bodyParts[Define.RIGHTEYE].activeSelf | wholeBody.bodyParts[Define.LEFTEYE].activeSelf))
            .Subscribe(_ => m_processManager.profile = viewableFieldProfile);
        
        this.UpdateAsObservable()
            .Where(_ => (wholeBody.bodyParts[Define.RIGHTEYE].activeSelf && wholeBody.bodyParts[Define.LEFTEYE].activeSelf))
            .Subscribe(_ => m_processManager.profile = highViewableFieldProfile);
    }
}