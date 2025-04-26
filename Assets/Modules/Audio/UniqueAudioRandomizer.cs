using System.Collections.Generic;
using UnityEngine;

namespace Modules.Audio
{
    public sealed class UniqueAudioRandomizer
    {
        private readonly AudioClip[] _audioClips;
        private readonly List<AudioClip> _availableClips = new();
        
        public UniqueAudioRandomizer(params AudioClip[] clips)
        {
            _audioClips = clips;
        }
        
        public bool CanGetRandom => _audioClips.Length > 0;

        public AudioClip GetRandom()
        {
            if (CanGetRandom == false)
                throw new System.Exception("No audio clips available");
            
             if (_availableClips.Count == 0)
                 _availableClips.AddRange(_audioClips);
             
             int randomIndex = Random.Range(0, _availableClips.Count);
             AudioClip targetClip = _availableClips[randomIndex];
             _availableClips.Remove(targetClip);

             return targetClip;
        }
    }
}