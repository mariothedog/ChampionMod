using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ChampionMod.Tiles.Crops
{
    class CornCrop : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileCut[Type] = true;
            Main.tileNoFail[Type] = true;
            Main.tileLavaDeath[Type] = true;
            //disableSmartCursor = true;

            //TileObjectData.newTile.CoordinateWidth = 16;
            //TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newTile.Width = 3;
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
            TileObjectData.newTile.StyleHorizontal = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.StyleAlch);
            TileObjectData.newTile.AnchorValidTiles = new[]
            {
                2 // Grass
            };
            TileObjectData.newTile.AnchorAlternateTiles = new[]
            {
                78, // ClayPot
				TileID.PlanterBox
            };
            TileObjectData.addTile(Type);
        }

        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            //if (Main.rand.Next(20) == 0) RandomUpdate(i, j);
            RandomUpdate(i, j);
            //Main.NewText("SetSpriteEffects method test");
			if (i % 2 == 1)
            {
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
		}

		public override bool Drop(int i, int j)
        {
            //Main.NewText("Drop method test");
            int stage = Main.tile[i, j].frameX / 18;
            Main.NewText("stage: " + stage);

            if (stage == 4)
            {
				Item.NewItem(i * 16, j * 16, 0, 0, mod.ItemType<Items.Seeds.CornSeeds>());
			}

			return false;
		}

		public override void RandomUpdate(int i, int j)
        {
            // Handles the growth stages

            Main.NewText(Main.tile[i, j].frameX);

            //Main.NewText("RandomUpdate method test");
            if (Main.tile[i, j].frameX % 18 == 0 && Main.tile[i, j].frameX < 72) // "< 72" so it doesn't get past the fifth growth stage
            {
				Main.tile[i, j].frameX += 18;
			}
        }
    }
}