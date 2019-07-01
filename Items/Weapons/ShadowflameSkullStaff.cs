using Microsoft.XNA.Framework
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Champion.Items.Weapons
{
	 public class ShadowflameSkullStaff : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault(Shadowflame Skull Staff);
			Item.staff[item.type] = true; 
		}

		public override void SetDefaults() {
			item.damage = 45;
			item.magic = true;
			item.mana = 20;
			item.width = 40;
			item.height = 40;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = 5;
			item.noMelee = true; 
			item.knockBack = 4;
			item.value = 2;
			item.rare = 5;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = ProjectileID.585;
			item.shootSpeed = 5f;
		}
	}
}
