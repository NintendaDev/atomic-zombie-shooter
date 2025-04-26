namespace Modules.Randomize
{
    public static class RandomExtensions
    {
        public static bool TryGetRandom<T>(this T[] array, out T result)
        {
            result = default;
            
            if (array == null)
                return false;
            
            result = GetRandom(array);

            return true;
        }
        
        public static T GetRandom<T>(this T[] array)
        {
            if (array == null || array.Length == 0)
                throw new System.Exception("Array is empty");
            
            return array[UnityEngine.Random.Range(0, array.Length)];
        }
    }
}