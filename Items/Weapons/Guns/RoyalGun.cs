using Microsoft.Xna.Framework;
using Terraria; 
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Guns
{
    public class RoyalGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("It feels like it will slip out of your hands.");
        }

        public override void SetDefaults() {
            item.damage = 11;
            item.ranged = true;
            item.width = 16;
            item.height = 16;
            item.useTime = 14;
            item.useAnimation = 23;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 4;
            item.UseSound = SoundID.Item11;
            item.shoot = 10;
            item.shootSpeed = 5f;
            item.useAmmo = AmmoID.Bullet;
			item.rare = 1;
			item.value = 50000;
            // If you are reading this, you're gay.
        }
		
		 public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.Slimed, 1200, false); // Slimed debuff for 20 seconds
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("KingsGel"), 5);;
            recipe.AddIngredient(ItemID.Gel, 100);
            recipe.AddRecipeGroup("ChampionMod:Tier4Bars", 15);
            recipe.AddTile(TileID.Anvils);
        }

    }
}