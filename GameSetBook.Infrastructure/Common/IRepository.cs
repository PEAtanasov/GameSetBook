using GameSetBook.Infrastructure.Models.Contracts;

namespace GameSetBook.Infrastructure.Common
{
    /// <summary>
    /// Implementing methods to access data
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Returns item with given id
        /// </summary>
        /// <typeparam name="T">type of item</typeparam>
        /// <param name="id">item identifier</param>
        /// <returns></returns>
        Task<T?> GetByIdAsync<T>(int id) where T : class;

        /// <summary>
        /// Returns item with given id
        /// </summary>
        /// <typeparam name="T">type of item</typeparam>
        /// <param name="id">item identifier</param>
        /// <returns></returns>
        Task<T?> GetByIdAsync<T>(string id) where T : class;

        /// <summary>
        /// Adding item in the database
        /// </summary>
        /// <typeparam name="T">type of item</typeparam>
        /// <param name="entity">item</param>
        /// <returns></returns>
        Task AddAsync<T>(T entity) where T : class;

        /// <summary>
        /// Delete item from database
        /// </summary>
        /// <typeparam name="T">type of item</typeparam>
        /// <param name="entity">item</param>
        /// <returns></returns>
        void Delete<T>(T entity) where T : class, IDeletable;

        /// <summary>
        /// Get all elements
        /// </summary>
        /// <typeparam name="T">Type of element</typeparam>
        /// <returns></returns>
        IQueryable<T> GetAll<T>() where T : class;

        /// <summary>
        /// Get all elements only for reading
        /// </summary>
        /// <typeparam name="T">Type of element</typeparam>
        /// <returns></returns>
        IQueryable<T> GetAllReadOnly<T>() where T : class;

        /// <summary>
        /// Get all elements including deleted items
        /// </summary>
        /// <typeparam name="T">Type of items</typeparam>
        /// <returns></returns>
        IQueryable<T> GetAllWithDeleted<T>() where T : class, IDeletable;

        /// <summary>
        /// Get all elements including deleted items only for reading
        /// </summary>
        /// <typeparam name="T">Type of items</typeparam>
        /// <returns></returns>
        IQueryable<T> GetAllWithDeletedReadOnly<T>() where T : class, IDeletable;

        /// <summary>
        /// Save changes into the database
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();

    }
}
