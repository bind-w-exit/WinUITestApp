using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using WinUITestApp.Models;
using WinUITestApp.Services;

namespace WinUITestApp.ViewModels
{
    public partial class MarketViewModel : BaseViewModel
    {
        [ObservableProperty]
        bool isUpdating;

        [ObservableProperty]
        private List<Coin> coins;

        TaskFactory uiFactory;
        ICryptoApiService _cryptoApiService;
        

        public MarketViewModel(ICryptoApiService cryptoApiService)
        {
            //var s = Environment.CurrentManagedThreadId;
            _cryptoApiService = cryptoApiService;    
            uiFactory = new TaskFactory(TaskScheduler.FromCurrentSynchronizationContext());
            IsUpdating = true;
            Task.Run(UpdateCoinsAsync);           
        }

        async Task UpdateCoinsAsync()
        {
            //var s = Environment.CurrentManagedThreadId;
            var res = await _cryptoApiService.GetCoins();

            // Update property in UI Theard (*>﹏<*)
            // Default binding mode in GridView is OneTime or what? ＞︿＜
            await uiFactory.StartNew(() => {
                Coins = res;
                IsUpdating = false;
                //var s = Environment.CurrentManagedThreadId;
            });
        }
    }
}
