using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.Enums;
using Microsoft.Xna.Framework.Graphics;

namespace ChampionMod.Tiles.Crops
{
    public class CornCrop : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileCut[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.StyleAlch);

            TileObjectData.newTile.Width = 3;
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 20 }; // Last one is 18 so it extends into the grass

            TileObjectData.newTile.Origin = new Point16(1, 3);

            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, 1, 1);

            TileObjectData.newTile.AnchorValidTiles = new[]
            {
                2, // Grass
                109 // Hallowed Grass
            };

            TileObjectData.addTile(Type);
        }

        public override bool CanPlace(int i, int j)
        {
            // So you can't hold down the corn seeds to constantly replace it
            // Since the corn crop is 3 blocks wide you also need to make sure it has enough space
            return Main.tile[i, j].type != Type && Main.tile[i + 1, j].type != Type && Main.tile[i - 1, j].type != Type;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int stage = frameX / 54;
            if (stage == 0)
            {
                for (int x = 0; x < 10; x++)
                {
                    Dust.NewDust(new Vector2((i + 1) * 16, (j + 3) * 16), 16, 16, 3);
                }
            }
            else if (stage == 1)
            {
                for (int x = 0; x < 10; x++)
                {
                    Dust.NewDust(new Vector2((i + 1) * 16, (j + 3) * 16), 16, 16, 3);
                    Dust.NewDust(new Vector2((i + 1) * 16, (j + 2) * 16), 16, 16, 3);
                }
            }
            else if (stage == 2)
            {
                for (int x = 0; x < 15; x++)
                {
                    Dust.NewDust(new Vector2((i + 1) * 16, (j + 3) * 16), 16, 16, 3);
                    Dust.NewDust(new Vector2((i + 1) * 16, (j + 2) * 16), 16, 16, 3);
                }
            }
            else if (stage == 3)
            {
                Item.NewItem(i * 16, j * 16, 0, 0, mod.ItemType("CornSeeds"), 1 + Main.rand.Next(3));
                Item.NewItem(i * 16, j * 16, 0, 0, mod.ItemType("Corn"), 1);

                for (int x = 0; x < 15; x++)
                {
                    Dust.NewDust(new Vector2((i + 1) * 16, (j + 3) * 16), 16, 16, 3);
                    Dust.NewDust(new Vector2((i + 1) * 16, (j + 2) * 16), 16, 16, 3);
                }

                for (int x = 0; x < 8; x++)
                {
                    Dust.NewDust(new Vector2((i + 1) * 16, (j + 1) * 16), 16, 16, mod.DustType("CornDust"));
                }
            }
            else if (stage == 4)
            {
                Item.NewItem(i * 16, j * 16, 0, 0, mod.ItemType("CornSeeds"), 2 + Main.rand.Next(3));
                Item.NewItem(i * 16, j * 16, 0, 0, mod.ItemType("Corn"), 1 + Main.rand.Next(3));

                for (int x = 0; x < 15; x++)
                {
                    Dust.NewDust(new Vector2((i + 1) * 16, (j + 3) * 16), 16, 16, 3);
                    Dust.NewDust(new Vector2((i + 1) * 16, (j + 2) * 16), 16, 16, 3);
                }

                for (int x = 0; x < 10; x++)
                {
                    Dust.NewDust(new Vector2((i + 1) * 16, (j + 1) * 16), 16, 16, mod.DustType("CornDust"));
                }
            }
        }

        public override void RandomUpdate(int i, int j)
        {
            // So it is not executing all this code for no reason when it's at the max stage
            // So it slows down the growth especially since there are 12 tiles that could be randomly updated
            // So the crop doesn't grow when it is not on the surface
            if (Main.tile[i, j].frameX < 216 && Main.rand.Next(90) == 0 && j < Main.worldSurface)
            {
                // Gets the top left tile coords
                int topLeftX = i - Main.tile[i, j].frameX / 18 % 3;
                int topLeftY = j - Main.tile[i, j].frameY / 18 % 4;

                for (int x = 0; x <= 2; x++)
                {
                    for (int y = 0; y <= 3; y++)
                    {
                        if (Main.tile[topLeftX + x, topLeftY + y].frameX < 216)
                        {
                            Main.tile[topLeftX + x, topLeftY + y].frameX += 54;
                            NetMessage.SendTileSquare(-1, topLeftX + x, topLeftY + y, 1); // For multiplayer syncing
                        }
                    }
                }
            }
        }

        public override bool CreateDust(int i, int j, ref int type)
        {
            return false;
        }

        public override bool KillSound(int i, int j)
        {
            Main.PlaySound(6, new Vector2(i * 16, j * 16));

            return false;
        }
    }
}