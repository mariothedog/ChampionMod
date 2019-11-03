using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Ammo.Bullets
{
    public class StoneBullet : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 4;
            item.ranged = true;
            item.width = 14;
            item.height = 34;
            item.knockBack = 2;
            item.maxStack = 999;
            item.consumable = true;
            item.ammo = AmmoID.Bullet;
            item.shoot = mod.ProjectileType("StoneBulletProjectile");
            item.shootSpeed = 4f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock);
            recipe.SetResult(this, 25);
            recipe.AddRecipe();
        }
    }
}