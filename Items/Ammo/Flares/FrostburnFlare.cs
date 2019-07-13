using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Ammo.Flares
{
	public class FrostburnFlare : ModItem
	{
		public override void SetStaticDefaults()
        {
			//DisplayName.SetDefault("Frostburn Flare");
		}

		public override void SetDefaults()
        {
			item.damage = 2;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;             
			item.knockBack = 1.5f;
			item.value = 10;
			item.rare = 2;
			item.shoot = mod.ProjectileType("FrostburnFlareProjectile");   
			item.shootSpeed = 6f;                  
			item.ammo = AmmoID.Flare;              
		}

        // To do

        /*public override void AddRecipes()
         {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Flare, 10);
			recipe.AddIngredient(ItemID.IceTorch, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 10);
			recipe.AddRecipe();
        }*/


        /*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            return true;
        }*/
    }
}
