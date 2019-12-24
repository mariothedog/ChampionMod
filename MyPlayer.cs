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
        public bool hasNaturesProtection = false;
        public bool NaturesProtectionBuff = false;

        public int primalDefence = 0;

        // Minions
        //public bool PrimalClump = false;

        public override void ResetEffects()
        {
            Bunny = false;
            BunnyMinion = false;
            //PrimalClump = false;
            hasNaturesProtection = false;
            NaturesProtectionBuff = false;
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
                // Dust
                if (Main.rand.NextFloat() < 0.5f)
                {
                    Dust.NewDust(new Vector2(player.position.X, player.position.Y + 10f), 40, 40, 27, 0f, 0f, 100, default);
                }

                memoryTimer -= 1;
            }
            // Brackets are very important because without them only the "LastDeathY != 0" needs to be true
            else if (memoryTimer == 0 && (LastDeathX != 0 || LastDeathY != 0))
            {
                // So timer doesn't decrease or teleports player/spawns dust
                memoryTimer = -1;

                // Teleport player
                player.Teleport(new Vector2(player.GetModPlayer<MyPlayer>().LastDeathX, player.GetModPlayer<MyPlayer>().LastDeathY));

                for (int i = 0; i < 70; i++) // Spawn lots of dust
                {
                    Dust.NewDust(new Vector2(player.position.X-40, player.position.Y), 110, 110, 27, 0f, 0f, 100, default, 1.6f);
                }
            }

            // If player holding normal flare gun
            if (player.inventory[player.selectedItem].type == ItemID.FlareGun)
            {
                if (player.itemAnimation <= 0) // If not shooting (just holding)
                {
                    int flareDustType = 0; // So if you don't have a flare equipped it won't show the dust
                    for (int i = 0; i < 4; i++) // Checks which flare comes first (to see which dust to use)
                    {
                        int slotType = player.inventory[54 + i].type;
                        if (slotType == 931 || slotType == 1614) // Flare and Blue Flare
                        {
                            break;
                        }
                        else if (slotType == 3965) // Frostburn Flare
                        {
                            flareDustType = 197;
                            break;
                        }
                    }

                    if (flareDustType == 197) // Frostburn Flare needs its own thing since it uses NewDustPerfect and has a different scale
                    {
                        Vector2 loc = new Vector2(player.itemLocation.X + 16f * player.direction, player.itemLocation.Y - 14f * player.gravDir);
                        player.itemLocation.Y -= 17;

                        loc.Y += 28;
                        loc.X -= 3;

                        if (player.direction == 1) // If facing right
                        {
                            // So it looks like the dust is coming out of the gun
                            loc.X += 41;
                        }

                        Dust dust;
                        // Top hole dust
                        dust = Dust.NewDustPerfect(loc, flareDustType, Vector2.Zero, 100);
                        dust.noGravity = true;
                        dust.velocity.Y -= 4f * player.gravDir;
                    }
                }
            }
        }

        public override void UpdateLifeRegen()
        {
            if (hasNaturesProtection)
            {
                // This decreases the health regeneration of the player as it can't reach the peak regen speed
                if (player.lifeRegenTime >= 320)
                {
                    player.lifeRegenTime = 0;
                }
            }
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (item.type == mod.ItemType("PrimalCleaver"))
            {
                if (primalDefence < 20)
                {
                    primalDefence += 1;
                }
            }
        }

        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            primalDefence = 0;
        }

        public override void PostUpdateBuffs()
        {
            player.statDefense += primalDefence;
        }

        /*public override void PostSellItem(NPC vendor, Item[] shopInventory, Item item)
        {
            player.QuickSpawnItem(ItemID.CopperCoin, (int)(item.value * 1.15f));
        }*/

        /*public override bool CanSellItem(NPC vendor, Item[] shopInventory, Item item)
        {
            //item.shopCustomPrice
            //item.value = (int)(item.value * 1.15f);
            //item.shopCustomPrice = 100;
            if (hasLuckyCat)
            {
                //Main.NewText("Value: " + item.value);
                //Main.NewText("Thing: " + item.shopCustomPrice);
                //Main.NewText("\n");
            }
            return true;
        }*/
    }
}