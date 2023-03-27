using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAudio : AudioPlayer
{
    public AudioClip ShootBulletClip = null, outOfBulletClip = null, reloadClip = null;

    public void PlayShootSound()
    {
        PlayClip(ShootBulletClip);
    }
    public void PlayOutOfBulletClip()
    {
        PlayClip(ShootBulletClip);
    }
    public void PlayReloadClip()
    {
        PlayClip(ShootBulletClip);
    }
}
