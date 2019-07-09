using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.OtherMelee
{
	public class Pitchfork : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("You could pluck someone's eye out with this!");
		}

		public override void SetDefaults()
		{
			item.damage = 20;
			item.width = 40;
			item.height = 40;
            item.useTime = 30;
			item.useAnimation = 40;
			item.useStyle = 5;
			item.knockBack = 8;
			item.value = 25000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.useTurn = true;
		    item.scale = 1;
			item.melee = true;
            item.ranged = false;
            item.noUseGraphic = true; // Stops the melee animation               
            item.shootSpeed = 3f;
            item.shoot = 0; // So it doesn't shoot anything
            item.shoot = mod.ProjectileType("PitchforkProjectile");
            item.useAmmo = 0;     
	    }
		
	}
}