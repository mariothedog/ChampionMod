using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Ammo.Arrows
{
    public class RoyalArrow : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 13;
            item.ranged = true;
            item.width = 14;
            item.height = 34;
            item.knockBack = 7;
            item.value = 5;
            item.rare = 1;
            item.maxStack = 999;
            item.consumable = true;
            item.ammo = 40;
            item.shoot = mod.ProjectileType("RoyalArrowProjectile");
            item.shootSpeed = 6f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("KingsGel"), 1);
            recipe.AddRecipeGroup("ChampionMod:Tier4Bars", 1);
            recipe.AddIngredient(ItemID.Gel, 10);
            recipe.AddIngredient(ItemID.WoodenArrow, 100);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 100);
            recipe.AddRecipe();
        }
    }
}