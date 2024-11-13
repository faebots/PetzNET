﻿using PeNet;
using Vestris.ResourceLib;

namespace PetzNET
{
    public static class Extractor
    {
        public static IPetzFile Load(string path)
        {
            switch (Path.GetExtension(path).ToLower())
            {
                case ".dog":
                case ".cat":
                    return LoadBreed(path);
                default:
                    return null;
            }

        }

        public static BreedFile LoadBreed(string path)
        {
            var file = new BreedFile();
            using (ResourceInfo info = new ResourceInfo())
            {
                info.Load(path);
                var peFile = new PeFile(path);
                if (info.ResourceTypes.Select(rt => rt.Name).Contains("UNIBREED"))
                {
                    file.Version = PetzVersion.Unibreed;
                }
                else
                {
                    var imports = peFile.ImportedFunctions?.Select(f => f.DLL).Distinct() ?? new List<string>();
                    if (imports.Contains("Petz II.exe"))
                    {
                        file.Version = PetzVersion.PetzII;
                    }
                    else if (imports.Contains("Petz 3.exe"))
                    {
                        file.Version = PetzVersion.Petz3;
                    }
                    else if (imports.Contains("Petz 4.exe"))
                    {
                        file.Version = PetzVersion.Petz4;
                    }
                    else if (imports.Contains("Petz 5.exe"))
                    {
                        file.Version = PetzVersion.Petz5;
                    }
                    else
                    {
                        throw new InvalidDataException("Could not identify breed file type.");
                    }
                }

                var rcData = info.Resources.Where(r =>
                {
                    try
                    {
                        return r.Key.ResourceType == Kernel32.ResourceTypes.RT_RCDATA;
                    }
                    catch
                    {
                        return false;
                    }
                }).Select(r => r.Value[0]).First();

                file.RCData = new RCData(rcData.WriteAndGetBytes());
            }
            return file;
        }
    }
}
