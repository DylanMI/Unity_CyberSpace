using CyberSpace;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField]
    private AudioClip _clip = null;

    [ContextMenu("PlayTestSound")]
    private void PlayTestSound()
    {
        CyberSpaceManager.Instance.SoundManager.PlayOneShotEffect(_clip, new Vector2Int(5, 8), 1f);
    }
}