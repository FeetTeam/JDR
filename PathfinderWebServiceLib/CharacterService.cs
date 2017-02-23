using PathfinderAdventure;
using PathfinderAdventure.BasePathFinder;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace PathfinderWebServiceLib
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public class CharacterService : ICharacterService
    {
        private object objetLock = new object();

        public event EventHandler<LogEventArgs> OnLog
        {
            add
            {
                lock (objetLock)
                {
                    onLog += value;
                }
            }
            remove
            {
                lock (objetLock)
                {
                    onLog -= value;
                }
            }
        }

        private event EventHandler<LogEventArgs> onLog;

        public string GetData(int value)
        {
        	if(onLog != null) onLog.Invoke(this, new LogEventArgs { Message = value.ToString() });
            //onLog?.Invoke(this, new LogEventArgs { Message = value.ToString() });
            return string.Format("You entered: {0}", value);
        }

        public IEnumerable<Character> GetCharacters()
        {
            var repo = new CharacterSetRepository();
            var res = repo.GetCharacters();
            return res;
        }

        public List<Ability> GetAbilities()
        {
            throw new Exception("A corriger");
            //var repo = new AbilitiesSetRepository();
            //var res = repo.GetAbilities();
            //return res;
        }

        public Character GetCharacterPersoWs(string name)
        {
            var repo = new CharacterSetRepository();
            var res = repo.GetCharacterPerso(name);
            return res;
        }

        public void CreateCharacter(CharacterWs c)
        {
            var repo = new CharacterSetRepository();
            if(c != null) repo.CreateCharacter(c.CharacterPersoWs);
            //repo.CreateCharacter(c?.CharacterPersoWs);
            //var repoAbilities = new AbilitiesSetRepository();
            //repoAbilities.CreateAbilitySet(c.CharacterPersoWs.AbilitiesSet);
        }

        public void UpdateCharacterPersoList(List<Character> lPerso)
        {
        }

        public void PartagePositionPerso(int ligne, int colonne)
        {
        }

        public IAsyncResult BeginGetCharacterPersoWs(string name, AsyncCallback clb, object asyncState)
        {
            throw new NotImplementedException();
        }

        public Character EndGetCharacterPersoWs(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public async Task<Character> GetCharacterPersoWs2Async(string name)
        {
            return await Task.Factory.StartNew(() => new CharacterSetRepository().GetCharacterPerso(name));
        }

        public IEnumerable<Race> GetRaces()
        {
            var repo = new RacesRepository();
            return repo.GetRaces();
        }
    }

    public class LogEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}