using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Ranged.Guns
{
    public class NanotechAlchemerGun : AlchemerGun
    {
        public NanotechAlchemerGun()
        {
            projType = "NanotechBulletProjectile";
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Inflicts \"Confused\" to those hit by its bullets.");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("AlchemerCasing"));
            recipe.AddIngredient(ItemID.FlaskofNanites, 10);
            recipe.AddIngredient(ItemID.Nanites, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}