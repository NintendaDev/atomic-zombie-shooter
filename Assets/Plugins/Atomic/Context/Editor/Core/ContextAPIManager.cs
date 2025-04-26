#if UNITY_EDITOR
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace Atomic.Contexts
{
    [InitializeOnLoad]
    internal static class ContextAPIManager
    {
        private const string ASSET_NAME = "ContextAPI";

        private static List<ContextAPIAsset> _assets;

        static ContextAPIManager()
        {
            LoadAssets();
        }

        public static void CompileAPI()
        {
            LoadAssets();

            if (_assets == null)
                return;

            for (int i = 0, cont = _assets.Count; i < cont; i++)
            {
                ContextAPIAsset asset = _assets[i];
                if (!asset.IsValid)
                    continue;

                IContextAPIConfiguration configuration = asset.GetConfiguration();
                ContextAPIGenerator.CreateFile(configuration);
            }

            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();
        }

        public static void RefreshAPI()
        {
            if (_assets == null)
                return;

            for (int i = 0, cont = _assets.Count; i < cont; i++)
            {
                ContextAPIAsset asset = _assets[i];
                if (!asset.IsValid)
                    continue;

                IContextAPIConfiguration configuration = asset.GetConfiguration();
                ContextAPIGenerator.UpdateFile(configuration);
            }
        }

        public static void CreateAPI()
        {
            string filePath = EditorUtility.SaveFilePanel(
                "Create Context API...",
                "Assets",
                "SampleContextAPI.yaml",
                "yaml"
            );

            using StreamWriter writer = new StreamWriter(filePath);
            writer.Write(ContextAPITemplate.Value);

            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();
        }

        private static void LoadAssets()
        {
            string[] assetPaths = AssetDatabase.FindAssets(ASSET_NAME)
                .Select(AssetDatabase.GUIDToAssetPath)
                .Where(IsContextAPIFile)
                .ToArray();

            int count = assetPaths.Length;
            _assets = new List<ContextAPIAsset>(count);

            for (int i = 0; i < count; i++)
            {
                string filePath = assetPaths[i];
                _assets.Add(new ContextAPIAsset(filePath));
            }
        }

        private static bool IsContextAPIFile(string path)
        {
            if (!path.EndsWith(".yaml") && !path.EndsWith(".yml"))
                return false;

            IEnumerable<string> lines = File.ReadLines(path);
            string first = lines.FirstOrDefault();
            if (string.IsNullOrEmpty(first))
                return false;

            return first != null && Regex.IsMatch(first, @"^header\s*:\s*ContextAPI$");
        }
    }
}
#endif
