using System;
using System.Data;
using System.Collections.Generic;
using HTQuanLyThuCung.DataAccess;
using System.Data.SqlClient;

namespace HTQuanLyThuCung.Helpers
{
    public static class SystemSettings
    {
        // Cache để tránh query database nhiều lần
        private static Dictionary<string, string> _cache = new Dictionary<string, string>();
        private static bool _isLoaded = false;

        public static int MaxLoginAttempts
        {
            get { return GetIntSetting("MAX_LOGIN_ATTEMPTS", 5); }
        }

        public static int LockoutMinutes
        {
            get { return GetIntSetting("LOCKOUT_MINUTES", 15); }
        }

        public static int ErrorUsernameExists
        {
            get { return GetIntSetting("ERROR_USERNAME_EXISTS", -1); }
        }

        public static int ErrorEmailExists
        {
            get { return GetIntSetting("ERROR_EMAIL_EXISTS", -2); }
        }

        private static int GetIntSetting(string settingKey, int defaultValue)
        {
            string value = GetSetting(settingKey);

            if (!string.IsNullOrEmpty(value) && int.TryParse(value, out int result))
            {
                return result;
            }

            return defaultValue;
        }

        private static string GetSetting(string settingKey)
        {
            if (!_isLoaded)
            {
                LoadSettingsFromDatabase();
            }

            if (_cache.ContainsKey(settingKey))
            {
                return _cache[settingKey];
            }

            return null;
        }

        private static void LoadSettingsFromDatabase()
        {
            try
            {
                DataTable bangDuLieu = DatabaseHelper.ExecuteStoredProcedure("sp_GetAllSystemSettings");

                foreach (DataRow dong in bangDuLieu.Rows)
                {
                    string key = dong["SettingKey"].ToString();
                    string value = dong["SettingValue"].ToString();
                    _cache[key] = value;
                }

                _isLoaded = true;
            }
            catch
            {
                _isLoaded = true;
            }
        }

        public static string GetSettingValue(string settingKey)
        {
            try
            {
                SqlParameter[] thamSo = new SqlParameter[]
                {
                new SqlParameter("@SettingKey", settingKey)
                };

                DataTable bangDuLieu = DatabaseHelper.ExecuteStoredProcedure("sp_GetSystemSetting", thamSo);

                if (bangDuLieu.Rows.Count > 0)
                {
                    return bangDuLieu.Rows[0]["SettingValue"].ToString();
                }
            }
            catch
            {
            }

            return null;
        }

        public static void Reset()
        {
            _cache.Clear();
            _isLoaded = false;
        }
    }
}