using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Ranged.Guns
{
    public class DreadfulAlchemerGun : AlchemerGun
    {
        public DreadfulAlchemerGun()
        {
            projType = "DreadfulBulletProjectile";
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Inflicts \"Poison\" to those hit by its bullets.");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("AlchemerCasing"));
            recipe.AddIngredient(ItemID.FlaskofPoison, 10);
            recipe.AddIngredient(ItemID.JungleSpores, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
