using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using Terraria.ID;

namespace ChampionMod.Tiles.FruitTrees
{
    public class AppleTree : ModTree
    {
        private Mod Mod => ModLoader.GetMod("ChampionMod");

        public override int CreateDust()
        {
            return DustID.Grass;
        }

        public override int GrowthFXGore()
        {
            return GoreID.TreeLeaf_Normal;
        }

        public override int DropWood()
        {
            return Mod.ItemType("Apple");
        }

        public override Texture2D GetTexture()
        {
            return Mod.GetTexture("Tiles/FruitTrees/AppleTree");
        }

        public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset)
        {
            return Mod.GetTexture("Tiles/FruitTrees/AppleTree_Tops");
        }

        public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame)
        {
            return Mod.GetTexture("Tiles/FruitTrees/AppleTree_Branches");
        }
    }
}