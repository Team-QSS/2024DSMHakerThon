using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

namespace Managers
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : SingleMono<AudioManager>
    {
        private static readonly Dictionary<string, AudioClip> Clips = new();
        private AudioSource audioSource;
        private readonly List<Action<AudioSource>> eventHandlers = new();

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (eventHandlers.Count == 0 || audioSource.isPlaying) return;
            foreach (var listener in eventHandlers.ToList()) listener(audioSource);
        }
        
        public static void AddEventHandlerInstance(Action<AudioSource> action) => Instance.AddEventHandler(action);
        public static void ClearEventHandlerInstance() => Instance.ClearEventHandler();
        public static void SetAsBackgroundMusicInstance(string path, bool loop = false) => Instance.SetAsBackgroundMusic(path, loop);
        public static void StopAllSoundsInstance() => Instance.StopAllSounds();
        public static void PlaySoundInstance(string path) => Instance.PlaySound(path);

        private void PlaySound(string path)
        {
            var clip = GetClip(path);
            if (clip) audioSource.PlayOneShot(clip);
        }

        private void SetAsBackgroundMusic(string path, bool loop = false)
        {
            var clip = GetClip(path);
            if (!clip) return;
            audioSource.clip = clip;
            audioSource.loop = loop;
            audioSource.Play();
        }

        private void AddEventHandler(Action<AudioSource> action) => eventHandlers.Add(action);

        private void ClearEventHandler() => eventHandlers.Clear();

        private void StopAllSounds() => audioSource.Stop();

        private static AudioClip GetClip(string path)
        {
            if (Clips.TryGetValue(path, out var clip)) return clip;
            return !(clip = Resources.Load<AudioClip>(path)) ? null : Clips[path] = clip;
        }
    }
}