namespace VertigoGames.SpinModule.Runtime.Scripts.Utility
{
    public static class SpinHelper
    {
        public static bool IsSafeZone(int index)
        {
            if (index == 1)
            {
                return true;
            }
            
            return index % 5 == 0 && !IsSuperZone(index);
        }
        
        public static bool IsSuperZone(int index)
        {
            return index % 30 == 0;
        }
    }
}