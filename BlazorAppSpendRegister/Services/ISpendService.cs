using BlazorAppSpendRegister.Models;

namespace BlazorAppSpendRegister.Services
{
    public interface ISpendService
    {
        Task<List<Spend>> GetSpends();

        Task SaveSpends(List<Spend> spends);
    }
}
