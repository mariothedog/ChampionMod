using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Ammo.Arrows
{
    public class MeteorArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meteor Arrow");
        }
        public override void SetDefaults()
        {
            item.damage = 8;
            item.ranged = true;
            item.width = 14;
            item.height = 34;
            item.knockBack = 7;
            item.value = 5;
            item.rare = 1;
            item.maxStack = 999;
            item.consumable = true;
            item.ammo = 40;
            item.shoot = mod.ProjectileType("MeteorArrowProjectile");
            item.shootSpeed = 5f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodenArrow, 70);
            recipe.AddIngredient(ItemID.MeteoriteBar);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 70);
            recipe.AddRecipe();
        }

        
    }
}
