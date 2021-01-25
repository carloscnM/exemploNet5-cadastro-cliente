using System;
using System.Collections.Generic;
using Cliente.APP.Entities;
using Cliente.APP.Repositories;

namespace Cliente.APP.BLL
{
    public class BoRestrictiveList 
    {
        private readonly IRestrictiveListRepository _restrictiveListRepository;
        public BoRestrictiveList()
        {
            _restrictiveListRepository = new RestrictiveListRepository();
        }
        
        internal bool HasRestriction(string cpf)
        {
            DateTime now = DateTime.Now;

            RestrictiveList restrict = _restrictiveListRepository.GetByCPF(cpf);
            if(restrict == null)
                return false;

            bool hasRestrict = BetweenPeriod(now, restrict.Started, restrict.Finish);

            return hasRestrict;
        }

        private static bool BetweenPeriod(DateTime now, DateTime Started, DateTime Finish)
        {
            return (now >= Started && now < Finish);
        }
    }
}