using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ChampionMod.Tiles.Blocks
{
    class AppleTreePotTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileSolid[Type] = true;
            TileObjectData.newTile.Width = 3;
            TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.Origin = new Point16(1, 0);
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, 1, 1);
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.CoordinateHeights = new[] { 16 };
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.DrawFlipHorizontal = true;
            TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
            TileObjectData.newTile.LavaDeath = true;
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(200, 200, 200));
            SetModTree(new FruitTrees.AppleTree());
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override int SaplingGrowthType(ref int style)
        {
            style = 0;
            return mod.TileType("AppleSaplingTile");
        }

        public override bool CanKillTile(int i, int j, ref bool blockDamaged)
        {
            int topLeftX = i - Main.tile[i, j].frameX / 18;

            for (int o = 0; o < 3; o++)
            {
                if (Main.tile[topLeftX + o, j - 1].type == 5)
                {
                    return false;
                }
            }
            return true;
        }

        public override bool CreateDust(int i, int j, ref int type)
        {
            int topLeftX = i - Main.tile[i, j].frameX / 18;

            for (int o = 0; o < 3; o++)
            {
                if (Main.tile[topLeftX + o, j - 1].type == 5)
                {
                    return false;
                }
            }
            return true;
        }

        public override bool KillSound(int i, int j)
        {
            int topLeftX = i - Main.tile[i, j].frameX / 18;

            for (int o = 0; o < 3; o++)
            {
                if (Main.tile[topLeftX + o, j - 1].type == 5)
                {
                    return false;
                }
            }
            return true;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 0, 0, mod.ItemType("AppleTreePot"));
        }
    }
}