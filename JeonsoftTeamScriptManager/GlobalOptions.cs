using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;

namespace JeonsoftTeamScriptManager
{
    public sealed class GlobalOptions
    {
        private static GlobalOptions instance;
        public const string ROOT_KEY = "Software\\Jeonsoft Corporation\\Jeonsoft Team Script Manager";
        public const string SETTINGS_KEY = "User Settings";

        private GlobalOptions()
        {
            LoadSettings();
        }

        public static GlobalOptions Instance
        {
            get
            {
                if (instance == null)
                    instance = new GlobalOptions();
                return instance;
            }
        }

        private bool KeyExists(string key)
        {
            RegistryKey rkey = Registry.CurrentUser.OpenSubKey(key);
            bool exists = rkey != null;
            if (rkey != null)
                rkey.Close();
            return exists;
        }

        private bool SubKeyExists(RegistryKey parent, string subKey)
        {
            RegistryKey key = parent.OpenSubKey(subKey);
            bool exists = key != null;
            if (key != null)
                key.Close();
            return exists;
        }

        public RegistryKey CreateRootKey(string subkey)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(subkey);
            return key;
        }

        public RegistryKey CreateSubKey(RegistryKey parentKey, string subKey)
        {
            RegistryKey key = parentKey.CreateSubKey(subKey);
            return key;
        }

        private RegistryKey GetRootKey()
        {
            RegistryKey root;
            if (KeyExists(ROOT_KEY))
                root = Registry.CurrentUser.OpenSubKey(ROOT_KEY, true);
            else
                root = CreateRootKey(ROOT_KEY);
            return root;
        }

        private void SetKeyItemValue(RegistryKey root, string subKey, string name, bool value)
        {
            RegistryKey key;
            if (SubKeyExists(root, subKey))
                key = root.OpenSubKey(subKey, true);
            else
                key = CreateSubKey(root, subKey);
            key.SetValue(name, value, RegistryValueKind.String);
            if (key != null)
                key.Close();
        }

        private void SetKeyItemValue(RegistryKey root, string subKey, string name, string value)
        {
            RegistryKey key;
            if (SubKeyExists(root, subKey))
                key = root.OpenSubKey(subKey, true);
            else
                key = CreateSubKey(root, subKey);
            key.SetValue(name, value, RegistryValueKind.String);
            if (key != null)
                key.Close();
        }

        private string ReadKeyItemValue(RegistryKey root, string subKey, string name, string defaultValue)
        {
            string value = string.Empty;
            if (KeyExists(ROOT_KEY))
            {
                if (SubKeyExists(root, subKey))
                {
                    RegistryKey key = root.OpenSubKey(subKey);
                    value = key.GetValue(name, defaultValue).ToString();
                }
            }
            return value;
        }

        private bool ReadKeyItemValue(RegistryKey root, string subKey, string name, bool defaultValue)
        {
            bool value = false;
            if (KeyExists(ROOT_KEY))
            {
                if (SubKeyExists(root, subKey))
                {
                    RegistryKey key = root.OpenSubKey(subKey);
                    value = bool.Parse(key.GetValue(name, defaultValue).ToString());
                }
            }
            return value;
        }

        private void WriteUserSettings(RegistryKey root, string name, string value)
        {
            SetKeyItemValue(root, SETTINGS_KEY, name, value);
        }

        private void WriteUserSettings(RegistryKey root, string name, bool value)
        {
            SetKeyItemValue(root, SETTINGS_KEY, name, value);
        }

        private string ReadStringUserSettings(RegistryKey root, string name)
        {
            string value = ReadKeyItemValue(root, SETTINGS_KEY, name, string.Empty);
            return value;
        }

        private bool ReadBooleanUserSettings(RegistryKey root, string name)
        {
            bool value = ReadKeyItemValue(root, SETTINGS_KEY, name, false);
            return value;
        }

        public void SaveSettings()
        {
            RegistryKey root = GetRootKey();
            WriteUserSettings(root, "Stash Config Name", StashConfigName);
            WriteUserSettings(root, "Merge File Output Directory", MergeFileOutputDirectory);
            WriteUserSettings(root, "Stash Manifest Directory", StashManifestDirectory);
            WriteUserSettings(root, "Prefixed Files Directory", PrefixedFilesDirectory);
            WriteUserSettings(root, "Postfixed Files Directory", PostfixedFilesDirectory);
            WriteUserSettings(root, "Default Directories", DefaultDirectories);
            WriteUserSettings(root, "Include Prefixed Files", IncludePrefixedFiles);
            WriteUserSettings(root, "Include PostFixed Files", IncludePostFixedFiles);
            WriteUserSettings(root, "Enable Default Directories", EnableDefaultDirectories);
            WriteUserSettings(root, "Enable File Tracking", EnableFileTracking);
            WriteUserSettings(root, "Enable Auto Check Updates", EnableAutoCheckUpdates);
            WriteUserSettings(root, "Resolve Host Name Addresses", ResolveHostNameAddresses);
            WriteUserSettings(root, "Use Full Path when Adding to Stash", SaveStashFilesWithFullPath);
            WriteUserSettings(root, "Save Stash on Merge", SaveStashOnMerge);
            if (root != null)
                root.Close();
        }

