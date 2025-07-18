﻿using fNbt;
using Minecraft.City.Datapack.Generator.Builder;
using Minecraft.City.Datapack.Generator.Builder.Buildings;

namespace Minecraft.City.Datapack.Generator.Builder.Static;

// ReSharper disable once ClassNeverInstantiated.Global
public class StaticFileAssembler : IAssembler
{
	private readonly NbtFileFixer _fileFixer;

	public StaticFileAssembler(NbtFileFixer fileFixer)
	{
		_fileFixer = fileFixer;
	}

	public void Assemble()
	{
		var buildings = new DirectoryInfo("../../../nbts/buildings");

		var buildingFiles = buildings.GetFiles("*.*", SearchOption.AllDirectories);

		var staticFiles = buildingFiles;

		foreach (var file in staticFiles)
		{
			var directoryName = file.Directory.Name;
			var fileName = file.Name;

			var destinationDirectory = $"output/data/poke-cities/structure/{directoryName}";

			if (!Directory.Exists(destinationDirectory))
			{
				Directory.CreateDirectory(destinationDirectory);
			}

			var nbt = new NbtFile(file.ToString());	
			
			_fileFixer.FixFile(nbt);
			
			var destination = $"{destinationDirectory}/{fileName}";
			nbt.SaveToFile(destination, NbtCompression.GZip);
			
			Console.WriteLine($"Saved {nbt.FileName}");
		}
	}
}