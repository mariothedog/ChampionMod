using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Magic.MagicStaffs
{
	 public class ShadowflameSkullStaff : ModItem
	{
		public override void SetStaticDefaults()
        {
			Item.staff[item.type] = true; 
		}

		public override void SetDefaults()
        {
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
			item.value = 100000;
			item.rare = 5;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = ProjectileID.ClothiersCurse;
			item.shootSpeed = 8f;
		}
	}
}
