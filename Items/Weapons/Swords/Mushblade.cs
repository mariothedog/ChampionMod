using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Swords
{
	public class Mushblade : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 15;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 23;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 75000;
			item.rare = 1;
			item.UseSound = SoundID.Item15;
			item.autoReuse = true;
			item.useTurn = true;
			item.crit = 5;

			// Crit by default is 4
		}
	}
}
