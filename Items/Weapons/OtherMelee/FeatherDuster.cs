using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.OtherMelee
{
    public class FeatherDuster : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Feather Duster");
            Tooltip.SetDefault("Clean your problems away");
        }
        public override void SetDefaults()
        {
            item.damage = 0;
            item.melee = true;
            item.width = 36;
            item.height = 36;
            item.useTime = 22;
            item.useAnimation = 22;
            item.useStyle = 1;
            item.knockBack = 20;
            item.value = 50;
            item.rare = 0;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Feather, 2);
            recipe.AddRecipeGroup("Wood", 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            // Goes through each npc when you swing the feather duster
            foreach (NPC npc in Main.npc)
            {
                // Checks if the distance between the npc and the player is less than or equal to 80
                // Checks if the enemy is not immune to knockback
                if (Vector2.Distance(npc.Center, player.Center) <= 80 && npc.knockBackResist != 0)
                {
                    // First gets the distance between the enemy and the player
                    // Then subtracts 50 so if the enemy is closer it will be smaller in the negatives (-30 compared to 10)
                    // Then it changes the negative number into a positive number (absolute value using Math.abs)
                    // Then it divides that value by 20 so the knockback isn't too big
                    // Then it gets multiplied by the player direction (player direction is 1 if facing right, -1 is facing left)
                    npc.velocity.X += Math.Abs(Vector2.Distance(npc.Center, player.Center)-50)/20 * player.direction;

                    // So the npc doesn't go super fast when hitting them multiple times with the feather duster
                    if (npc.velocity.X >= 6 || npc.velocity.X <= -6)
                    {
                        npc.velocity.X = 6 * player.direction;
                    }
                }
            }

            // Create dust
            if (Main.rand.NextFloat() < 0.3f) // So less spawns
            {
                Terraria.Dust.NewDust(hitbox.Center.ToVector2(), 30, 30, 0, 0f, 0f, 0, new Color(255,255,255), 0.9f);
            }

            // This condition is only true if the player is on the ground because when the player is in the air "hitbox.Center.Y - player.Center.Y" is equal to about 3 but when on the ground it is 4
            // It only becomes true (on the ground) when the feather duster is approaching the
            if (hitbox.Center.Y - player.Center.Y >= 4)
            {
                // SoundType.Custom meaning that it isn't in the item folder (SoundType.Item for that)
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/FeatherDusterSound"));
            }
        }
    }
}