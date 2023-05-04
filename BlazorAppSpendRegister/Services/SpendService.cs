using BlazorAppSpendRegister.Models;
using Blazored.LocalStorage;
using System.Text.Json;

namespace BlazorAppSpendRegister.Services
{
    public class SpendService : ISpendService
    {
        private readonly ILocalStorageService localStorageService;
        public SpendService(ILocalStorageService localStorageService)
        {
            this.localStorageService = localStorageService;
        }

        private string spendsLocalStorageKey => "spendKey";

        public async Task<List<Spend>> GetSpends()
        {
            var spendsJson = await localStorageService.GetItemAsync<string>(spendsLocalStorageKey);
            if (string.IsNullOrWhiteSpace(spendsJson))
                return new();

            return JsonSerializer.Deserialize<List<Spend>>(spendsJson);
        }

        public async Task SaveSpends(List<Spend> spends)
        {
            var spendsJson = JsonSerializer.Serialize(spends);

            await localStorageService.SetItemAsync(spendsLocalStorageKey, spendsJson);
        }
    }
}
