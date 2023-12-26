using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.IRepositories;

    public interface IGenericRepository<T> where T : class
    {
        //[return: MaybeNull]
        Task<T> Get(int id,CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken);
        IAsyncEnumerable<T> AsAsyncEnumerable();
        Task Add(T entity,CancellationToken cancellationToken);
        void Delete(T entity );
        void Update(T entity );
        Task Save();
    }


