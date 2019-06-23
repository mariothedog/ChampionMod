using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Ammo
{
    public class SporeBullet : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 10;
            item.ranged = true;
            item.width = 14;
            item.height = 34;
            item.knockBack = 4;
            item.value = 20;
            item.rare = 1;
            item.maxStack = 999;
            item.consumable = true;
            item.ammo = AmmoID.Bullet;
            item.shoot = mod.ProjectileType("SporeBulletProjectile");
            item.shootSpeed = 10f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.EmptyBullet, 50);
            recipe.AddIngredient(ItemID.JungleSpores, 5);
            recipe.AddIngredient(ItemID.Mushroom, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
        }
    }
}