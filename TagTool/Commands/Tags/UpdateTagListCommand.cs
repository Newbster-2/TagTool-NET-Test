using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Commands.Common;

namespace TagTool.Commands.Tags
{
    class UpdateTagListCommand : Command
    {
        private GameCache Cache { get; }

        public static Dictionary<int, string> tagNameTable { get; set; }

        public enum TagListVersion : int
        {
            ElDewrito,
            ElDewritoLegacy,
            ElDewritoLegacyLegacy,
            MS23,
        }

        public UpdateTagListCommand(GameCache cache) : base
        (
            false,
            "UpdateTagList",
            "Updates tag name table based on the specified tag list",
            "UpdateTagList <TagListVersion>",
            "Updates tag name table based on the specified tag list"
        )
        {
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            string jsonData = "";

            if (args.Count != 1)
                return new TagToolError(CommandError.ArgCount);

            if (!Enum.TryParse(args[0], true, out TagListVersion tagListVersion))
                return new TagToolError(CommandError.ArgInvalid);

            // TODO: Figure out how to route the file path through a handler (the folder tree is static)
            switch (tagListVersion)
            {
                case TagListVersion.ElDewrito:
                    jsonData = File.ReadAllText($@"{JSONFileTree.JSONBinPath}eldewrito_tags.json");
                    break;
                case TagListVersion.ElDewritoLegacy:
                    jsonData = File.ReadAllText($@"{JSONFileTree.JSONBinPath}eldewrito_legacy_tags.json");
                    break;
                case TagListVersion.ElDewritoLegacyLegacy:
                    jsonData = File.ReadAllText($@"{JSONFileTree.JSONBinPath}eldewrito_legacy_legacy_tags.json");
                    break;
                case TagListVersion.MS23:
                    jsonData = File.ReadAllText($@"{JSONFileTree.JSONBinPath}ms23_tags.json");
                    break;
            }

            tagNameTable = JsonConvert.DeserializeObject<Dictionary<int, string>>(jsonData);

            if (Cache is GameCacheHaloOnline)
            {
                var cache = Cache as GameCacheHaloOnline;

                foreach (var tag in cache.TagCache.NonNull())
                {
                    if (tagNameTable.TryGetValue(tag.Index, out string name))
                    {
                        tag.Name = name;
                    }
                }

                cache.SaveTagNames();
            }

            if (Cache is GameCacheModPackage)
            {
                var cache = Cache as GameCacheModPackage;

                foreach (var tag in cache.TagCache.NonNull())
                {
                    if (tagNameTable.TryGetValue(tag.Index, out string name))
                    {
                        tag.Name = name;
                    }
                }

                cache.SaveTagNames();
            }

            return true;
        }
    }
}