using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Ranged.Guns
{
    public class BlazingAlchemerGun : AlchemerGun
    {
        public BlazingAlchemerGun()
        {
            projType = "BlazingBulletProjectile";
        }

        public override void SetStaticDefaults()
        {
            //projType = mod.ProjectileType("BlazingBulletProjectile");
            Tooltip.SetDefault("Inflicts \"On Fire!\" to those hit by its bullets.");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("AlchemerCasing"));
            recipe.AddIngredient(ItemID.FlaskofFire, 10);
            recipe.AddIngredient(ItemID.Hellstone, 70);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}