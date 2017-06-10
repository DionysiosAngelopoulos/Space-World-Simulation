using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_World_Simulation {
	class GenericScout : Unit {
		public GenericScout(string name, Faction faction) : base(name, faction) {

		}

		public override void Update(Sector sector) {
			// The generic scout will not be an agressive class.
			// It will flee from combat.
			// FIXME: Make this come from configs and not a hard coded subclass.
			if (station != null) {
				// We are in a station, do nothing.
				return;
			}
			foreach(Conflict conf in sector.world.conflicts) {
				if (conf.sectors.Contains(sector)) {
					// We flee!
					Random rand = new Random();
					int num = rand.Next(sector.connections.Count());
					World.Move(sector, this, sector.connections[num]);
					// Debug
					Console.WriteLine("{0} at {1} -> {2}", name, sector.name, sector.connections[num].name);
					break;
				}
			}
			base.Update(sector);
		}
	}
}
