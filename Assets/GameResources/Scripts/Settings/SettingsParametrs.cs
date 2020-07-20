namespace Settings
{
    public static class SettingsParametrs
    {
        public static float CamDistanceCurrent
        {
            get
            {
                return camDistanceCurrent;
            }
        }
        public static bool IsMute
        {
            get
            {
                return isMute;
            }
        }

        public static float SoundVolume
        {
            get
            {
                return soundVolume;
            }
        }

        public static float MusicVolume
        {
            get
            {
                return musicVolume;
            }
        }

        public static float CamDistanceShift
        {
            get
            {
                return camDistanceShift;
            }
        }

        private static float soundVolume = 0.5f;
        private static float musicVolume = 0f;

        private static float soundVolumeOld = soundVolume;
        private static float musicVolumeOld = musicVolume;

        private static bool isMute = false;

        public static int QualityValue = 3;

        private static float camDistanceMin = 20f;
        private static float camDistanceMax = 200f;
        private static float camDistanceCurrent = camDistanceMax;
        private static float camDistanceShift = 1f;

        /// <summary>
        /// Устанавливаем дистанцию отрисовки камеры
        /// </summary>
        public static void SetCamDistance(float value)
        {
            camDistanceShift = value;
            camDistanceCurrent = (camDistanceMax - camDistanceMin) *
                                  value + camDistanceMin;
        }

        /// <summary>
        /// Установить mute
        /// </summary>
        /// <param name="isMute"></param>
        public static void SetMute(bool isMute)
        {
            SettingsParametrs.isMute = isMute;
            if (isMute)
            {
                soundVolumeOld = soundVolume;
                musicVolumeOld = musicVolume;
                soundVolume = 0f;
                musicVolume = 0f;
            }
            else
            {
                soundVolume = soundVolumeOld;
                musicVolume = musicVolumeOld;
            }
        }

        /// <summary>
        /// Устанавливаем громкость звуков
        /// </summary>
        /// <param name="volume"></param>
        public static void SetSoundVolume(float volume)
        {
            soundVolume = volume;
        }

        /// <summary>
        /// Устанавливаем громкость музыки
        /// </summary>
        /// <param name="volume"></param>
        public static void SetMusicVolume(float volume)
        {
            musicVolume = volume;
        }
    }
}