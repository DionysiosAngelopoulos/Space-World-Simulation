using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_World_Simulation {
	class AggressiveScout : GenericScout {
		public AggressiveScout(string name, Faction faction) : base(name, faction) {

		}

		public override void Update(Sector sector) {
			// This is an aggressive scout. Instead of fleeing like the generic
			// scout it will attack!

			if (station != null) {
				// We are in a station, this scout will exit and in the
				// next update cyclem, will atack.
				station.UnDock(this);
			}

			bool sure = false; // Read on it will be explained in line 41-42.

			foreach(Unit unit in sector.units) {
				if (faction.enemies.Contains(unit.faction)) {
					if (sure) {
						// We have an enemy. Does a conflict already exist?
						bool exist = false;
						foreach (Conflict conflict in sector.world.conflicts) {
							if (conflict.sectors.Contains(sector)) {
								exist = true;
								break;
							}
						}
						if (exist) {
							// Simply attack.
							unit.hull -= 1;
						} else {
							// A conflict does not exist. We must create one!
							List<Faction> temp = new List<Faction>();
							temp.Add(faction);
							temp.Add(unit.faction);
							sector.world.conflicts.Add(new Conflict(temp, sector));
						}

						// Make sure we do not search for a conflict again since
						// we no that a conflict for sure exists now.

						sure = true;
					} else {
						// We know for sure that a conflict does exist. Simply attack.
						unit.hull -= 1;
					}
				}
			}

			base.Update(sector);
		}
	}
}
