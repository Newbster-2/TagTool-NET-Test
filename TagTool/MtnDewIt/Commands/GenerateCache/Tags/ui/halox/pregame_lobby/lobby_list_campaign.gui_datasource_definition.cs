using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.GenerateCache.Tags 
{
    public class ui_halox_pregame_lobby_lobby_list_campaign_gui_datasource_definition : TagFile
    {
        public ui_halox_pregame_lobby_lobby_list_campaign_gui_datasource_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
        (
            cache,
            cacheContext,
            stream
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            Stream = stream;
            TagData();
        }

        public override void TagData()
        {
            var tag = GetCachedTag<GuiDatasourceDefinition>($@"ui\halox\pregame_lobby\lobby_list_campaign");
            var dsrc = CacheContext.Deserialize<GuiDatasourceDefinition>(Stream, tag);
            dsrc.Name = CacheContext.StringTable.GetOrAddString($@"lobby_list");
            dsrc.Elements = new List<GuiDatasourceDefinition.DatasourceElementBlock>
            {
                new GuiDatasourceDefinition.DatasourceElementBlock
                {
                    StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                    {
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"name"),
                            Value = CacheContext.StringTable.GetOrAddString($@"switch_lobby"),
                        },
                    },
                },
                new GuiDatasourceDefinition.DatasourceElementBlock
                {
                    StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                    {
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"name"),
                            Value = CacheContext.StringTable.GetOrAddString($@"select_network_mode"),
                        },
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"target"),
                            Value = CacheContext.StringTable.GetOrAddString($@"network_mode"),
                        },
                    },
                },
                new GuiDatasourceDefinition.DatasourceElementBlock
                {
                    StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                    {
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"name"),
                            Value = CacheContext.StringTable.GetOrAddString($@"select_skulls"),
                        },
                    },
                },
                new GuiDatasourceDefinition.DatasourceElementBlock
                {
                    StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                    {
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"name"),
                            Value = CacheContext.StringTable.GetOrAddString($@"select_scoring"),
                        },
                    },
                },
                new GuiDatasourceDefinition.DatasourceElementBlock
                {
                    StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                    {
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"name"),
                            Value = CacheContext.StringTable.GetOrAddString($@"switch_campaign_level"),
                        },
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"target"),
                            Value = CacheContext.StringTable.GetOrAddString($@"level"),
                        },
                    },
                },
                new GuiDatasourceDefinition.DatasourceElementBlock
                {
                    StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                    {
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"name"),
                            Value = CacheContext.StringTable.GetOrAddString($@"switch_campaign_difficulty"),
                        },
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"target"),
                            Value = CacheContext.StringTable.GetOrAddString($@"difficulty"),
                        },
                    },
                },
                new GuiDatasourceDefinition.DatasourceElementBlock
                {
                    StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                    {
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"name"),
                            Value = CacheContext.StringTable.GetOrAddString($@"switch_selected_mod"),
                        },
                    },
                },
                new GuiDatasourceDefinition.DatasourceElementBlock
                {
                    StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                    {
                        new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"name"),
                            Value = CacheContext.StringTable.GetOrAddString($@"start_game"),
                        },
                    },
                },
            };
            CacheContext.Serialize(Stream, tag, dsrc);
        }
    }
}