        public void LoadSettings()
        {
            RegistryKey root = GetRootKey();
            StashConfigName = ReadStringUserSettings(root, "Stash Config Name");
            MergeFileOutputDirectory = ReadStringUserSettings(root, "Merge File Output Directory");
            StashManifestDirectory = ReadStringUserSettings(root, "Stash Manifest Directory");
            PrefixedFilesDirectory = ReadStringUserSettings(root, "Prefixed Files Directory");
            PostfixedFilesDirectory = ReadStringUserSettings(root, "Postfixed Files Directory");
            DefaultDirectories = ReadStringUserSettings(root, "Default Directories");
            IncludePrefixedFiles = ReadBooleanUserSettings(root, "Include Prefixed Files");
            IncludePostFixedFiles = ReadBooleanUserSettings(root, "Include PostFixed Files");
            EnableDefaultDirectories = ReadBooleanUserSettings(root, "Enable Default Directories");
            EnableFileTracking = ReadBooleanUserSettings(root, "Enable File Tracking");
            EnableAutoCheckUpdates = ReadBooleanUserSettings(root, "Enable Auto Check Updates");
            ResolveHostNameAddresses = ReadBooleanUserSettings(root, "Resolve Host Name Addresses");
            SaveStashFilesWithFullPath = ReadBooleanUserSettings(root, "Use Full Path when Adding to Stash");
            SaveStashOnMerge = ReadBooleanUserSettings(root, "Save Stash on Merge");
            if (root != null)
                root.Close();
        }

        private bool saveStashOnMerge;
        public bool SaveStashOnMerge
        {
            get { return saveStashOnMerge; }
            set { saveStashOnMerge = value; }
        }
        private string stashConfigName;

        public string StashConfigName
        {
            get { return stashConfigName; }
            set { stashConfigName = value; }
        }

        private string defaultDirectories;

        public string DefaultDirectories
        {
            get { return defaultDirectories; }
            set { defaultDirectories = value; }
        }
        private bool enableAutoCheckUpdates;

        public bool EnableAutoCheckUpdates
        {
            get { return enableAutoCheckUpdates; }
            set { enableAutoCheckUpdates = value; }
        }

        private bool enableDefaultDirectories;

        public bool EnableDefaultDirectories
        {
            get { return enableDefaultDirectories; }
            set { enableDefaultDirectories = value; }
        }
        private bool enableFileTracking;

        public bool EnableFileTracking
        {
            get { return enableFileTracking; }
            set { enableFileTracking = value; }
        }

        private bool resolveHostNameAddresses;

        public bool ResolveHostNameAddresses
        {
            get { return resolveHostNameAddresses; }
            set { resolveHostNameAddresses = value; }
        }

        private bool addToStashWithFullPath;

        public bool SaveStashFilesWithFullPath
        {
            get { return addToStashWithFullPath; }
            set { addToStashWithFullPath = value; }
        }

        private bool includePrefixedFiles;
        
        public bool IncludePrefixedFiles
        {
            get { return includePrefixedFiles; }
            set { includePrefixedFiles = value; }
        }

        private bool includePostFixedFiles;
        public bool IncludePostFixedFiles
        {
            get { return includePostFixedFiles; }
            set { includePostFixedFiles = value; }
        }

        private string mergeFileOutputDirectory;

        public string MergeFileOutputDirectory
        {
            get { return mergeFileOutputDirectory; }
            set { mergeFileOutputDirectory = value; }
        }
        private string stashManifestDirectory;

        public string StashManifestDirectory
        {
            get { return stashManifestDirectory; }
            set { stashManifestDirectory = value; }
        }

        private string prefixedFilesDirectory;

        public string PrefixedFilesDirectory
        {
            get { return prefixedFilesDirectory; }
            set { prefixedFilesDirectory = value; }
        }
        private string postfixedFilesDirectory;

        public string PostfixedFilesDirectory
        {
            get { return postfixedFilesDirectory; }
            set { postfixedFilesDirectory = value; }
        }
        
    }
}
