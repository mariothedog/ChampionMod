using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ChampionMod.Tiles.Saplings
{
    public class AppleSaplingTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newTile.AnchorValidTiles = new[] { 2, 109 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.DrawFlipHorizontal = true;
            TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
            TileObjectData.newTile.LavaDeath = true;
            TileObjectData.newTile.RandomStyleRange = 3;
            TileObjectData.addTile(Type);
            //sapling = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("AppleSapling");
            AddMapEntry(new Color(200, 200, 200), name);
            dustType = DustID.Grass;
            adjTiles = new int[] { TileID.Saplings };
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void RandomUpdate(int i, int j)
        {
            //if (WorldGen.genRand.Next(20) == 0)
            //{
            //Main.NewText("failed update");
            bool isPlayerNear = WorldGen.PlayerLOS(i, j);
            bool success = WorldGen.GrowTree(i, j);
            Main.NewText(isPlayerNear);
            Main.NewText(success);
            Main.NewText("");
            if (success && isPlayerNear)
            {
                WorldGen.TreeGrowFXCheck(i, j);
                Main.NewText("Successfull update");
            }
            //}
        }

        public override void SetSpriteEffects(int i, int j, ref SpriteEffects effects)
        {
            RandomUpdate(i, j);
            if (i % 2 == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
        }
    }
}