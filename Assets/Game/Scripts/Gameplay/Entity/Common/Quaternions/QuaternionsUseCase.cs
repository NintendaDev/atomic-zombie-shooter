using UnityEngine;

namespace Game.Gameplay.Entity.Common
{
    public static class QuaternionsUseCase
    {
        public static Quaternion MakeSpreadRotation(this Quaternion initialRotation, float spread)
        {
            float randomPitch = Random.Range(-spread, spread);
            float randomYaw = Random.Range(-spread, spread);
            float randomRoll = Random.Range(-spread, spread);
            
            Quaternion spreadRotation = Quaternion.Euler(randomPitch, randomYaw, randomRoll);
            
            return initialRotation * spreadRotation;
        }
    }
}