namespace Settings
{
    public static class SettingsParametrs
    {
        public static float SoundVolume = 0.5f;
        public static float MusicVolume = 0f;

        public static float SoundVolumeOld = SoundVolume;
        public static float MusicVolumeOld = MusicVolume;

        public static bool IsMute = false;

        public static float CamDistanceMin
        {
            get
            {
                return 20f;
            }
        }
        public static float CamDistanceMax
        {
            get
            {
                return 200f;
            }
        }

        public static float CamDistanceCurrent = CamDistanceMax;
    }
}