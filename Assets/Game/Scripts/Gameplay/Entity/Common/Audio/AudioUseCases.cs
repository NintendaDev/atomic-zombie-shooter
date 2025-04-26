using Atomic.Entities;
using Modules.Audio;
using Modules.Randomize;
using UnityEngine;

namespace Game.Gameplay.Entity.Common
{
    public static class AudioUseCases
    {
        public static bool TryPlayRandomSound(this IEntity entity, in UniqueAudioRandomizer randomizer, 
            float volumeScale = 1f)
        {
            if (TryGetClip(randomizer, out AudioClip audioClip) == false)
                return false;
            
            return TryPlaySound(entity, audioClip, volumeScale);
        }

        public static bool TryGetClip(in UniqueAudioRandomizer randomizer, out AudioClip audioClip)
        {
            audioClip = null;
            
            if (randomizer.CanGetRandom == false)
                return false;
            
            audioClip = randomizer.GetRandom();

            return true;
        }

        public static bool TryPlaySound(this IEntity entity, AudioClip audioClip, float volumeScale = 1f)
        {
            if (entity.HasAudioSource() == false)
                return false;
            
            AudioSource audioSource = entity.GetAudioSource();
            
            audioSource.Reset();
            audioSource.PlayOneShot(audioClip, volumeScale);

            return true;
        }

        public static bool TryPlayRandomSound(this IEntity entity, AudioClip[] audioClips, float volumeScale = 1f)
        {
            if (entity.HasAudioSource() == false)
                return false;
            
            return TryPlayRandomSound(entity.GetAudioSource(), audioClips, volumeScale);
        }
        
        public static bool TryPlayRandomSound(this AudioSource audioSource, AudioClip[] audioClips, 
            UniqueAudioRandomizer randomizer, float volumeScale = 1f)
        {
            if (audioClips.Length == 0)
                return false;
            
            audioSource.Reset();
            audioSource.PlayOneShot(audioClips.GetRandom(), volumeScale);

            return true;
        }

        public static bool TryPlayRandomSound(this AudioSource audioSource, AudioClip[] audioClips, 
            float volumeScale = 1f)
        {
            if (audioClips.Length == 0)
                return false;
            
            audioSource.Reset();
            audioSource.PlayOneShot(audioClips.GetRandom(), volumeScale);

            return true;
        }

        public static bool TryPlayRandomSound(this AudioSource audioSource, AudioClip[] audioClips,
            float minPitch, float maxPitch, float volumeScale = 1f)
        {
            audioSource.Reset();
            audioSource.pitch = Random.Range(minPitch, maxPitch);
            
            audioSource.PlayOneShot(audioClips.GetRandom(), volumeScale);

            return true;
        }
        
        public static void Reset(this AudioSource audioSource)
        {
            audioSource.pitch = 1f;
        }
    }
}