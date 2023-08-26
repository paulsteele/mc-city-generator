﻿using System.Text.Json.Serialization;

namespace Minecraft.City.Datapack.Generator.Content.PackMetadata;

public class Pack
{
	[JsonPropertyName("pack_format")] public int PackFormat => 10;
	[JsonPropertyName("description")] public string Description => "Poke Cities";
}