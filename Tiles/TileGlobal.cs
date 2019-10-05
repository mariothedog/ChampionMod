using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.NPCs
{
    public class TileGlobal : GlobalTile
    {
        public override bool Drop(int i, int j, int type)
        {
            // Verdant Leaf
            if (type == TileID.Trees && Main.rand.Next(20) == 0) // 5% drop chance
            {
                bool normalTree = false;

                // Goes through the blocks under the tile and checks if they are not a part of the tree and if it isn't then it will check if it is forest grass
                for (int x = 0; x < 10; x++)
                {
                    Tile tile = Main.tile[i, j + x];

                    if (tile.type == 2) // If it is normal grass
                    {
                        normalTree = true;
                    }
                }

                if (normalTree)
                {
                    Item.NewItem(new Vector2(i * 16, j * 16), mod.ItemType("VerdantLeaf"));
                }
            }

            return true; // True to drop the default items
        }
    }
}