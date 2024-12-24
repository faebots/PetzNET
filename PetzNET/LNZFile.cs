using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetzNET.LNZ;

namespace PetzNET
{
    public class LNZFile
    {
        public LNZFile(byte[] data)
        {
            RawData = data;
            var text = Encoding.ASCII.GetString(RawData);

            string currSectionName = "";
            string currSection = "";
            var lines = text.Split('\n');

            //split the file into sections
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i].Trim();
                if (string.IsNullOrEmpty(line))
                {
                    if (!string.IsNullOrEmpty(currSectionName))
                    {
                        Sections[currSectionName] = currSection;
                        currSectionName = "";
                    }
                    currSection = "";
                }
                else
                {
                    var trimmed = line.Split(';', StringSplitOptions.TrimEntries)[0];
                    if (trimmed.StartsWith('[') && trimmed.EndsWith("]"))
                    {
                        currSectionName = trimmed.Substring(1, trimmed.Length - 2);
                    }
                    currSection += $"{line}\n";
                }
            }

            //parse each section
            foreach (var key in Sections.Keys)
            {
                switch (key)
                {
                    case "Fur Pattern Balls":
                        FurPatternBalls = new LNZSection<FurPatternGroup>(key, Sections[key]);
                        break;
                    case "Fur Color Areas":
                        FurColorAreas = new LNZSection<FurColorArea>(key, Sections[key]);
                        break;
                    case "Fur Markings":
                        FurMarkings = new LNZSection<FurMarking>(key, Sections[key]);
                        break;
                    case "Adjust Clothing":
                        AdjustClothing = new LNZSection<ClothingAdjustment>(key, Sections[key]);
                        break;
                    case "Flat Clothing":
                        FlatClothing = new LNZSection<ClothingItem>(key, Sections[key]);
                        break;
                    case "Add Clothing":
                        AddClothing = new LNZSection<ClothingItem>(key, Sections[key]);
                        break;
                    case "Force To Female":
                        ForceToFemale = new LNZSection<LNZDataBool>(key, Sections[key]);
                        break;
                    case "Force To Male":
                        ForceToMale = new LNZSection<LNZDataBool>(key, Sections[key]);
                        break;
                    case "Color Info Override":
                        ColorInfoOverride = new LNZSection<BallColorOverride>(key, Sections[key]);
                        break;
                    case "Outline Color Override":
                        OutlineColorOverride = new LNZSection<BallAttributeOverride>(key, Sections[key]);
                        break;
                    case "Fuzz Override":
                        FuzzOverride = new LNZSection<BallAttributeOverride>(key, Sections[key]);
                        break;
                    case "Ball Size Override":
                        BallSizeOverride = new LNZSection<BallAttributeOverride>(key, Sections[key]);
                        break;
                    case "Thin/Fat":
                        ThinFat = new LNZSection<BallSizeLimit>(key, Sections[key]);
                        break;
                    case "Texture List":
                        TextureList = new LNZSection<TextureItem>(key, Sections[key]);
                        break;
                    case "Add Ball":
                        AddBalls = new LNZSection<AddBall>(key, Sections[key]);
                        break;
                    case "Default Linez Thickness":
                        DefaultLinezThickness = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Linez":
                        LinezData = new LNZSection<Linez>(key, Sections[key]);
                        break;
                    case "Paint Ballz":
                        PaintBallz = new LNZSection<PaintBall>(key, Sections[key]);
                        break;
                    case "Ballz Info":
                        BallzInfo = new LNZSection<BallInfo>(key, Sections[key]);
                        break;
                    case "256 Eyelid Color":
                        EyelidColor = new LNZSection<EyelidColor>(key, Sections[key]);
                        break;
                    case "Eyes":
                        Eyes = new LNZSection<EyeDefinition>(key, Sections[key]);
                        break;
                    case "Project Ball":
                        ProjectBall = new LNZSection<BallProjection>(key, Sections[key]);
                        break;
                    case "Move":
                        Move = new LNZSection<BallPosition>(key, Sections[key]);
                        break;
                    case "Omissions":
                        Omissions = new LNZSection<LabeledBall>(key, Sections[key]);
                        break;
                    case "Whiskers":
                        Whiskers = new LNZSection<Whisker>(key, Sections[key]);
                        break;
                    case "Add Ball Override":
                        AddBallOverride = new LNZSection<BallPosition>(key, Sections[key]);
                        break;
                    case "Draw Linez Before Ballz":
                        DrawLinezBeforeBallz = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Circle Render Mode":
                        CircleRenderMode = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Line Render Mode":
                        LineRenderMode = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Default Glue Ball":
                        DefaultGlueBall = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Z Shade Slope":
                        ZShadeSlope = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Draw Small Balls":
                        DrawSmallBalls = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Head Enlargement":
                        HeadEnlargement = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Face Extension":
                        FaceExtension = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Body Extension":
                        BodyExtension = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Leg Extension":
                        LegExtension = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Feet Enlargement":
                        FeetEnlargement = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Ear Extension":
                        EarExtension = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Default Scales":
                        DefaultScales = new LNZSection<BallScale>(key, Sections[key]);
                        break;
                    case "Head Rotation Limits":
                        HeadRotationLimits = new LNZSection<RotationLimit>(key, Sections[key]);
                        break;
                    case "Head Tilt Limits":
                        HeadTiltLimits = new LNZSection<RotationLimit>(key, Sections[key]);
                        break;
                    case "Head Shot":
                        HeadShot = new LNZSection<HeadShotAttribute>(key, Sections[key]);
                        break;
                    case "Key Balls":
                        KeyBalls = new LNZSection<LabeledBall>(key, Sections[key]);
                        break;
                    case "Num Ballz":
                        NumBallz = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Head Balls":
                        HeadBalls = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Extra Head Balls":
                        ExtraHeadBalls = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Left Brow Balls":
                        LeftBrowBalls = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Right Brow Balls":
                        RightBrowBalls = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Jowlz Balls":
                        JowlzBalls = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Whisker Balls":
                        WhiskerBalls = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Tail Balls":
                        TailBalls = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Left Ear Balls":
                        LeftEarBalls = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Right Ear Balls":
                        RightEarBalls = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Left Arm Balls":
                        LeftArmBalls = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Right Arm Balls":
                        RightArmBalls = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Left Foot Balls":
                        LeftFootBalls = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Right Foot Balls":
                        RightFootBalls = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Left Hand Balls":
                        LeftHandBalls = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Right Hand Balls":
                        RightHandBalls = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Left Leg Balls":
                        LeftLegBalls = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Right Leg Balls":
                        RightLegBalls = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Body Balls":
                        BodyBalls = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Extra Balls":
                        ExtraBalls = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Lnz Version":
                        LnzVersion = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Additional Frames":
                        AdditionalFrames = new LNZSection<LNZDataString>(key, Sections[key]);
                        break;
                    case "Breed Name":
                        BreedName = new LNZSection<LNZDataString>(key, Sections[key]);
                        break;
                    case "No Texture Rotate":
                        NoTextureRotate = new LNZSection<LNZDataInt>(key, Sections[key]);
                        break;
                    case "Default Linez File":
                        DefaultLinezFile = new LNZSection<LNZDataString>(key, Sections[key]);
                        break;
                    case "Sounds":
                        Sounds = new LNZSection<LNZDataString>(key, Sections[key]);
                        break;
                    case "Little one":
                        LittleOne = new LNZSection<LNZDataString>(key, Sections[key]);
                        break;
                }
            }
        }

        public byte[] RawData { get; set; }
        public Dictionary<string, string> Sections { get; private set; } = new Dictionary<string, string>();

        private Dictionary<string, object> sections = new Dictionary<string, object>();


        public LNZSection<FurPatternGroup>? FurPatternBalls
        {
            get => (LNZSection<FurPatternGroup>?)sections["Fur Pattern Balls"];
            set => sections["Fur Pattern Balls"] = value;
        }

        public LNZSection<FurColorArea>? FurColorAreas
        {
            get => (LNZSection<FurColorArea>?)sections["Fur Color Areas"];
            set => sections["Fur Color Areas"] = value;
        }

        public LNZSection<FurMarking>? FurMarkings
        {
            get => (LNZSection<FurMarking>?)sections["Fur Markings"];
            set => sections["Fur Markings"] = value;
        }

        public LNZSection<ClothingAdjustment>? AdjustClothing
        {
            get => (LNZSection<ClothingAdjustment>?)sections["Adjust Clothing"];
            set => sections["Adjust Clothing"] = value;
        }

        public LNZSection<ClothingItem>? FlatClothing
        {
            get => (LNZSection<ClothingItem>?)sections["Flat Clothing"];
            set => sections["Flat Clothing"] = value;
        }

        public LNZSection<ClothingItem>? AddClothing
        {
            get => (LNZSection<ClothingItem>?)sections["Add Clothing"];
            set => sections["Add Clothing"] = value;
        }

        public LNZSection<LNZDataBool>? ForceToFemale
        {
            get => (LNZSection<LNZDataBool>?)sections["Force To Female"];
            set => sections["Force To Female"] = value;
        }

        public LNZSection<LNZDataBool>? ForceToMale
        {
            get => (LNZSection<LNZDataBool>?)sections["Force To Male"];
            set => sections["Force To Male"] = value;
        }

        public LNZSection<BallColorOverride>? ColorInfoOverride
        {
            get => (LNZSection<BallColorOverride>?)sections["Color Info Override"];
            set => sections["Color Info Override"] = value;
        }

        public LNZSection<BallAttributeOverride>? OutlineColorOverride
        {
            get => (LNZSection<BallAttributeOverride>?)sections["Outline Color Override"];
            set => sections["Outline Color Override"] = value;
        }

        public LNZSection<BallAttributeOverride>? FuzzOverride
        {
            get => (LNZSection<BallAttributeOverride>?)sections["Fuzz Override"];
            set => sections["Fuzz Override"] = value;
        }

        public LNZSection<BallAttributeOverride>? BallSizeOverride
        {
            get => (LNZSection<BallAttributeOverride>?)sections["Ball Size Override"];
            set => sections["Ball Size Override"] = value;
        }

        public LNZSection<BallSizeLimit>? ThinFat
        {
            get => (LNZSection<BallSizeLimit>?)sections["Thin/Fat"];
            set => sections["Thin/Fat"] = value;
        }

        public LNZSection<TextureItem>? TextureList
        {
            get => (LNZSection<TextureItem>?)sections["Texture List"];
            set => sections["Texture List"] = value;
        }

        public LNZSection<AddBall>? AddBalls
        {
            get => (LNZSection<AddBall>?)sections["Add Ball"];
            set => sections["Add Ball"] = value;
        }

        public LNZSection<LNZDataInt>? DefaultLinezThickness
        {
            get => (LNZSection<LNZDataInt>?)sections["Default Linez Thickness"];
            set => sections["Default Linez Thickness"] = value;
        }

        public LNZSection<Linez>? LinezData
        {
            get => (LNZSection<Linez>?)sections["Linez"];
            set => sections["Linez"] = value;
        }

        public LNZSection<PaintBall>? PaintBallz
        {
            get => (LNZSection<PaintBall>?)sections["Paint Ballz"];
            set => sections["Paint Ballz"] = value;
        }

        public LNZSection<BallInfo>? BallzInfo
        {
            get => (LNZSection<BallInfo>?)sections["Ballz Info"];
            set => sections["Ballz Info"] = value;
        }

        public LNZSection<LNZDataString>? Sounds
        {
            get => (LNZSection<LNZDataString>?)sections["Sounds"];
            set => sections["Sounds"] = value;
        }

        public LNZSection<LNZDataString>? LittleOne
        {
            get => (LNZSection<LNZDataString>?)sections["Little one"];
            set => sections["Little one"] = value;
        }

        public LNZSection<LNZDataString>? DefaultLinezFile
        {
            get => (LNZSection<LNZDataString>?)sections["Default Linez File"];
            set => sections["Default Linez File"] = value;
        }

        public LNZSection<EyelidColor>? EyelidColor
        {
            get => (LNZSection<EyelidColor>?)sections["256 Eyelid Color"];
            set => sections["256 Eyelid Color"] = value;
        }

        public LNZSection<EyeDefinition>? Eyes
        {
            get => (LNZSection<EyeDefinition>?)sections["Eyes"];
            set => sections["Eyes"] = value;
        }

        public LNZSection<BallProjection>? ProjectBall
        {
            get => (LNZSection<BallProjection>?)sections["Project Ball"];
            set => sections["Project Ball"] = value;
        }

        public LNZSection<BallPosition>? Move
        {
            get => (LNZSection<BallPosition>?)sections["Move"];
            set => sections["Move"] = value;
        }

        public LNZSection<LabeledBall>? Omissions
        {
            get => (LNZSection<LabeledBall>?)sections["Omissions"];
            set => sections["Omissions"] = value;
        }

        public LNZSection<Whisker>? Whiskers
        {
            get => (LNZSection<Whisker>?)sections["Whiskers"];
            set => sections["Whiskers"] = value;
        }

        public LNZSection<BallPosition>? AddBallOverride
        {
            get => (LNZSection<BallPosition>?)sections["Add Ball Override"];
            set => sections["Add Ball Override"] = value;
        }

        public LNZSection<LNZDataInt>? DrawLinezBeforeBallz
        {
            get => (LNZSection<LNZDataInt>?)sections["Draw Linez Before Ballz"];
            set => sections["Draw Linez Before Ballz"] = value;
        }

        public LNZSection<LNZDataInt>? CircleRenderMode
        {
            get => (LNZSection<LNZDataInt>?)sections["Circle Render Mode"];
            set => sections["Circle Render Mode"] = value;
        }

        public LNZSection<LNZDataInt>? LineRenderMode { 
            get => (LNZSection<LNZDataInt>?)sections["Line Render Mode"]; 
            set => sections["Line Render Mode"] = value;
        }

        public LNZSection<LNZDataInt>? DefaultGlueBall { 
            get => (LNZSection<LNZDataInt>?)sections["Default Glue Ball"]; 
            set => sections["Default Glue Ball"] = value;
        }

        public LNZSection<LNZDataInt>? ZShadeSlope { 
            get => (LNZSection<LNZDataInt>?)sections["Z Shade Slope"]; 
            set => sections["Z Shade Slope"] = value;
        }

        public LNZSection<LNZDataInt>? DrawSmallBalls { 
            get => (LNZSection<LNZDataInt>?)sections["Draw Small Balls"]; 
            set => sections["Draw Small Balls"] = value;
        }

        public LNZSection<LNZDataInt>? HeadEnlargement { 
            get => (LNZSection<LNZDataInt>?)sections["Head Enlargement"]; 
            set => sections["Head Enlargement"] = value;
        }

        public LNZSection<LNZDataInt>? FaceExtension { 
            get => (LNZSection<LNZDataInt>?)sections["Face Extension"]; 
            set => sections["Face Extension"] = value;
        }

        public LNZSection<LNZDataInt>? BodyExtension { 
            get => (LNZSection<LNZDataInt>?)sections["Body Extension"]; 
            set => sections["Body Extension"] = value;
        }

        public LNZSection<LNZDataInt>? LegExtension { 
            get => (LNZSection<LNZDataInt>?)sections["Leg Extension"]; 
            set => sections["Leg Extension"] = value;
        }

        public LNZSection<LNZDataInt>? FeetEnlargement { 
            get => (LNZSection<LNZDataInt>?)sections["Feet Enlargement"]; 
            set => sections["Feet Enlargement"] = value;
        }

        public LNZSection<LNZDataInt>? EarExtension { 
            get => (LNZSection<LNZDataInt>?)sections["Ear Extension"]; 
            set => sections["Ear Extension"] = value;
        }

        public LNZSection<BallScale>? DefaultScales { 
            get => (LNZSection<BallScale>?)sections["Default Scales"]; 
            set => sections["Default Scales"] = value;
        }

        public LNZSection<RotationLimit>? HeadRotationLimits { 
            get => (LNZSection<RotationLimit>?)sections["Head Rotation Limits"]; 
            set => sections["Head Rotation Limits"] = value;
        }

        public LNZSection<RotationLimit>? HeadTiltLimits { 
            get => (LNZSection<RotationLimit>?)sections["Head Tilt Limits"]; 
            set => sections["Head Tilt Limits"] = value;
        }

        public LNZSection<HeadShotAttribute>? HeadShot { 
            get => (LNZSection<HeadShotAttribute>?)sections["Head Shot"]; 
            set => sections["Head Shot"] = value;
        }

        public LNZSection<LabeledBall>? KeyBalls { 
            get => (LNZSection<LabeledBall>?)sections["Key Balls"]; 
            set => sections["Key Balls"] = value;
        }

        public LNZSection<LNZDataInt>? NumBallz { 
            get => (LNZSection<LNZDataInt>?)sections["Num Ballz"]; 
            set => sections["Num Ballz"] = value;
        }

        public LNZSection<LNZDataInt>? HeadBalls { 
            get => (LNZSection<LNZDataInt>?)sections["Head Balls"]; 
            set => sections["Head Balls"] = value;
        }

        public LNZSection<LNZDataInt>? ExtraHeadBalls { 
            get => (LNZSection<LNZDataInt>?)sections["Extra Head Balls"]; 
            set => sections["Extra Head Balls"] = value;
        }

        public LNZSection<LNZDataInt>? LeftBrowBalls { 
            get => (LNZSection<LNZDataInt>?)sections["Left Brow Balls"]; 
            set => sections["Left Brow Balls"] = value;
        }

        public LNZSection<LNZDataInt>? RightBrowBalls { 
            get => (LNZSection<LNZDataInt>?)sections["Right Brow Balls"]; 
            set => sections["Right Brow Balls"] = value;
        }

        public LNZSection<LNZDataInt>? JowlzBalls { 
            get => (LNZSection<LNZDataInt>?)sections["Jowlz Balls"]; 
            set => sections["Jowlz Balls"] = value;
        }

        public LNZSection<LNZDataInt>? WhiskerBalls { 
            get => (LNZSection<LNZDataInt>?)sections["Whisker Balls"]; 
            set => sections["Whisker Balls"] = value;
        }

        public LNZSection<LNZDataInt>? TailBalls { 
            get => (LNZSection<LNZDataInt>?)sections["Tail Balls"]; 
            set => sections["Tail Balls"] = value;
        }

        public LNZSection<LNZDataInt>? LeftEarBalls { 
            get => (LNZSection<LNZDataInt>?)sections["Left Ear Balls"]; 
            set => sections["Left Ear Balls"] = value;
        }

        public LNZSection<LNZDataInt>? RightEarBalls { 
            get => (LNZSection<LNZDataInt>?)sections["Right Ear Balls"]; 
            set => sections["Right Ear Balls"] = value;
        }

        public LNZSection<LNZDataInt>? LeftArmBalls { 
            get => (LNZSection<LNZDataInt>?)sections["Left Arm Balls"]; 
            set => sections["Left Arm Balls"] = value;
        }

        public LNZSection<LNZDataInt>? RightArmBalls { 
            get => (LNZSection<LNZDataInt>?)sections["Right Arm Balls"]; 
            set => sections["Right Arm Balls"] = value;
        }

        public LNZSection<LNZDataInt>? LeftFootBalls { 
            get => (LNZSection<LNZDataInt>?)sections["Left Foot Balls"]; 
            set => sections["Left Foot Balls"] = value;
        }

        public LNZSection<LNZDataInt>? RightFootBalls { 
            get => (LNZSection<LNZDataInt>?)sections["Right Foot Balls"]; 
            set => sections["Right Foot Balls"] = value;
        }

        public LNZSection<LNZDataInt>? LeftHandBalls { 
            get => (LNZSection<LNZDataInt>?)sections["Left Hand Balls"]; 
            set => sections["Left Hand Balls"] = value;
        }

        public LNZSection<LNZDataInt>? RightHandBalls { 
            get => (LNZSection<LNZDataInt>?)sections["Right Hand Balls"]; 
            set => sections["Right Hand Balls"] = value;
        }

        public LNZSection<LNZDataInt>? LeftLegBalls { 
            get => (LNZSection<LNZDataInt>?)sections["Left Leg Balls"]; 
            set => sections["Left Leg Balls"] = value;
        }

        public LNZSection<LNZDataInt>? RightLegBalls { 
            get => (LNZSection<LNZDataInt>?)sections["Right Leg Balls"]; 
            set => sections["Right Leg Balls"] = value;
        }

        public LNZSection<LNZDataInt>? BodyBalls { 
            get => (LNZSection<LNZDataInt>?)sections["Body Balls"]; 
            set => sections["Body Balls"] = value;
        }

        public LNZSection<LNZDataInt>? ExtraBalls { 
            get => (LNZSection<LNZDataInt>?)sections["Extra Balls"]; 
            set => sections["Extra Balls"] = value;
        }

        public LNZSection<LNZDataInt>? LnzVersion { 
            get => (LNZSection<LNZDataInt>?)sections["Lnz Version"]; 
            set => sections["Lnz Version"] = value;
        }

        public LNZSection<LNZDataString>? AdditionalFrames { 
            get => (LNZSection<LNZDataString>?)sections["Additional Frames"]; 
            set => sections["Additional Frames"] = value;
        }

        public LNZSection<LNZDataString>? BreedName { 
            get => (LNZSection<LNZDataString>?)sections["Breed Name"]; 
            set => sections["Breed Name"] = value;
        }

        public LNZSection<LNZDataInt>? NoTextureRotate
        {            
            get => (LNZSection<LNZDataInt>?)sections["No Texture Rotate"]; 
            set => sections["No Texture Rotate"] = value;
        }

        /// <summary>
        /// Export to string that can be written into a file.
        /// </summary>
        /// <returns></returns>
        public string Export()
        {
            var sb = new StringBuilder();
            foreach (var key in sections.Keys)
            {
                sb.AppendLine(sections[key].ToString());
            }
            return sb.ToString();
        }
    }
}
