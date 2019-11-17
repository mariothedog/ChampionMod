using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Champion.Items.Weapons
{
	public class Immolator : ModItem
	{
		public override void SetStaticDefaults() {
		}

		public override void SetDefaults() {
			item.damage = 70;           
			item.melee = true;          
			item.width = 44;           
			item.height = 44;           
			item.useTime = 34;          
			item.useAnimation = 34;         
			item.useStyle = 1;          
			item.knockBack = 8;         
			item.value = Item.buyPrice(gold: 1);           
			item.rare = 3;              
			item.UseSound = SoundID.Item1;      
			item.autoReuse = true;          
		}

		public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool(3)) {
				//Emit dusts when swing the sword
				int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, 127, 0f, 0f, 255, default);
			}
		}
	}
}
