using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Ranged.Guns
{
    public class CorrosiveAlchemerGun : AlchemerGun
    {
        public CorrosiveAlchemerGun()
        {
            projType = "CorrosiveBulletProjectile";
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Inflicts \"Cursed Inferno\" to those hit by its bullets.");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("AlchemerCasing"));
            recipe.AddIngredient(ItemID.FlaskofCursedFlames, 10);
            recipe.AddIngredient(ItemID.CursedFlame, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
