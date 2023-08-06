namespace Abstract.Base_Template
{
    public static class DataManager
    {
        #region Static

        public static void SaveData<T>(T dataToSave, int uniqueID) where T : SavableEntity<T>
        {
            var path = $"{dataToSave.GetKey()}_{uniqueID}.es3";
            var dataKey = dataToSave.GetKey();
            ES3.Save(dataKey, dataToSave, path);
        }

        public static T LoadData<T>(string key, int uniqueId, T def = default) where T : SavableEntity<T>
        {
            var path = $"{key}_{uniqueId}.es3";
            if (!ES3.FileExists(path)) return def;
            if (ES3.KeyExists(key, path))
            {
                T objectToReturn = ES3.Load<T>(key, path);
                return objectToReturn;
            }

            return def;
        }

        #endregion
    }
}