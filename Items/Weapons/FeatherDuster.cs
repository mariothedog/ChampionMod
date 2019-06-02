using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SingleSwordMod.Items.Weapons
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
            item.UseSound = SoundID.Item1;
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
            foreach (NPC npc in Main.npc)
            {
                if (Vector2.Distance(npc.Center, player.Center) <= 80)
                {
                    // First getsthe distance between the enemy and the player
                    // Then subtracts 50 so if the enemy is closer it will be smaller in the negatives (-30 compared to 10)
                    // Then it changes the negative number into a positive number (absolute value using Math.abs)
                    // Then it divides that value by 20 so the knockback isn't too big
                    // Then it gets multiplied by the player direction (player direction is 1 if facing right, -1 is facing left)
                    npc.velocity.X+= Math.Abs(Vector2.Distance(npc.Center, player.Center)-50)/20 * player.direction;
                }
            }
        }
    }
}
