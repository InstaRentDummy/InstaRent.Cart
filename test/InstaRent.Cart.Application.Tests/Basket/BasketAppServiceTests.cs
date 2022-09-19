using InstaRent.Cart.Baskets;
using InstaRent.Cart.Services;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Caching;
using Xunit;

namespace InstaRent.Cart
{
    public class BasketAppServiceTests : CartApplicationTestBase
    {
        private readonly ICartAppService _cartAppService;
        private readonly IDistributedCache<Basket, string> _basketRepository;
        public BasketAppServiceTests()
        {
            _basketRepository = GetRequiredService<IDistributedCache<Basket, string>>();

            _cartAppService = GetRequiredService<ICartAppService>();
            
        }
        [Fact]
        public async Task AddBagAsync()
        {
            // Arrange
            var input = new AddBagDto
            {
                BagId = Guid.Parse("4a2d4f7e-c8ee-4495-984b-3eda432a7765"),
                BagName = "Gucci Wallet",
                StartDate = new DateTime(2022, 3, 20),
                EndDate = new DateTime(2023, 9, 24),
                Price = 100.00,
                Tags = new List<string>() { "Wallet" },
                RenterId = "renter1@gmail.com",
                Count = 1,
                LesseeId = "lesse1@gmail.com",
            };

            // Act
            var serviceResult = await _cartAppService.AddBagAsync(input);


            serviceResult.ShouldNotBe(null);
            serviceResult.Items[0].BagName.ShouldBe("Gucci Wallet");
            serviceResult.Items[0].StartDate.ShouldBe(new DateTime(2022, 3, 20));
            serviceResult.Items[0].EndDate.ShouldBe(new DateTime(2023, 9, 24));
            serviceResult.Items[0].price.ShouldBe(100.00);
            serviceResult.Items[0].Tags[0].ShouldBe("Wallet");
            serviceResult.Items[0].RenterId.ShouldBe("renter1@gmail.com"); 
            
        }


        [Fact]
        public async Task AddandRemoveBagAsync()
        {
            // Arrange
            var input = new AddBagDto
            {
                BagId = Guid.Parse("4a2d4f7e-c8ee-4495-984b-3eda432a7765"),
                BagName = "Gucci Wallet",
                StartDate = new DateTime(2022, 3, 20),
                EndDate = new DateTime(2023, 9, 24),
                Price = 100.00,
                Tags = new List<string>() { "Wallet" },
                RenterId = "renter_1@gmail.com",
                Count = 1,
                LesseeId = "lesse_1@gmail.com",
            };

            // Act
            var serviceResult = await _cartAppService.AddBagAsync(input);

            var inputRemove = new RemoveBagDto 
            {
                BagId = Guid.Parse("4a2d4f7e-c8ee-4495-984b-3eda432a7765"),
                Count = 1,
                LesseeId = "lesse_1@gmail.com",
            };

            // Act
            var removeResult = await _cartAppService.RemoveBagAsync(inputRemove);


            removeResult.TotalPrice.ShouldBe(0);
            removeResult.Items.Count.ShouldBe(0);

        }

    }
}