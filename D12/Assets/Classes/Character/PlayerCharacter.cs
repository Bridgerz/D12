using System;
using Assets.Classes.Traits;

namespace Assets.Classes.Character
{
    class PlayerCharacter : BaseCharacter
    {
        /// <summary>
        /// Trait management system
        /// </summary>
        public TraitSystem TraitTrees;

        public PlayerCharacter()
        {
            TraitTrees = new TraitSystem();
        }

    }
}
