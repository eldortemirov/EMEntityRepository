using Microsoft.EntityFrameworkCore;

namespace EMEntityRepository.Context
{
    public interface IDataContext
    {
        DbContext EMDataContext { get; }
    }
}
