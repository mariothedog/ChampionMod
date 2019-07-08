using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod
{
    public class MyPlayer : ModPlayer
    {
        public bool Bunny = false;
        public static bool hasProjectile;
        public bool BunnyMinion;
        public float LastDeathX;
        public float LastDeathY;
        public int memoryTimer = -1;
        public bool NaturesProtection = false;

        public override void ResetEffects()
        {
            Bunny = false;
            BunnyMinion = false;
            NaturesProtection = false;
        }

        public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
        {
            if (junk)
            {
                return;
            }

            if (Main.rand.Next(70) == 0 && player.ZoneJungle && NPC.downedGolemBoss && worldLayer != 1 && liquidType == 0) // 1/70 chance of catching if in jungle, Golem dead, not on surface and fishing in water
            {
                caughtType = mod.ItemType("MemoryFish");
            }
        }

        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            LastDeathX = player.position.X;
            LastDeathY = player.position.Y;
        }

        public override void ModifyZoom(ref float zoom)
		{
            // If player holding Snowball Rifle
            if (player.inventory[player.selectedItem].type == mod.ItemType("SnowballRifle"))
            {
			    zoom = 0.2f;
            }
		}

        public override void PreUpdate()
        {
            // For Memory Potion and Memory Lens
            if (memoryTimer > 0) // To delay the teleportation
            {
                Main.NewText(player.position);
                // Dust
                if (Main.rand.NextFloat() < 0.5f)
                {
                    Dust.NewDust(new Vector2(player.position.X, player.position.Y + 10f), 40, 40, 27, 0f, 0f, 100, default(Color));
                }

                memoryTimer -= 1;
            }
            // Brackets are very important because without them only the "LastDeathY != 0" needs to be true
            else if (memoryTimer == 0 && (LastDeathX != 0 || LastDeathY != 0))
            {
                // So timer doesn't decrease or teleports player/spawns dust
                memoryTimer = -1;

                // Teleport player
                player.position.X = player.GetModPlayer<MyPlayer>().LastDeathX;
                player.position.Y = player.GetModPlayer<MyPlayer>().LastDeathY;

                for (int i = 0; i < 70; i++) // Spawn lots of dust
                {
                    Dust.NewDust(new Vector2(player.position.X-40, player.position.Y), 110, 110, 27, 0f, 0f, 100, default(Color), 1.6f);
                }
            }
        }

        public override void UpdateLifeRegen()
        {
            if (NaturesProtection)
            {
                //player.lifeRegen /= 10;

                //player.lifeRegenTime = (int)(player.lifeRegenTime / 1.2);
                //player.lifeRegenCount -= 1;
                //player.lifeRegenTime -= 1;
                //player.lifeRegenTime /= 2;
                //player.lifeRegen -= 1;
                //player.lifeRegenCount -= 1;
                //Main.NewText(player.lifeRegen);
                //Main.NewText(player.lifeRegenTime);
                //Main.NewText(player.lifeRegenCount);

                /*float num2 = 0f;
                num2 = ((!player.shinyStone) ? (num2 / 2f) : (num2 * 0.75f));
                PlayerHooks.NaturalLifeRegen(player, ref num2);
                float num4 = (float)player.statLifeMax2 / 400f * 0.85f + 0.15f;
                num2 *= num4;
                player.lifeRegen += (int)Math.Round((double)num2);
                player.lifeRegenCount += player.lifeRegen;*/

                /*player.lifeRegen -= 1;

                if (player.lifeRegen < 0)
                {
                    player.lifeRegen = 0;
                }*/

                /*if (player.lifeRegenTime >= 300)
                {
                    player.lifeRegen += 1;
                    player.lifeRegenCount += player.lifeRegen;
                }*/

                if (player.lifeRegenTime >= 300)
                {
                    player.lifeRegenTime = 300;
                }

                Main.NewText(player.lifeRegenTime);
            }
        }
    }
}