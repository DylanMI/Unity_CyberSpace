using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CyberSpace
{
    /// <summary>
    /// Handles the CyberSpace sound effects, handles background sounds and general CyberSpace sounds
    /// </summary>
    public class CyberSpaceSoundManager
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

        public void SetAmbience(AudioClip clip)
        {

        }

        public void PlayOneShotEffect(AudioClip clip, Vector2Int coordinate, float volume)
        {
            CyberSpaceTerrainObject terrainObj = null;
            if (terrainObj = CyberSpaceManager.Instance.TerrainManager.GetGridObjectAtCoordinate(coordinate))
            {
                MeshRenderer mr = terrainObj.GetComponent<MeshRenderer>();
                Vector3 center = mr.bounds.center;
                float height = mr.bounds.extents.y;
                PlayOneShotEffect(clip, center + new Vector3(0, height, 0), volume);
            }
            else
                Debug.LogError($"CyberSpaceSoundManager::PlayOneShotEffect -> Could not find object at coordinate: {coordinate}");
        }

        public void PlayOneShotEffect(AudioClip clip, Vector3 position, float volume)
        {
            var disposableAudioSource = new DisposableAudioSource();
            disposableAudioSource.Obj.transform.position = position;
            disposableAudioSource.Play(clip, volume, true);
        }
    }
}
