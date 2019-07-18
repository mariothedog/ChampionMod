﻿using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ChampionMod.Tiles.Crops
{
    public class CornCrop : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileCut[Type] = true;
            //Main.tileAlch[Type] = true;
            Main.tileNoFail[Type] = true;
            //Main.tileLavaDeath[Type] = true;
            //dustType = -1;
            //disableSmartCursor = true;
            //AddMapEntry(new Color(13, 88, 130), "Banner");
            //TileObjectData.newTile.Width = 1;
            //TileObjectData.newTile.Height = 1;
            //TileObjectData.newTile.Origin = Point16.Zero;
            //TileObjectData.newTile.UsesCustomCanPlace = true;
            //TileObjectData.newTile.CoordinateHeights = new int[]
            //{
            //	20
            //};
            //TileObjectData.newTile.CoordinateWidth = 16;
            //TileObjectData.newTile.CoordinatePadding = 2;
            //TileObjectData.newTile.DrawYOffset = -1;
            //TileObjectData.newTile.StyleHorizontal = true;
            //TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.AlternateTile, TileObjectData.newTile.Width, 0);
            //TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
            //TileObjectData.newTile.LavaDeath = true;
            //TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
            //TileObjectData.addBaseTile(out TileObjectData.StyleAlch);
            TileObjectData.newTile.CopyFrom(TileObjectData.StyleAlch);

            TileObjectData.newTile.Width = 2;
            //TileObjectData.newTile.Height = 3;
            //TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };

            TileObjectData.newTile.AnchorValidTiles = new[]
            {
                2, //TileID.Grass
				109, // TileId.HallowedGrass
				//mod.TileType<ExampleBlock>()
            };
            TileObjectData.newTile.AnchorAlternateTiles = new[]
            {
                78, //ClayPot
				TileID.PlanterBox
            };
            TileObjectData.addTile(Type);
            //drop = mod.ItemType()
        }
        //public override bool CanPlace(int i, int j)
        //{
        //	return base.CanPlace(i, j);
        //}
        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if (Main.rand.Next(20) == 0) RandomUpdate(i, j);
            /*if (i % 2 == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }*/
        }

        public override bool Drop(int i, int j)
        {
            //int stage = Main.tile[i, j].frameX / 18;
            int stage = Main.tile[i, j].frameX / 36;
            if (stage == 2)
            {
                Item.NewItem(i * 16, j * 16, 0, 0, mod.ItemType<Items.Seeds.CornSeeds>());
            }
            return false;
        }

        /*public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType("ExampleMusicBox"));
        }*/

        public override void RandomUpdate(int i, int j)
        {
            // Works for 1x3 plant
            //Tile tile = Main.tile[i, j];
            //int topY = j - tile.frameY / 18 % 3;
            /*if (Main.tile[i, topY].frameX < 36)
            {
                Main.tile[i, topY].frameX += 18;
            }*/

            /*if (Main.tile[i, topY + 1].frameX < 36)
            {
                Main.tile[i, topY + 1].frameX += 18;
            }

            if (Main.tile[i, topY + 2].frameX < 36)
            {
                Main.tile[i, topY + 2].frameX += 18;
            }*/

            // For 2x1 plant [wip]
            /*if (Main.tile[i, j].frameX < 72)
            {
                Main.tile[i, j].frameX += 36;
            }

            if (Main.tile[i + 1, j].frameX == 0)
            {
                Main.tile[i + 1, j].frameX = 18;
            }

            if (Main.tile[i + 1, j].frameX < 72)
            {
                Main.tile[i + 1, j].frameX += 36;
            }*/

            int x = i - Main.tile[i, j].frameX / 18 % 2;
            int y = j - Main.tile[i, j].frameY / 18 % 1;

            /*for (int l = x; l < x + 2; l++)
            {
                for (int m = y; m < y + 1; m++)
                {
                    if (Main.tile[l, m].active() && Main.tile[l, m].type == Type)
                    {
                        if (Main.tile[l, m].frameY < 18)
                        {
                            Main.tile[l, m].frameY += 18;
                        }
                        else
                        {
                            Main.tile[l, m].frameY -= 18;
                        }
                    }
                }
            }*/

            //Main.tile[i, ].frameX
            //short frameAdjustment = (short)(tile.frameX > 0 ? -18 : 18);
            //Main.tile[i, topY].frameX += frameAdjustment;
            //Main.tile[i, topY + 1].frameX += frameAdjustment;
            //Main.tile[i, topY + 2].frameX += frameAdjustment;
        }
        //public override void RightClick(int i, int j)
        //{
        //	base.RightClick(i, j);
        //}
    }
}