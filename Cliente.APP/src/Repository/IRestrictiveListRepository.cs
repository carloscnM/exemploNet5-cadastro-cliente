using System.Collections.Generic;
using Cliente.APP.Entities;

namespace Cliente.APP.Repositories
{
    public interface IRestrictiveListRepository
    {
        IList<RestrictiveList> Get();
        RestrictiveList Get(string id);
        RestrictiveList GetByCPF(string cpf);
        RestrictiveList Store(RestrictiveList RestrictiveList);
    
    }
}
