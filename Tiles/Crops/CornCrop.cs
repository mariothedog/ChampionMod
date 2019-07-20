using Microsoft.Xna.Framework.Graphics;
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
            //TileObjectData.newTile.Origin = Point16.Zero;
            //TileObjectData.newTile.UsesCustomCanPlace = true;
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

            //TileObjectData.newTile.Width = 3;
            //TileObjectData.newTile.Height = 4;
            //TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16 };

            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };

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
            if (Main.rand.Next(40) == 0) RandomUpdate(i, j);
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
            Main.NewText("Random Update");

            Tile bottomLeftTile = null; // Todo
            int bottomLeftTileX = 0;
            int bottomLeftTileY = 0;

            // Find the bottomLeftTile coords
            for (int x = 0; x <= 1; x++)
            {
                for (int y = 0; y >= -1; y--)
                {
                    if (Main.tile[i + x, j + y].type == Type)
                    {
                        bottomLeftTile = Main.tile[i + x, j + y];
                        bottomLeftTileX = i + x;
                        bottomLeftTileY = j + y;
                    }
                }
            }

            //Main.NewText("X: " + bottomLeftTileX);
            //Main.NewText("Y: " + bottomLeftTileY);
            //Main.NewText("Over");

            bottomLeftTile.frameX += 36;

            /*for (int x = 0; x <= 1; x++)
            {
                for (int y = 0; y <= 1; y++)
                {
                    if (Main.tile[bottomLeftTileX + x, bottomLeftTileY + y].frameX < 144)
                    {
                        Main.tile[bottomLeftTileX + x, bottomLeftTileY + y].frameX += 36;
                    }
                }
            }*/

            /*if (bottomLeftTile.frameX < 144)
            {
                bottomLeftTile.frameX += 36;
            }*/

            //Tile tile = Main.tile[i, j];
            //int topY = j - tile.frameY / 18 % 4;

            // Doesn't seem to work for the normal corn
            //int topY = j - Main.tile[i, j].frameY / 54 % 4;

            // This is needed as the i and j changes as in a multi tile each tile is separate so we need to make sure we are working with the right tile
            /*if (Main.tile[i + 2, j].type == Type) // Far left tile
            {
                for (int x = 0; x < 3; x++)
                {
                    if (Main.tile[i + x, topY].frameX < 270) // Top
                    {
                        Main.tile[i + x, topY].frameX += 54;
                    }

                    if (Main.tile[i + x, topY + 1].frameX < 270) // Middle up (y axis)
                    {
                        Main.tile[i + x, topY + 1].frameX += 54;
                    }

                    if (Main.tile[i + x, topY + 2].frameX < 270) // Middle down (y axis)
                    {
                        Main.tile[i + x, topY + 2].frameX += 54;
                    }

                    if (Main.tile[i + x, topY + 3].frameX < 270) // Bottom
                    {
                        Main.tile[i + x, topY + 3].frameX += 54;
                    }
                }
            }
            else if (Main.tile[i + 1, j].type == Type) // Middle tile (x axis)
            {
                for (int x = -1; x < 2; x++)
                {
                    if (Main.tile[i + x, topY].frameX < 270) // Top
                    {
                        Main.tile[i + x, topY].frameX += 54;
                    }

                    if (Main.tile[i + x, topY + 1].frameX < 270) // Middle up (y axis)
                    {
                        Main.tile[i + x, topY + 1].frameX += 54;
                    }

                    if (Main.tile[i + x, topY + 2].frameX < 270) // Middle down (y axis)
                    {
                        Main.tile[i + x, topY + 2].frameX += 54;
                    }

                    if (Main.tile[i + x, topY + 3].frameX < 270) // Bottom
                    {
                        Main.tile[i + x, topY + 3].frameX += 54;
                    }
                }
            }
            else
            {
                for (int x = -2; x < 2; x++) // Far right tile
                {
                    if (Main.tile[i + x, topY].frameX < 270) // Top
                    {
                        Main.tile[i + x, topY].frameX += 54;
                    }

                    if (Main.tile[i + x, topY + 1].frameX < 270) // Middle up (y axis)
                    {
                        Main.tile[i + x, topY + 1].frameX += 54;
                    }

                    if (Main.tile[i + x, topY + 2].frameX < 270) // Middle down (y axis)
                    {
                        Main.tile[i + x, topY + 2].frameX += 54;
                    }

                    if (Main.tile[i + x, topY + 3].frameX < 270) // Bottom
                    {
                        Main.tile[i + x, topY + 3].frameX += 54;
                    }
                }
            }*/

            // Works for 1x3 plant
            //Tile tile = Main.tile[i, j];
            //int topY = j - tile.frameY / 18 % 3;
            /*if (Main.tile[i, topY].frameX < 36)
            {
                Main.tile[i, topY].frameX += 18;
            }

            if (Main.tile[i, topY + 1].frameX < 36)
            {
                Main.tile[i, topY + 1].frameX += 18;
            }

            if (Main.tile[i, topY + 2].frameX < 36)
            {
                Main.tile[i, topY + 2].frameX += 18;
            }*/

            // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

            // For 2x1 plant
            // Need to do this as it keeps on switching between the 2 tiles so it needs to make sure which one it is in at the moment
            /*if (Main.tile[i + 1, j].type == Type)
            {
                if (Main.tile[i, j].frameX < 72)
                {
                    Main.tile[i, j].frameX += 36;
                }

                if (Main.tile[i + 1, j].frameX < 72)
                {
                    Main.tile[i + 1, j].frameX += 36;
                }
            }
            else
            {
                if (Main.tile[i, j].frameX < 72)
                {
                    Main.tile[i, j].frameX += 36;
                }

                if (Main.tile[i - 1, j].frameX < 72)
                {
                    Main.tile[i - 1, j].frameX += 36;
                }
            }*/
        }
    }
}