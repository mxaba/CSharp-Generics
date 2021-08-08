namespace WiredBrainCoffee.StorageApp.Repositories
{
    public static class RespositoryExtensions
    {
        public static void addBatch<T>(this IWriteRepository<T> repository, T[] items){
            foreach(var item in items){
                repository.Add(item);
            }
            repository.Save();
        }
    }
}