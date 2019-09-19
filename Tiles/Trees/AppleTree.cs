using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using Terraria.ID;

namespace ChampionMod.Tiles.Trees
{
    public class AppleTree : ModTree
    {
        private Mod mod => ModLoader.GetMod("ChampionMod");

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
            return mod.ItemType("Bayonet");
        }

        public override Texture2D GetTexture()
        {
            return mod.GetTexture("Trees/ExampleTree");
        }

        public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset)
        {
            return mod.GetTexture("Trees/ExampleTree_Tops");
        }

        public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame)
        {
            return mod.GetTexture("Trees/ExampleTree_Branches");
        }
    }
}