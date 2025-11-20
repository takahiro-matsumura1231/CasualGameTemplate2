using UnityEngine;

namespace Template.Core
{
    public class AudioManager : MonoBehaviourSingleton<AudioManager>
    {
        [Header("Audio Sources")]
        [SerializeField] private AudioSource bgmSource;
        [SerializeField] private AudioSource seSource;

        protected override void SingletonAwakened()
        {
            if (bgmSource == null)
            {
                bgmSource = gameObject.AddComponent<AudioSource>();
                bgmSource.playOnAwake = false;
                bgmSource.loop = true;
            }
            if (seSource == null)
            {
                seSource = gameObject.AddComponent<AudioSource>();
                seSource.playOnAwake = false;
                seSource.loop = false;
            }
        }

        public void PlayBGM(AudioClip clip, bool loop = true, float volume = 1f)
        {
            if (clip == null) return;
            bgmSource.clip = clip;
            bgmSource.loop = loop;
            bgmSource.volume = volume;
            bgmSource.Play();
        }

        public void StopBGM()
        {
            if (bgmSource.isPlaying) bgmSource.Stop();
        }

        public void PlaySE(AudioClip clip, float volume = 1f)
        {
            if (clip == null) return;
            seSource.PlayOneShot(clip, volume);
        }
    }
}


