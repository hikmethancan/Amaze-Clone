using MoreMountains.NiceVibrations;

namespace Abstract.Base_Template
{
    public static class HapticSystem
    {
        public static bool HapticOff;
        
        public static void PlayPreset(this HapticTypes hapticPatterns)
        {
            if(HapticOff) return;
            
            MMVibrationManager.Haptic(hapticPatterns);
        }
    }

}