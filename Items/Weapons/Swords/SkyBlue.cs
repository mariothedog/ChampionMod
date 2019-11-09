using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ChampionMod.Items.Weapons.Swords
{
	public class SkyBlue : ModItem
	{
		public override void SetDefaults() {
			item.damage = 6;           
			item.melee = true;          
			item.width = 36;            
			item.height = 36;           
			item.useTime = 15;          
			item.useAnimation = 15;         
			item.useStyle = 1;          
			item.knockBack = 4; 
			item.shoot = mod.ProjectileType("SmallStar");
			item.shootSpeed = 12f;
			item.value = Item.buyPrice(gold: 1);           //The value of the weapon
			item.rare = 2;              //The rarity of the weapon, from -1 to 13
			item.UseSound = SoundID.Item1;      //The sound when the weapon is using
			item.autoReuse = true;          //Whether the weapon can use automatically by pressing mousebutton
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		        {
            float numberProjectiles = 5; 
            float rotation = MathHelper.ToRadians(5); // adds spread
			
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1)));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
        
            return false; // False so it doesn't create another projectile like normal
	    }
    }
}
