using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UFrame.Common;
using UFrame.ResourceManagement;
namespace UFrame.Sound
{
    public class SoundManager : SingletonMono<SoundManager>
    {
        AudioSource BGMusicSource = null;
        AudioSource normalSource = null;
        void Start()
        {
            BGMusicSource = gameObject.AddComponent<AudioSource>();
            BGMusicSource.loop = true;

            normalSource = gameObject.AddComponent<AudioSource>();
        }

        public void PlayBGMusic(string musicPath)
        {
            //AudioClip clip = Resources.Load(musicPath) as AudioClip;
            var getter = ResHelper.LoadAsset(musicPath);
            AudioClip clip = getter.Get(gameObject) as AudioClip;
            BGMusicSource.clip = clip;
            BGMusicSource.Play();
        }

        public void PlaySound(string soundPath)
        {
            //AudioClip clip = Resources.Load(soundPath) as AudioClip;
            var getter = ResHelper.LoadAsset(soundPath);
            AudioClip clip = getter.Get(gameObject) as AudioClip;
            normalSource.PlayOneShot(clip);
        }
    }
}

