using TagTool.Cache;
using TagTool.Common;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static TagTool.Tags.TagFieldFlags;

namespace TagTool.Tags.Definitions.Gen4
{
    [TagStructure(Name = "global_cache_file_pixel_shaders", Tag = "gpix", Size = 0x1C)]
    public class GlobalCacheFilePixelShaders : TagStructure
    {
        public int ShaderCount;
        public int CachedShaderCount;
        public int TotalMemorySize;
        public int CachedMemorySize;
        public List<CompiledPixelShaderBlock> CompiledShaders;
        
        [TagStructure(Size = 0x58)]
        public class CompiledPixelShaderBlock : TagStructure
        {
            public RasterizerCompiledShaderStruct CompiledShaderSplut;
            public int RuntimeShader;
            
            [TagStructure(Size = 0x54)]
            public class RasterizerCompiledShaderStruct : TagStructure
            {
                public ShaderFlags ShaderFlags1;
                public byte[] XenonCompiledShader; // xenon compiled shader}
                public byte[] Dx9CompiledShader; // dx9 compiled shader}
                public GlobalRasterizerConstantTableStruct XenonRasterizerConstantTable;
                public GlobalRasterizerConstantTableStruct Dx9RasterizerConstantTable;
                public uint Gprs; // gprs}
                public int CacheFileReference;
                
                [Flags]
                public enum ShaderFlags : uint
                {
                    RequiresConstantTable = 1 << 0
                }
                
                [TagStructure(Size = 0x10)]
                public class GlobalRasterizerConstantTableStruct : TagStructure
                {
                    public List<RasterizerConstantBlock> Constants;
                    public RasterizerConstantTableTypeEnum Type;
                    [TagField(Length = 0x3, Flags = TagFieldFlags.Padding)]
                    public byte[] Padding;
                    
                    public enum RasterizerConstantTableTypeEnum : sbyte
                    {
                        Vertex,
                        Pixel
                    }
                    
                    [TagStructure(Size = 0x8)]
                    public class RasterizerConstantBlock : TagStructure
                    {
                        public StringId ConstantName;
                        public ushort RegisterStart;
                        public byte RegisterCount;
                        public RegisterSetEnum RegisterSet;
                        
                        public enum RegisterSetEnum : sbyte
                        {
                            Bool,
                            Int,
                            Float,
                            Sampler,
                            VertexBool,
                            VertexInt,
                            VertexFloat,
                            VertexSampler
                        }
                    }
                }
            }
        }
    }
}
