using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DigiKalaShop.ViewModels.Users;
using DigiShop.Controllers;
using DigiShop.CoreBussiness.EfCoreDomains.AccessPermissions;
using DigiShop.CoreBussiness.EfCoreDomains.OTP;
using DigiShop.CoreBussiness.EfCoreDomains.Users;
using DigiShop.CoreBussiness.EfCoreDomains.UserSignInlogs;
using DigiShop.CoreBussiness.RepsPattern;
using DigiShop.InfraStructure.KaveNegar.SmsPanelService;
using DigiShop.SysCoreServices.Validators;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Crypto.Tls;
using Shouldly;
using Xunit;

namespace DigiShop.UnitTestEnviroment
{
    public class AccountControllerUnitTests
    {
        private readonly Mock<IAccountService> _mockAccountService;
        private readonly AccountController controller;
        
        public AccountControllerUnitTests()
        {
            _mockAccountService = new Mock<IAccountService>();
            controller = new AccountController(_mockAccountService.Object);
        }
        
        [Fact]
        // It tests out the view as a casted returned value 
        public async Task SignupTestAsyncForViewResult()
        {
            var result = await controller.Signup();
            Assert.IsType<ViewResult>(result);
        }
        // It Tests out modelstate while it's invalid ...
        // there is no moq in that 
        [Fact]
        public async Task SignupTestAsyncForCreating()
        {
            var Message = "این نام کاربری قبلا ثبت نام کرده";
            controller.ModelState.AddModelError("Phonenumber",Message);
            var user = new SignupViewModel()
            {
                Phonenumber = "09130242717"
            };
            var result = await controller.Signup(user);
            var IsViewResult = Assert.IsType<ViewResult>(result);
            var testUser = Assert.IsType<SignupViewModel>(IsViewResult.Model);
            Assert.Same(user.Phonenumber,testUser.Phonenumber);
        }
        // It is testing out model state while it's invalid using moq
        [Fact]
        public async Task SignupTestAsyncForCreatingByUsingMoqWhileModelStateInvalid()
        {
            var Message = "این نام کاربری قبلا ثبت نام کرده";
            controller.ModelState.AddModelError("Phonenumber",Message);
            var user = new User()
            {
                Phonenumber = "09130242717"
            };
            _mockAccountService.Verify(x=>x.SignupUserAsync(It.IsAny<User>()),Times.Never);
        }
        
        //it is testing out model state while it's valid using moq
        [Fact]
        public async Task SignupTestAsyncForCreatingUsingMoqWhileModelstateIsvalid()
        {
            var signupViewModel =new SignupViewModel();
            signupViewModel.Phonenumber = "09130242717";
            var user = new User()
            {
                Phonenumber = "09130242717"
            };
            _mockAccountService.Setup(r => r.SignupUserAsync(It.IsAny<User>())).Callback<User>(x => user = x);
      
            await controller.Signup(signupViewModel);
           _mockAccountService.Verify(x=>x.SignupUserAsync(It.IsAny<User>()),Times.Once);
           Assert.Equal(signupViewModel.Phonenumber,user.Phonenumber);
           Assert.Equal(user.Phonenumber,user.Phonenumber);
        }
        // It tests out if there is any redirections
        [Fact]
        public async Task SignupTestAsyncForRedirectingToVerify()
        {
            var user = new SignupViewModel()
            {
                Phonenumber = "09130242717"
            };
            var result = await controller.Signup(user);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Verify",redirectToActionResult.ActionName);
        }
      // this is just for practice ... a simeple unit test
        [Theory]
        [InlineData("2dab87")]
        public void Testguild(string code)
        {
            var validator = new Validator();
            Assert.True(validator.IsGuidValid(code));
        }

    }
}