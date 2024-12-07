using MPA.Web.Controllers;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace MPA.Web.Tests.Controllers;

public class HomeController_Tests : MPAWebTestBase
{
    [Fact]
    public async Task Index_Test()
    {
        //Act
        var response = await GetResponseAsStringAsync(
            GetUrl<HomeController>(nameof(HomeController.Index))
        );

        //Assert
        response.ShouldNotBeNullOrEmpty();
    }
}
