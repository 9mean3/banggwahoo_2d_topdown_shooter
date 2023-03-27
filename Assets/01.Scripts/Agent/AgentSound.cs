using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSound : AudioPlayer
{
    public AudioClip stepSound, hitClip, deathClip;

    public void PlayStepSound()
    {
        PlayClipWithVariablePitch(stepSound);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
