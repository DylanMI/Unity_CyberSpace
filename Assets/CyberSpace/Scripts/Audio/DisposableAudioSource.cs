using System.Collections;
using UnityEngine;

namespace CyberSpace
{
    public class DisposableAudioSource
    {
        public GameObject Obj = null;
        private AudioSource _source = null;
        public DisposableAudioSource()
        {
            Obj = new GameObject("CYS_DisposableAudioSource");
            _source = Obj.AddComponent<AudioSource>();
        }

        public void Play(AudioClip clip, float volume = 1f, bool dispose = true)
        {
            _source.PlayOneShot(clip);
            if (dispose)
            {
                Obj.AddComponent<EmptyBehaviour>().StartCoroutine(DisposeAfterPlaying());
            }
        }

        private IEnumerator DisposeAfterPlaying()
        {
            while (_source.isPlaying)
                yield return new WaitForEndOfFrame();

            GameObject.Destroy(Obj);
            yield return null;
        }
    }
}
