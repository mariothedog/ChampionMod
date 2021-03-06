using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;

namespace ChampionMod.Utils
{
    public class LiquidHelper : ModPlayer
    {
        public enum Liquids : byte
        {
            Water,
            Lava,
            Honey
        }

        internal static bool PlaceLiquids(Player player, int x, int y, Liquids liquid)
        {
            if (Main.netMode != NetmodeID.Server)
            {
                Tile tileSafely = Framing.GetTileSafely(x, y);
                if (player.whoAmI == Main.myPlayer)
                {
                    if ((!tileSafely.nactive() || !Main.tileSolid[(int)tileSafely.type] || Main.tileSolidTop[(int)tileSafely.type]) && (tileSafely.liquid == 0 || tileSafely.liquidType() == (byte)liquid))
                    {
                        tileSafely.liquidType((int)liquid);
                        tileSafely.liquid = 255;
                        WorldGen.SquareTileFrame(x, y, true);
                        if (Main.netMode == 1)
                        {
                            NetMessage.sendWater(x, y);
                        }
                        else
                        {
                            Liquid.AddWater(x, y);
                        }
                        return true;
                    }
                }
            }
            return false;
        }

        internal static bool ActuallyFreakingPlaceTheLiquidOMFG(Player player, Liquids liquid, int range)
        {
            if (player.whoAmI == Main.myPlayer && !player.noBuilding)
            {
                Vector2 adjustedPos = player.position / 16;
                float xDist = Math.Abs(Player.tileTargetX - adjustedPos.X);
                float yDist = Math.Abs(Player.tileTargetY - adjustedPos.Y);

                if (xDist > Player.tileRangeX + range || yDist > Player.tileRangeY + range)
                {
                    return false;
                }

                if (PlaceLiquids(player, Player.tileTargetX, Player.tileTargetY, liquid))
                {
                    Main.PlaySound(19, (int)player.position.X, (int)player.position.Y, 1, 1f, 0f);

                    return true;
                }
            }

            return false;
        }
    }
}
