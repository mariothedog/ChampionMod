using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Ranged.Guns
{
    public class AcidicAlchemerGun : AlchemerGun
    {
        public AcidicAlchemerGun()
        {
            projType = "AcidicBulletProjectile";
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Inflicts \"Ichor\" to those hit by its bullets.");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("AlchemerCasing"));
            recipe.AddIngredient(ItemID.FlaskofIchor, 10);
            recipe.AddIngredient(ItemID.Ichor, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
