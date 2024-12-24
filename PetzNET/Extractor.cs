using PeNet;
using System.Drawing;
using System.Runtime.InteropServices;
using Vestris.ResourceLib;

namespace PetzNET
{
    public static class Extractor
    {
        /// <summary>
        /// Load a Petz file from a file path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IPetzFile Load(string path)
        {
            switch (Path.GetExtension(path).ToLower())
            {
                case ".dog":
                case ".cat":
                    return LoadBreed(path);
                //TODO: additional file types
                case ".toy":
                case ".clo":
                case ".pet":
                case ".env":
                default:
                    return null;
            }

        }

        /// <summary>
        /// Load a breed file from a file path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        public static BreedFile LoadBreed(string path)
        {
            var file = new BreedFile();
            using (ResourceInfo info = new ResourceInfo())
            {
                info.Load(path);
                var peFile = new PeFile(path);

                //Identify game version or unibreed
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

                var rcData = info.Resources.Where(r => r.Key.TypeName == "RT_RCDATA").Select(r => r.Value.Single(v => v.Name.Name == "1003")).Single();

                file.RCData = new RCData(rcData.WriteAndGetBytes());

                //Load LNZ files
                var lnzId = info.ResourceTypes.Single(rt => rt.Name == "LNZ");
                foreach (var res in info.Resources[lnzId])
                {
                    var lnz = res.WriteAndGetBytes();
                    file.LNZFiles[res.Name.Name] = new LNZFile(lnz);
                }

                //Load string tables
                var stringTables = info.Resources.Where(r => r.Key.TypeName == "RT_STRING");

                foreach (var stringTable in stringTables)
                {
                    foreach (StringResource block in stringTable.Value)
                    {
                        var blockDict = new Dictionary<ushort, string>();
                        foreach (var key in block.Strings.Keys)
                        {
                            blockDict[key] = block.Strings[key];
                        }
                        file.StringTables[block.BlockId] = blockDict;
                    }
                }

                file.BreedName = file.StringTables[63][1001];
                file.DefaultPetName = file.StringTables[63][1000];

                //Load bitmaps
                var bitmapId = info.ResourceTypes.Single(rt => rt.Name == "BMP");
                foreach (GenericResource bmp in info.Resources[bitmapId])
                {
                    file.Bitmaps[bmp.Name.Name] = new Bitmap(new MemoryStream(bmp.Data));
                }

                var scpId = info.ResourceTypes.Single(rt => rt.Name == "SCP");
                
                //Load SCP file (parsing not implemented yet)
                file.SCP = new SCPFile(info.Resources[scpId].First().WriteAndGetBytes());

            }
            return file;
        }
    }
}
