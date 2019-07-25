using ChampionMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Throwing
{
    public class CorruptorsKnife : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Corruptor's Knife");
        }
        
        public override void SetDefaults() {
            item.shootSpeed = 12f;
            item.damage = 35;
            item.knockBack = 6f;
            item.useStyle = 1;
            item.useAnimation = 22;
            item.useTime = 22;
            item.width = 30;
            item.height = 30;
            item.maxStack = 1;
            item.rare = 4;

            item.consumable = false;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.melee = true;

            item.UseSound = SoundID.Item1;
            item.value = Item.sellPrice(gold: 1);
            item.shoot = mod.ProjectileType("CorruptKnife");
        }
		
	    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float numberProjectiles = 2; 
            float rotation = MathHelper.ToRadians(3); // adds spread
			
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1)));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
        
            return false; // False so it doesn't create another projectile like normal
	    }
    }
}
