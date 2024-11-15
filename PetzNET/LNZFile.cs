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
                    if (line.StartsWith('[') &&  line.EndsWith("]"))
                    {
                        currSectionName = line.Substring(1, line.Length - 2);
                    }
                    currSection += $"{line}\n";
                }
            }

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
                    case "Head Tilt Limis":
                        HeadTiltLimits = new LNZSection<RotationLimit> (key, Sections[key]);
                        break;
                    case "Head Shot":
                        HeadShot = new LNZSection<HeadShotAttribute> (key, Sections[key]);
                        break;
                    case "Key Balls":
                        KeyBalls = new LNZSection<LabeledBall> (key, Sections[key]);
                        break;
                    case "Num Ballz":
                        NumBallz = new LNZSection<LNZDataInt> (key, Sections[key]);
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
                        RightEarBalls = new LNZSection<LNZDataInt> (key, Sections[key]);
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
                }
            }
        }

        public byte[] RawData { get; set; }
        public Dictionary<string, string> Sections { get; private set; } = new Dictionary<string, string>();
        public LNZSection<FurPatternGroup>? FurPatternBalls { get; set; }
        public LNZSection<FurColorArea>? FurColorAreas { get; set; }
        public LNZSection<FurMarking>? FurMarkings { get; set; }
        public LNZSection<ClothingAdjustment>? AdjustClothing { get; set; }
        public LNZSection<ClothingItem>? FlatClothing { get; set; }
        public LNZSection<ClothingItem>? AddClothing { get; set; }
        public LNZSection<LNZDataBool>? ForceToFemale { get; set; }
        public LNZSection<LNZDataBool>? ForceToMale { get; set; }
        public LNZSection<BallColorOverride>? ColorInfoOverride { get; set; }
        public LNZSection<BallAttributeOverride>? OutlineColorOverride { get; set; }
        public LNZSection<BallAttributeOverride>? FuzzOverride { get; set; }
        public LNZSection<BallAttributeOverride>? BallSizeOverride { get; set; }
        public LNZSection<BallSizeLimit>? ThinFat { get; set; }
        public LNZSection<TextureItem>? TextureList { get; set; }
        public LNZSection<AddBall>? AddBalls { get; set; }
        public LNZSection<LNZDataInt>? DefaultLinezThickness { get; set; }
        public LNZSection<Linez>? LinezData { get; set; }
        public LNZSection<PaintBall>? PaintBallz {  get; set; }
        public LNZSection<BallInfo>? BallzInfo { get; set; }
        public LNZSection<LNZDataString>? Sounds { get; set; }
        public LNZSection<LNZDataString>? LittleOne { get; set; }
        public LNZSection<LNZDataString>? DefaultLinezFile { get; set; }
        public LNZSection<EyelidColor>? EyelidColor { get; set; }
        public LNZSection<EyeDefinition>? Eyes { get; set; }
        public LNZSection<BallProjection>? ProjectBall { get; set; }
        public LNZSection<BallPosition>? Move { get; set; }
        public LNZSection<LabeledBall>? Omissions { get; set; }
        public LNZSection<Whisker>? Whiskers {  get; set; }
        public LNZSection<BallPosition>? AddBallOverride { get; set; }
        public LNZSection<LNZDataInt>? DrawLinezBeforeBallz {  get; set; }
        public LNZSection<LNZDataInt>? CircleRenderMode { get; set; }
        public LNZSection<LNZDataInt>? LineRenderMode { get; set; }
        public LNZSection<LNZDataInt>? DefaultGlueBall { get; set; }
        public LNZSection<LNZDataInt>? ZShadeSlope { get; set; }
        public LNZSection<LNZDataInt>? DrawSmallBalls { get; set; }
        public LNZSection<LNZDataInt>? HeadEnlargement { get; set; }
        public LNZSection<LNZDataInt>? FaceExtension { get; set; }
        public LNZSection<LNZDataInt>? BodyExtension { get; set; }
        public LNZSection<LNZDataInt>? LegExtension { get; set; }
        public LNZSection<LNZDataInt>? FeetEnlargement { get; set; }
        public LNZSection<LNZDataInt>? EarExtension { get; set; }
        public LNZSection<BallScale>? DefaultScales { get; set; }
        public LNZSection<RotationLimit>? HeadRotationLimits { get; set; }
        public LNZSection<RotationLimit>? HeadTiltLimits { get; set; }
        public LNZSection<HeadShotAttribute>? HeadShot { get; set; }
        public LNZSection<LabeledBall>? KeyBalls { get; set; }
        public LNZSection<LNZDataInt>? NumBallz { get; set; }
        public LNZSection<LNZDataInt>? HeadBalls { get; set; }
        public LNZSection<LNZDataInt>? ExtraHeadBalls { get; set; }
        public LNZSection<LNZDataInt>? LeftBrowBalls { get; set; }
        public LNZSection<LNZDataInt>? RightBrowBalls { get; set; }
        public LNZSection<LNZDataInt>? JowlzBalls { get; set; }
        public LNZSection<LNZDataInt>? WhiskerBalls { get; set; }
        public LNZSection<LNZDataInt>? TailBalls { get; set; }
        public LNZSection<LNZDataInt>? LeftEarBalls { get; set; }
        public LNZSection<LNZDataInt>? RightEarBalls { get; set; }
        public LNZSection<LNZDataInt>? LeftArmBalls { get; set; }
        public LNZSection<LNZDataInt>? RightArmBalls { get; set; }
        public LNZSection<LNZDataInt>? LeftFootBalls { get; set; }
        public LNZSection<LNZDataInt>? RightFootBalls { get; set; }
        public LNZSection<LNZDataInt>? LeftHandBalls { get; set; }
        public LNZSection<LNZDataInt>? RightHandBalls { get; set; }
        public LNZSection<LNZDataInt>? LeftLegBalls { get; set; }
        public LNZSection<LNZDataInt>? RightLegBalls { get; set; }
        public LNZSection<LNZDataInt>? BodyBalls { get; set; }
        public LNZSection<LNZDataInt>? ExtraBalls { get; set; }
        public LNZSection<LNZDataInt>? LnzVersion { get; set; }
        public LNZSection<LNZDataString>? AdditionalFrames { get; set; }
        public LNZSection<LNZDataString>? BreedName { get; set; }
        public LNZSection<LNZDataInt>? NoTextureRotate { get; set; }

    }
}
