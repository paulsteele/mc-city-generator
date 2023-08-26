﻿namespace Minecraft.City.Datapack.Generator.Writers;

public class NbtCopyWriter
{
	public void Serialize()
	{
		var path = $"output/data/poke-cities/structures";
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}

		var directories = Directory.GetDirectories("../../../nbts");
		
		foreach (var directory in directories)
		{
			CopyDirectory.IO.CopyDirectory(directory, path);
		}
	}
}