using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.Commands.MtnDewIt.ConvertCache 
{
    public class ui_eldewrito_common_map_bitmaps_030_outskirts_bitmap : TagFile
    {
        public ui_eldewrito_common_map_bitmaps_030_outskirts_bitmap(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\030_outskirts");
            var bitm = CacheContext.Deserialize<Bitmap>(Stream, tag);
            AddBitmap(bitm, 0, Stream, $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\030_outskirts.dds");
            CacheContext.Serialize(Stream, tag, bitm);
        }
    }
}